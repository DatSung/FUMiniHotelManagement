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

namespace FUMiniHotelManagement.Razor.Pages.RoomPage
{
    public class EditModel : PageModel
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;

        public EditModel(IRoomService roomService, IRoomTypeService roomTypeService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
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

            RoomInformation = roominformation;
            ViewData["RoomTypeId"] =
                new SelectList(await _roomTypeService.GetAllRoomTypeAsync(), "RoomTypeId", "RoomTypeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _roomService.UpdateRoomAsync(RoomInformation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomInformationExists(RoomInformation.RoomId))
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

        private bool RoomInformationExists(Guid id)
        {
            return _roomService.GetRoomByIdAsync(id).GetAwaiter().GetResult() is not null;
        }
    }
}