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
	public class BookingService : IBookingService
	{
		private IBookingRepository repository;

		public BookingService()
		{
			this.repository = new BookingRepository();
		}

		public async Task<bool> CreateBookingAsync(BookingReservation booking)
		{
			return await repository.CreateBookingAsync(booking);
		}

		public async Task<bool> DeleteBookingAsync(BookingReservation booking)
		{
			return await repository.DeleteBookingAsync(booking);
		}

		public async Task<IEnumerable<BookingReservation>> GetAllBookingAsync()
		{
			return await repository.GetAllBookingAsync();
		}

		public async Task<BookingReservation?> GetBookingByIdAsync(Guid id)
		{
			return await repository.GetBookingByIdAsync(id);
		}

		public async Task<IEnumerable<BookingReservation?>> SearchBookingByCustomerNameAsync(string name)
		{
			return await repository.SearchBookingByCustomerNameAsync(name);
		}

		public async Task<bool> UpdateBookingAsync(BookingReservation booking)
		{
			return await repository.UpdateBookingAsync(booking);
		}
	}
}
