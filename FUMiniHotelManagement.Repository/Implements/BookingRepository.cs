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
	public class BookingRepository : IBookingRepository
	{
		private BaseDAO<BookingReservation> bookingDAO;

		public BookingRepository()
		{
			bookingDAO = new BaseDAO<BookingReservation>();
		}

		public async Task<bool> CreateBookingAsync(BookingReservation booking)
		{
			return await bookingDAO.InsertAsync(booking) > 0;
		}

		public async Task<bool> DeleteBookingAsync(BookingReservation booking)
		{
			return await bookingDAO.DeleteAsync(booking) > 0;
		}

		public async Task<IEnumerable<BookingReservation>> GetAllBookingAsync()
		{
			return await bookingDAO.RetriveForceManyAsync(includeProperties: "Customer");
		}

		public async Task<BookingReservation?> GetBookingByIdAsync(Guid id)
		{
			return await bookingDAO.RetriveForceAsync(x => x.BookingReservationId == id);
		}

		public async Task<IEnumerable<BookingReservation?>> SearchBookingByCustomerNameAsync(string name)
		{
			var result = await bookingDAO.RetriveForceManyAsync(includeProperties: "Customer");
			return result.Where(x => x.Customer.FullName == name);
		}

		public async Task<bool> UpdateBookingAsync(BookingReservation booking)
		{
			var existBooking = await bookingDAO.RetriveForceAsync(x => x.BookingReservationId == booking.BookingReservationId);
			existBooking!.BookingDate = booking.BookingDate;
			existBooking.BookingStatus = booking.BookingStatus;
			existBooking.CustomerId = booking.CustomerId;
			existBooking.TotalPrice = booking.TotalPrice;
			return await bookingDAO.ModifyAsync(existBooking) > 0;
		}
	}
}
