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
    public class DeleteModel : PageModel
    {
        private readonly IRoomService _roomService;

        public DeleteModel(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [BindProperty] public RoomInformation RoomInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roominformation = await _roomService.GetRoomByIdAsync(id.Value);

            if (roominformation == null)
            {
                return NotFound();
            }
            else
            {
                RoomInformation = roominformation;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roominformation = await _roomService.GetRoomByIdAsync(id.Value);

            if (roominformation != null)
            {
                RoomInformation = roominformation;
                await _roomService.DeleteRoomAsync(RoomInformation);
            }

            return RedirectToPage("./Index");
        }
    }
}