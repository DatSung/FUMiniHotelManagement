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
    public class DeleteModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public DeleteModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty] public BookingReservation BookingReservation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingreservation = await _bookingService.GetBookingByIdAsync(id.Value);

            if (bookingreservation == null)
            {
                return NotFound();
            }
            else
            {
                BookingReservation = bookingreservation;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingreservation = await _bookingService.GetBookingByIdAsync(id.Value);

            if (bookingreservation != null)
            {
                BookingReservation = bookingreservation;
                await _bookingService.DeleteBookingAsync(bookingreservation);
            }

            return RedirectToPage("./Index");
        }
    }
}