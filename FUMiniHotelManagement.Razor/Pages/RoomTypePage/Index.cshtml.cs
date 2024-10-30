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

namespace FUMiniHotelManagement.Razor.Pages.RoomTypePage
{
    public class IndexModel : PageModel
    {
        private readonly IRoomTypeService _roomTypeService;

        public IndexModel(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        public IList<RoomType> RoomType { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var roomTypes = await _roomTypeService.GetAllRoomTypeAsync();
            if (roomTypes != null)
            {
                RoomType = roomTypes.ToList();
            }
        }
    }
}