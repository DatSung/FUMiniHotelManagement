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

namespace FUMiniHotelManagement.Razor.Pages.RoomPage
{
    public class IndexModel : PageModel
    {
        private readonly FUMiniHotelManagement.DAO.Context.FUMiniHotelManagementContext _context;
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;

        public IndexModel(IRoomService roomService, IRoomTypeService roomTypeService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
        }

        public IList<RoomInformation> RoomInformation { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var rooms = await _roomService.GetAllRoomAsync();
            RoomInformation = rooms.ToList();
            foreach (var room in RoomInformation)
            {
                room.RoomType = await _roomTypeService.GetRoomTypeByIdAsync(room.RoomTypeId);
            }
        }
    }
}