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

namespace FUMiniHotelManagement.Razor.Pages.BookingReservationPage
{
    public class EditModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IUserService _userService;

        public EditModel(IBookingService bookingService, IUserService userService)
        {
            _bookingService = bookingService;
            _userService = userService;
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

            BookingReservation = bookingreservation;
            ViewData["CustomerId"] = new SelectList(await _userService.GetAllUserAsync(), "UserId", "EmailAddress");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await _bookingService.UpdateBookingAsync(BookingReservation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingReservationExists(BookingReservation.BookingReservationId))
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

        private bool BookingReservationExists(Guid id)
        {
            return _bookingService.GetBookingByIdAsync(id).GetAwaiter().GetResult() is not null;
        }
    }
}