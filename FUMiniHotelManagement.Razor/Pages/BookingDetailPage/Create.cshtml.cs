using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.DAO.Context;
using FUMiniHotelManagement.Service.Interfaces;

namespace FUMiniHotelManagement.Razor.Pages.BookingDetailPage
{
    public class CreateModel : PageModel
    {
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public CreateModel(IBookingDetailService bookingDetailService, IBookingService bookingService,
            IRoomService roomService)
        {
            _bookingDetailService = bookingDetailService;
            _bookingService = bookingService;
            _roomService = roomService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["BookingReservationId"] = new SelectList(await _bookingService.GetAllBookingAsync(),
                "BookingReservationId",
                "BookingReservationId");
            ViewData["RoomId"] = new SelectList(await _roomService.GetAllRoomAsync(), "RoomId", "RoomNumber");
            return Page();
        }

        [BindProperty] public BookingDetail BookingDetail { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (BookingDetail == null)
            {
                ViewData["BookingReservationId"] = new SelectList(await _bookingService.GetAllBookingAsync(),
                    "BookingReservationId",
                    "BookingReservationId");
                ViewData["RoomId"] = new SelectList(await _roomService.GetAllRoomAsync(), "RoomId", "RoomNumber");
                return Page();
            }

            await _bookingDetailService.CreateBookingDetailAsync(BookingDetail);

            return RedirectToPage("./Index");
        }
    }
}