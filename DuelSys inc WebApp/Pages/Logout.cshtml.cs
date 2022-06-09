using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostLogout()
        {
            if (HttpContext.User.Identity?.IsAuthenticated == true)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return LocalRedirect("/Index");
        }

        public IActionResult OnPost()
        {
            return LocalRedirect(ReturnUrl ?? "/Index");
        }
    }
}
