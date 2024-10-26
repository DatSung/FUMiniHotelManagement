using FUMiniHotelManagement.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelManagement.Service.Interfaces
{
	public interface IUserService
	{
		Task<User?> CheckLoginAsync(string email, string password);
		Task<IEnumerable<User>> GetAllUserAsync();
		Task<User?> GetUserByEmailAsync(string email);
		Task<User?> GetUserByIdAsync(Guid id);
		Task<bool> CreateUserAsync(User user);
		Task<bool> UpdateUserAsync(User user);
		Task<bool> DeleteUserAsync(User user);
		Task<IEnumerable<User?>> SearchUserByNameAsync(string name);
	}
}
