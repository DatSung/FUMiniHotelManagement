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
	public class RoomRepository : IRoomRepository
	{
		private BaseDAO<RoomInformation> roomDAO;

        public RoomRepository()
        {
			roomDAO = new BaseDAO<RoomInformation>();
        }

        public async Task<bool> CreateRoomAsync(RoomInformation room)
		{
			return await roomDAO.InsertAsync(room) > 0;
		}

		public async Task<bool> DeleteRoomAsync(RoomInformation room)
		{
			return await roomDAO.DeleteAsync(room) > 0;
		}

		public async Task<IEnumerable<RoomInformation>> GetAllRoomAsync()
		{
			return await roomDAO.RetriveForceManyAsync(includeProperties: "RoomType");
		}

		public async Task<RoomInformation?> GetRoomByIdAsync(Guid id)
		{
			return await roomDAO.RetriveForceAsync(x=>x.RoomId == id);
		}

		public async Task<IEnumerable<RoomInformation?>> SearchRoomByRoomNumberAsync(string roomNumber)
		{
			return await roomDAO.RetriveForceManyAsync(x=> x.RoomNumber.ToLower().Trim().Contains(roomNumber.ToLower().Trim()));
		}

		public async Task<bool> UpdateRoomAsync(RoomInformation room)
		{
			var existRoom = await roomDAO.RetriveAsync(x => x.RoomId == room.RoomId);

			if (existRoom is null)
			{
				return false;
			}

			existRoom.RoomDetailDescription = room.RoomDetailDescription;
			existRoom.RoomPricePerDay = room.RoomPricePerDay;
			existRoom.RoomMaxCapacity = room.RoomMaxCapacity;
			existRoom.RoomNumber = room.RoomNumber;
			existRoom.RoomStatus = room.RoomStatus;
			existRoom.RoomTypeId = room.RoomTypeId;

			return await roomDAO.ModifyAsync(existRoom) > 0;
		}
	}
}
