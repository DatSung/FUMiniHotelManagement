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

namespace FUMiniHotelManagement.Razor.Pages.UserPage
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty] public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByIdAsync(id.Value);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            var users = await _userService.GetAllUserAsync();
            if (id == null || users == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByIdAsync(id.Value);

            if (user != null)
            {
                User = user;

                await _userService.DeleteUserAsync(User);
            }

            return RedirectToPage("./Index");
        }
    }
}