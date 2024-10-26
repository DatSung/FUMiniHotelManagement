using FUMiniHotelManagement.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelManagement.Repository.Interfaces
{
	public interface IBookingDetailRepository
	{
		Task<IEnumerable<BookingDetail>> GetAllBookingDetailAsync();
		Task<IEnumerable<BookingDetail>> GetAllBookingDetailByBookingIdAsync(Guid id);
		Task<BookingDetail?> GetBookingDetailRoomNumberAsync(Guid id);
		Task<bool> CreateBookingDetailAsync(BookingDetail bookingDetail);
		Task<bool> UpdateBookingDetailAsync(BookingDetail bookingDetail);
		Task<bool> DeleteBookingDetailAsync(BookingDetail bookingDetail);
	}
}
