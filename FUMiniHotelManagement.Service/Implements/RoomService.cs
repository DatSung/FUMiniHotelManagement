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
	public class RoomService : IRoomService
	{
		private IRoomRepository repository;

        public RoomService()
        {
            repository = new RoomRepository();
        }

        public async Task<bool> CreateRoomAsync(RoomInformation room)
		{
			return await repository.CreateRoomAsync(room);
		}

		public async Task<bool> DeleteRoomAsync(RoomInformation room)
		{
			return await repository.DeleteRoomAsync(room);
		}

		public async Task<IEnumerable<RoomInformation>> GetAllRoomAsync()
		{
			return await repository.GetAllRoomAsync();
		}

		public async Task<RoomInformation?> GetRoomByIdAsync(Guid id)
		{
			return await repository.GetRoomByIdAsync(id);
		}

		public async Task<IEnumerable<RoomInformation?>> SearchRoomByRoomNumberAsync(string roomNumber)
		{
			return await repository.SearchRoomByRoomNumberAsync(roomNumber);
		}

		public async Task<bool> UpdateRoomAsync(RoomInformation room)
		{
			return await repository.UpdateRoomAsync(room);
		}
	}
}
