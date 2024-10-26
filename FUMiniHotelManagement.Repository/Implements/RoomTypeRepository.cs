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
	public class RoomTypeRepository : IRoomTypeRepository
	{
		private BaseDAO<RoomType> roomTypeDAO;

        public RoomTypeRepository()
        {
            roomTypeDAO = new BaseDAO<RoomType>();
        }

        public async Task<bool> CreateRoomTypeAsync(RoomType roomType)
		{
			return await roomTypeDAO.InsertAsync(roomType) > 0;
		}

		public async Task<bool> DeleteRoomTypeAsync(RoomType roomType)
		{
			return await roomTypeDAO.DeleteAsync(roomType) > 0;
		}

		public async Task<IEnumerable<RoomType>> GetAllRoomTypeAsync()
		{
			return await roomTypeDAO.RetriveForceManyAsync();
		}

		public async Task<RoomType?> GetRoomTypeByIdAsync(Guid id)
		{
			return await roomTypeDAO.RetriveAsync(x => x.RoomTypeId == id);
		}

		public async Task<bool> UpdateRoomTypeAsync(RoomType roomType)
		{
			var existRoomType = await roomTypeDAO.RetriveAsync(x => x.RoomTypeId == roomType.RoomTypeId);
			if (existRoomType is null) 
			{
				return false;
			}

			existRoomType = roomType;

			return await roomTypeDAO.ModifyAsync(existRoomType) > 0;
		}
	}
}
