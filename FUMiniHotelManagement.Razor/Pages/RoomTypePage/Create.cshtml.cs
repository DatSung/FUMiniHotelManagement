using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FUMiniHotelManagement.BusinessObject.Entities;
using FUMiniHotelManagement.DAO.Context;
using FUMiniHotelManagement.Service.Interfaces;

namespace FUMiniHotelManagement.Razor.Pages.RoomTypePage
{
    public class CreateModel : PageModel
    {
        private readonly IRoomTypeService _roomTypeService;

        public CreateModel(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public RoomType RoomType { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || RoomType == null)
            {
                return Page();
            }

            await _roomTypeService.CreateRoomTypeAsync(RoomType);

            return RedirectToPage("./Index");
        }
    }
}