using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.DAO.Context;
using FUMiniHotelManagement.Service.Interfaces;

namespace FUMiniHotelManagement.Razor.Pages.BookingDetailPage
{
    public class EditModel : PageModel
    {
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;


        public EditModel(IBookingDetailService bookingDetailService, IBookingService bookingService,
            IRoomService roomService)
        {
            _bookingDetailService = bookingDetailService;
            _bookingService = bookingService;
            _roomService = roomService;
        }

        [BindProperty] public BookingDetail BookingDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id, Guid? roomId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingdetail = _bookingDetailService.GetAllBookingDetailByBookingIdAsync(id.Value).GetAwaiter()
                .GetResult().FirstOrDefault(x => x.RoomId == roomId);
            if (bookingdetail == null)
            {
                return NotFound();
            }

            BookingDetail = bookingdetail;
            ViewData["BookingReservationId"] = new SelectList(await _bookingService.GetAllBookingAsync(),
                "BookingReservationId",
                "BookingReservationId");
            ViewData["RoomId"] = new SelectList(await _roomService.GetAllRoomAsync(), "RoomId", "RoomNumber");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["BookingReservationId"] = new SelectList(await _bookingService.GetAllBookingAsync(),
                "BookingReservationId",
                "BookingReservationId");
            ViewData["RoomId"] = new SelectList(await _roomService.GetAllRoomAsync(), "RoomId", "RoomNumber");
            
            try
            {
                await _bookingDetailService.UpdateBookingDetailAsync(BookingDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailExists(BookingDetail.BookingReservationId, BookingDetail.RoomId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingDetailExists(Guid id, Guid roomId)
        {
            return _bookingDetailService.GetAllBookingDetailByBookingIdAsync(id).GetAwaiter().GetResult()
                .FirstOrDefault(x => x.RoomId == roomId) is not null;
        }
    }
}