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

namespace FUMiniHotelManagement.Razor.Pages.RoomTypePage
{
    public class EditModel : PageModel
    {

        private readonly IRoomTypeService _roomTypeService;
        
        public EditModel(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [BindProperty]
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
            RoomType = roomType;
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
                await _roomTypeService.UpdateRoomTypeAsync(RoomType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypeExists(RoomType.RoomTypeId))
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

        private bool RoomTypeExists(Guid id)
        {
          return _roomTypeService.GetRoomTypeByIdAsync(id).GetAwaiter().GetResult() is not null;
        }
    }
}
