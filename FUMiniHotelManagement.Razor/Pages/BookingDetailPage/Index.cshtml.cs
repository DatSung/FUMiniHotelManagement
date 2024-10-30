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
    public class IndexModel : PageModel
    {
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public IndexModel(IBookingDetailService bookingDetailService, IBookingService bookingService,
            IRoomService roomService)
        {
            _bookingDetailService = bookingDetailService;
            _bookingService = bookingService;
            _roomService = roomService;
        }

        public IList<BookingDetail> BookingDetail { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var bookingDetails = await _bookingDetailService.GetAllBookingDetailAsync();
            foreach (var bookingDetail in bookingDetails)
            {
                bookingDetail.BookingReservation =
                    await _bookingService.GetBookingByIdAsync(bookingDetail.BookingReservationId);
                bookingDetail.Room = await _roomService.GetRoomByIdAsync(bookingDetail.RoomId);
            }

            BookingDetail = bookingDetails.ToList();
        }
    }
}