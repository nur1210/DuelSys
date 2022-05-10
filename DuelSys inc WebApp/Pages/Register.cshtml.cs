using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace DuelSys_inc_WebApp.Pages
{
    public class RegisterModel : PageModel
    {

        [BindProperty] public Registration RegisterForm { get; set; }

        public RegisterModel()
        {
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {

        }

        public class Registration
        {
            [Required]
            [Display(Name = "First name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last name")]
            public string LastName { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Compare(nameof(Password), ErrorMessage = "Please make sure both passwords are identical")]
            public string RepeatPassword { get; set; }

            public Registration()
            {
            }

            public Registration(string firstName, string lastName, string email, string password, string repeatPassword)
            {
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                Password = password;
                RepeatPassword = repeatPassword;
            }
        }
    }
}
