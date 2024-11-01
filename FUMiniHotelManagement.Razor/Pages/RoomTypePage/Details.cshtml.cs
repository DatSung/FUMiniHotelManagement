﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.DAO.Context;
using FUMiniHotelManagement.Service.Interfaces;

namespace FUMiniHotelManagement.Razor.Pages.RoomTypePage
{
    public class DetailsModel : PageModel
    {
        private readonly IRoomTypeService _roomTypeService;
        public DetailsModel(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        public RoomType RoomType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _roomTypeService.GetRoomTypeByIdAsync(id.Value);
            if (roomType == null)
            {
                return NotFound();
            }
            else
            {
                RoomType = roomType;
            }

            return Page();
        }
    }
}