using FUMiniHotelManagement.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelManagement.Repository.Interfaces
{
    public interface IRoomRepository
    {
		Task<IEnumerable<RoomInformation>> GetAllRoomAsync();
		Task<RoomInformation?> GetRoomByIdAsync(Guid id);
		Task<bool> CreateRoomAsync(RoomInformation room);
		Task<bool> UpdateRoomAsync(RoomInformation room);
		Task<bool> DeleteRoomAsync(RoomInformation room);
		Task<IEnumerable<RoomInformation?>> SearchRoomByRoomNumberAsync(string roomNumber);
	}
}
