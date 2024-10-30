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

namespace FUMiniHotelManagement.Razor.Pages.BookingDetailPage
{
    public class DetailsModel : PageModel
    {
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public DetailsModel(IBookingDetailService bookingDetailService, IRoomService roomService, IBookingService bookingService)
        {
            _bookingDetailService = bookingDetailService;
            _roomService = roomService;
            _bookingService = bookingService;
        }

        public BookingDetail BookingDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id, Guid roomId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingdetail = _bookingDetailService.GetAllBookingDetailByBookingIdAsync(id.Value).GetAwaiter()
                .GetResult().FirstOrDefault(x => x.RoomId == roomId);
            bookingdetail.Room = await _roomService.GetRoomByIdAsync(bookingdetail.RoomId);
            bookingdetail.BookingReservation =
                await _bookingService.GetBookingByIdAsync(bookingdetail.BookingReservationId);
            if (bookingdetail == null)
            {
                return NotFound();
            }
            else
            {
                BookingDetail = bookingdetail;
            }

            return Page();
        }
    }
}