﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.DAO.Context;

namespace FUMiniHotelManagement.Razor.Pages.RoomPage
{
    public class IndexModel : PageModel
    {
        private readonly FUMiniHotelManagement.DAO.Context.FUMiniHotelManagementContext _context;

        public IndexModel(FUMiniHotelManagement.DAO.Context.FUMiniHotelManagementContext context)
        {
            _context = context;
        }

        public IList<RoomInformation> RoomInformation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.RoomInformations != null)
            {
                RoomInformation = await _context.RoomInformations
                .Include(r => r.RoomType).ToListAsync();
            }
        }
    }
}