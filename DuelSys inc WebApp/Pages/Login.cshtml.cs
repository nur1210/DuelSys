using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using Logic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public Credential credential { get; set; }
        public UserService UserManager { get; set; }
        public Validation Validation { get; set; }
        private readonly INotyfService _toastNotification;

        public LoginModel(UserService userManager, INotyfService toastNotification, Validation validation)
        {
            UserManager = userManager;
            _toastNotification = toastNotification;
            Validation = validation;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (!Validation.ValidUser(credential.Email, credential.Password)) return Page();
            var user = UserManager.GetUserByEmail(credential.Email);
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, credential.Email),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
            _toastNotification.Success("Login successful!");
            return user.IsAdmin ? RedirectToPage("/UsersView") : RedirectToPage("/Tournaments");
        }

    }
    public class Credential
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
