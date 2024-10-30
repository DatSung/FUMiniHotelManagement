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

namespace FUMiniHotelManagement.Razor.Pages.RoomPage
{
    public class CreateModel : PageModel
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;

        public CreateModel(IRoomService roomService, IRoomTypeService roomTypeService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["RoomTypeId"] =
                new SelectList(await _roomTypeService.GetAllRoomTypeAsync(), "RoomTypeId", "RoomTypeName");
            return Page();
        }

        [BindProperty] public RoomInformation RoomInformation { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || RoomInformation == null)
            {
                return Page();
            }


            await _roomService.CreateRoomAsync(RoomInformation);

            return RedirectToPage("./Index");
        }
    }
}