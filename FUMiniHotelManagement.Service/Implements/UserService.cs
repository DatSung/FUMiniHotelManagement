using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.Repository.Implements;
using FUMiniHotelManagement.Repository.Interfaces;
using FUMiniHotelManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelManagement.Service.Implements
{
	public class UserService : IUserService
	{
		private IUserRepository repository;

		public UserService()
		{
			repository = new UserRepository();
		}

		public async Task<User?> CheckLoginAsync(string email, string password)
		{
			var user = await repository.GetUserByEmailAsync(email);

			if (user == null)
			{
				return null;
			}

			var isPasswordCorrect = user.Password!.Equals(password);

			if (!isPasswordCorrect)
			{
				return null;
			}

			return user;

		}

		public async Task<bool> CreateUserAsync(User user)
		{
			return await repository.CreateUserAsync(user);
		}

		public async Task<bool> DeleteUserAsync(User user)
		{
			return await repository.DeleteUserAsync(user);
		}

		public async Task<IEnumerable<User>> GetAllUserAsync()
		{
			return await repository.GetAllUserAsync();
		}

		public async Task<User?> GetUserByEmailAsync(string email)
		{
			return await repository.GetUserByEmailAsync(email);
		}

		public async Task<User?> GetUserByIdAsync(Guid id)
		{
			return await repository.GetUserByIdAsync(id);
		}

		public async Task<IEnumerable<User?>> SearchUserByNameAsync(string name)
		{
			return await repository.SearchUserByNameAsync(name);
		}

		public async Task<bool> UpdateUserAsync(User user)
		{
			return await repository.UpdateUserAsync(user);
		}
	}
}
