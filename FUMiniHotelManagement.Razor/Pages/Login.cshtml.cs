using FUMiniHotelManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace FUMiniHotelManagement.Razor.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginInputModel LoginInput { get; set; }

        private readonly IUserService userService;

        public LoginModel(IUserService userService)
        {
            this.userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userService.CheckLoginAsync(LoginInput.Email, LoginInput.Password);
            if (user == null) 
            {
                return Page();  
            }

            HttpContext.Session.SetString("Role", user.Role!);

            return Redirect("/UserPage");
           
        }

        public class LoginInputModel
        {
            [Required(ErrorMessage = "Email is required")]
            //[EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
        }
    }
}
