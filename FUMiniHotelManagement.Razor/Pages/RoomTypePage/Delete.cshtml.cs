﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.DAO.Context;

namespace FUMiniHotelManagement.Razor.Pages.RoomTypePage
{
    public class DeleteModel : PageModel
    {
        private readonly FUMiniHotelManagement.DAO.Context.FUMiniHotelManagementContext _context;

        public DeleteModel(FUMiniHotelManagement.DAO.Context.FUMiniHotelManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RoomType RoomType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.RoomTypes == null)
            {
                return NotFound();
            }

            var roomtype = await _context.RoomTypes.FirstOrDefaultAsync(m => m.RoomTypeId == id);

            if (roomtype == null)
            {
                return NotFound();
            }
            else 
            {
                RoomType = roomtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.RoomTypes == null)
            {
                return NotFound();
            }
            var roomtype = await _context.RoomTypes.FindAsync(id);

            if (roomtype != null)
            {
                RoomType = roomtype;
                _context.RoomTypes.Remove(RoomType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
