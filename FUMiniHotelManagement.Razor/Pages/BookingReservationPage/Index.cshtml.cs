using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.DAO.Context;
using FUMiniHotelManagement.Service.Interfaces;

namespace FUMiniHotelManagement.Razor.Pages.BookingReservationPage
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IUserService _userService;

        public IndexModel(IBookingService bookingService, IUserService userService)
        {
            _bookingService = bookingService;
            _userService = userService;
        }

        public IList<BookingReservation> BookingReservation { get; set; } = default!;

        public async Task OnGetAsync()
        { 
            var bookings = await _bookingService.GetAllBookingAsync();
            foreach (var booking in bookings)
            {
                booking.Customer = await _userService.GetUserByIdAsync(booking.CustomerId);
            }

            BookingReservation = bookings.ToList();
        }
    }
}