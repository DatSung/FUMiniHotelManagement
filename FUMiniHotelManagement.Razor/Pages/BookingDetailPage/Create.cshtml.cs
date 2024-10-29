﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.DAO.Context;

namespace FUMiniHotelManagement.Razor.Pages.BookingDetailPage
{
    public class CreateModel : PageModel
    {
        private readonly FUMiniHotelManagement.DAO.Context.FUMiniHotelManagementContext _context;

        public CreateModel(FUMiniHotelManagement.DAO.Context.FUMiniHotelManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookingReservationId"] = new SelectList(_context.BookingReservations, "BookingReservationId", "BookingReservationId");
        ViewData["RoomId"] = new SelectList(_context.RoomInformations, "RoomId", "RoomNumber");
            return Page();
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BookingDetails == null || BookingDetail == null)
            {
                return Page();
            }

            _context.BookingDetails.Add(BookingDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}