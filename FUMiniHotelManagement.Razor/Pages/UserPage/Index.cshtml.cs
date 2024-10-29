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
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        public IndexModel( IUserService userService)
        {
            _userService = userService;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var users = await _userService.GetAllUserAsync();
            if (users != null)
            {
                User = users.ToList();
            }
        }
    }
}
