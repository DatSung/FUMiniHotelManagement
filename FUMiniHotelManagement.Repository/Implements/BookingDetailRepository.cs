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
	public class BookingDetailRepository : IBookingDetailRepository
	{
		private BaseDAO<BookingDetail> bookingDetailDAO;

		public BookingDetailRepository()
		{
			this.bookingDetailDAO = new BaseDAO<BookingDetail>();
		}

		public async Task<bool> CreateBookingDetailAsync(BookingDetail bookingDetail)
		{
			return await bookingDetailDAO.InsertAsync(bookingDetail) > 0;
		}

		public async Task<bool> DeleteBookingDetailAsync(BookingDetail bookingDetail)
		{
			return await bookingDetailDAO.DeleteAsync(bookingDetail) > 0;
		}

		public async Task<IEnumerable<BookingDetail>> GetAllBookingDetailAsync()
		{
			return await bookingDetailDAO.RetriveForceManyAsync();
		}

		public async Task<IEnumerable<BookingDetail>> GetAllBookingDetailByBookingIdAsync(Guid id)
		{
			return await bookingDetailDAO.RetriveForceManyAsync(x => x.BookingReservationId == id);
		}

		public Task<BookingDetail?> GetBookingDetailRoomNumberAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> UpdateBookingDetailAsync(BookingDetail bookingDetail)
		{
			var existBookingDetail = await bookingDetailDAO.RetriveForceAsync(x => x.BookingReservationId == bookingDetail.BookingReservationId && x.RoomId == bookingDetail.RoomId);

			existBookingDetail.StartDate =bookingDetail.StartDate;
			existBookingDetail.EndDate = bookingDetail.EndDate;


			return await bookingDetailDAO.ModifyAsync(bookingDetail) > 0;
		}
	}
}
