using FUMiniHotelManagement.DAO.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelManagement.DAO.DAOS
{
	public class BaseDAO<T> where T : class
	{
		private FUMiniHotelManagementContext _Context;
		private DbSet<T> DbSet;

		public BaseDAO()
		{
			_Context = new FUMiniHotelManagementContext();
			DbSet = _Context.Set<T>();
		}

		public async Task<int> InsertAsync(T Entity)
		{
            _Context = new FUMiniHotelManagementContext();
            DbSet = _Context.Set<T>();
            DbSet.Add(Entity);
            return await _Context.SaveChangesAsync();
		}

		public async Task<int> DeleteAsync(T Entity)
		{
            _Context = new FUMiniHotelManagementContext();
            DbSet = _Context.Set<T>();
            DbSet.Remove(Entity);
			return await _Context.SaveChangesAsync();
		}

		public async Task<int> ModifyAsync(T Entity)
		{
            _Context = new FUMiniHotelManagementContext();
            DbSet = _Context.Set<T>();
            DbSet.Update(Entity);
			return await _Context.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> RetriveManyAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
            _Context = new FUMiniHotelManagementContext();
            DbSet = _Context.Set<T>();

            IQueryable<T> query = DbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(property);
				}
			}

			return await query.ToListAsync();
		}

		public async Task<IEnumerable<T>> RetriveForceManyAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
            _Context = new FUMiniHotelManagementContext();
            DbSet = _Context.Set<T>();

            List<T> results = new List<T>();

			if (filter != null)
			{
				var filteredEntities = await DbSet.Where(filter).ToListAsync();

				foreach (var entity in filteredEntities)
				{
					await _Context.Entry(entity).ReloadAsync();
					results.Add(entity);
				}
			}
			else
			{
				var allEntities = await DbSet.ToListAsync();
				foreach (var entity in allEntities)
				{
					_Context.Entry(entity).Reload();
					results.Add(entity);
				}
			}

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					foreach (var result in results)
					{
						_Context.Entry(result).Reference(property).Load();
					}
				}
			}

			return results;
		}


		public async Task<T> RetriveAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
		{
            _Context = new FUMiniHotelManagementContext();
            DbSet = _Context.Set<T>();

            IQueryable<T> query = DbSet;
			query = query.Where(filter);


			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(property);
				}
			}

			return await query.FirstOrDefaultAsync();
		}


		public async Task<T?> RetriveForceAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
		{
            _Context = new FUMiniHotelManagementContext();
            DbSet = _Context.Set<T>();

            var entity = await DbSet.FirstOrDefaultAsync(filter);

			if (entity != null)
			{
				await _Context.Entry(entity).ReloadAsync();
			}

			IQueryable<T> query = DbSet;

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(property);
				}
			}

			return await query.FirstOrDefaultAsync(filter);
		}
	}
}