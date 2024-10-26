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
	public class RoomTypeService : IRoomTypeService
	{
		private IRoomTypeRepository repository;

        public RoomTypeService()
        {
            repository = new RoomTypeRepository();
        }

        public async Task<bool> CreateRoomTypeAsync(RoomType roomType)
		{
			return await repository.CreateRoomTypeAsync(roomType);
		}

		public async Task<bool> DeleteRoomTypeAsync(RoomType roomType)
		{
			return await repository.DeleteRoomTypeAsync(roomType);
		}

		public async Task<IEnumerable<RoomType>> GetAllRoomTypeAsync()
		{
			return await repository.GetAllRoomTypeAsync();
		}

		public async Task<RoomType?> GetRoomTypeByIdAsync(Guid id)
		{
			return await repository.GetRoomTypeByIdAsync(id);
		}

		public async Task<bool> UpdateRoomTypeAsync(RoomType roomType)
		{
			return await repository.UpdateRoomTypeAsync(roomType);
		}
	}
}
