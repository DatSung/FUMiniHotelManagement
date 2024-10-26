using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.DAO.DAOS;
using FUMiniHotelManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelManagement.Repository.Implements
{
	public class UserRepository : IUserRepository
	{
		private BaseDAO<User> userDAO;

		public UserRepository()
		{
			userDAO = new BaseDAO<User>();
		}

		public async Task<bool> CreateUserAsync(User user)
		{
			return await userDAO.InsertAsync(user) > 0;
		}

		public async Task<bool> DeleteUserAsync(User user)
		{
			return await userDAO.DeleteAsync(user) > 0;
		}

		public async Task<IEnumerable<User>> GetAllUserAsync()
		{
			return await userDAO.RetriveForceManyAsync();
		}

		public async Task<User?> GetUserByEmailAsync(string email)
		{
			return await userDAO.RetriveForceAsync(x => x.EmailAddress == email);
		}

		public async Task<User?> GetUserByIdAsync(Guid id)
		{
			return await userDAO.RetriveForceAsync(x => x.UserId == id);
		}

		public async Task<IEnumerable<User?>> SearchUserByNameAsync(string name)
		{
			return await userDAO.RetriveForceManyAsync(x => x.FullName!.Trim().ToLower().Contains(name.Trim().ToLower()));
		}

		public async Task<bool> UpdateUserAsync(User user)
		{
			var existUser = await userDAO.RetriveAsync(x => x.UserId == user.UserId);
			if (existUser is null) return false;
			existUser.Telephone = user.Telephone;
			existUser.Role = user.Role;
			existUser.AvatarUrl = user.AvatarUrl;
			existUser.EmailAddress = user.EmailAddress;
			existUser.Birthday = user.Birthday;
			existUser.FullName = user.FullName;
			existUser.Status = user.Status;
			existUser.Password = user.Password;
			return await userDAO.ModifyAsync(existUser) > 0;
		}
	}
}
