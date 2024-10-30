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

namespace FUMiniHotelManagement.Razor.Pages.BookingReservationPage
{
    public class CreateModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IUserService _userService;

        public CreateModel(IBookingService bookingService, IUserService userService)
        {
            _bookingService = bookingService;
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["CustomerId"] = new SelectList(await _userService.GetAllUserAsync(), "UserId", "EmailAddress");
            return Page();
        }

        [BindProperty] public BookingReservation BookingReservation { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            BookingReservation.BookingReservationId = Guid.NewGuid();
            if (ModelState.IsValid || BookingReservation == null)
            {
                ViewData["CustomerId"] = new SelectList(await _userService.GetAllUserAsync(), "UserId", "EmailAddress");
                return Page();
            }

            await _bookingService.CreateBookingAsync(BookingReservation);

            return RedirectToPage("./Index");
        }
    }
}