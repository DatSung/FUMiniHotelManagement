using FUMiniHotelManagement.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelManagement.Service.Interfaces
{
	public interface IRoomTypeService
	{
		Task<IEnumerable<RoomType>> GetAllRoomTypeAsync();
		Task<RoomType?> GetRoomTypeByIdAsync(Guid id);
		Task<bool> CreateRoomTypeAsync(RoomType roomType);
		Task<bool> UpdateRoomTypeAsync(RoomType roomType);
		Task<bool> DeleteRoomTypeAsync(RoomType roomType);
	}
}
