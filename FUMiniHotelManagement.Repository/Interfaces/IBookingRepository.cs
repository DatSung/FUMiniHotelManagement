using FUMiniHotelManagement.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUMiniHotelManagement.Repository.Interfaces
{
    public interface IBookingRepository
    {
		Task<IEnumerable<BookingReservation>> GetAllBookingAsync();
		Task<BookingReservation?> GetBookingByIdAsync(Guid id);
		Task<bool> CreateBookingAsync(BookingReservation booking);
		Task<bool> UpdateBookingAsync(BookingReservation booking);
		Task<bool> DeleteBookingAsync(BookingReservation booking);
		Task<IEnumerable<BookingReservation?>> SearchBookingByCustomerNameAsync(string name);
	}
}
