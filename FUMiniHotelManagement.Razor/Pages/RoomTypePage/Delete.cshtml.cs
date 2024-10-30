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
    public class DeleteModel : PageModel
    {
        private readonly IRoomTypeService _roomTypeService;

        public DeleteModel(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [BindProperty] public RoomType RoomType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var roomTypes = await _roomTypeService.GetAllRoomTypeAsync();
            if (id == null || roomTypes == null)
            {
                return NotFound();
            }

            var roomType = roomTypes.FirstOrDefault(x => x.RoomTypeId == id);

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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = await _roomTypeService.GetRoomTypeByIdAsync(id.Value);

            if (roomType != null)
            {
                RoomType = roomType;
                await _roomTypeService.DeleteRoomTypeAsync(RoomType);
            }

            return RedirectToPage("./Index");
        }
    }
}