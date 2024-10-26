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
	public class BookingDetailService : IBookingDetailService
	{
		private IBookingDetailRepository repository;

		public BookingDetailService()
		{
			this.repository = new BookingDetailRepository();
		}

		public async Task<bool> CreateBookingDetailAsync(BookingDetail bookingDetail)
		{
			return await repository.CreateBookingDetailAsync(bookingDetail);
		}

		public async Task<bool> DeleteBookingDetailAsync(BookingDetail bookingDetail)
		{
			return await repository.CreateBookingDetailAsync(bookingDetail);
		}

		public async Task<IEnumerable<BookingDetail>> GetAllBookingDetailAsync()
		{
			return await repository.GetAllBookingDetailAsync();
		}

		public async Task<IEnumerable<BookingDetail>> GetAllBookingDetailByBookingIdAsync(Guid id)
		{
			return await repository.GetAllBookingDetailByBookingIdAsync(id);
		}

		public async Task<BookingDetail?> GetBookingDetailRoomNumberAsync(Guid id)
		{
			return await repository.GetBookingDetailRoomNumberAsync(id);
		}

		public async Task<bool> UpdateBookingDetailAsync(BookingDetail bookingDetail)
		{
			return await repository.UpdateBookingDetailAsync(bookingDetail);
		}
	}
}
