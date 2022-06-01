using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using Logic.Models;
using Logic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    public class EditProfileModel : PageModel
    {
        public UserService UserService { get; }
        public Validation Validation { get; }
        public User User { get; set; }
        [BindProperty] public string FirstName { get; set; }
        [BindProperty] public string LastName { get; set; }

        [BindProperty]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindProperty]
        [Display(Name = "Current password")]
        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [BindProperty]
        [Display(Name = "New password")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [BindProperty]
        [Display(Name = "Repeat password")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string? RepeatPassword { get; set; }

        private readonly INotyfService _toastNotification;

        public EditProfileModel(UserService userService, Validation validation, INotyfService toastNotification)
        {
            UserService = userService;
            Validation = validation;
            _toastNotification = toastNotification;
        }

        public void OnGet(int id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated) return;
            //var id = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            User = UserService.GetUserById(id);
            FirstName = User.FirstName;
            LastName = User.LastName;
            Email = User.Email;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || !HttpContext.User.Identity.IsAuthenticated) return Page();
            var id = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            User = UserService.GetUserById(id);
            if (!string.IsNullOrEmpty(NewPassword) && Validation.ValidatePassword(CurrentPassword, User.Password))
            {
                User.FirstName = FirstName;
                User.LastName = LastName;
                if (Validation.ValidEmail(Email))
                {
                    User.Email = Email;
                }
                User.Password = NewPassword;
                UserService.UpdateUserPassword(User);
                _toastNotification.Success("Updated successfully");
                return RedirectToPage("/Profile");
            }

            User.FirstName = FirstName;
            User.LastName = LastName;
            if (Validation.ValidEmail(Email))
            {
                User.Email = Email;
            }
            UserService.UpdateUser(User);
            _toastNotification.Success("Updated successfully");
            return RedirectToPage("/Profile");
        }
    }
}
