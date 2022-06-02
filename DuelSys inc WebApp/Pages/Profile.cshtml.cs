using System.Security.Claims;
using Logic.Models;
using Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        public UserService UserService { get; }
        public MatchService MatchService { get; }
        [BindProperty] public string UserFullName { get; set; }
        [BindProperty] public User User { get; set; }
        [BindProperty] public List<Match> PlayedMatches{ get; set; }

        public ProfileModel(UserService userService, MatchService matchService)
        {
            UserService = userService;
            MatchService = matchService;
        }
        public void OnGet()
        {
            var userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            User = UserService.GetUserById(userId);
            UserFullName = UserService.GetAllUsersIdAndFullName()
                .Where(x => x.Key == userId)
                .Select(y => y.Value)
                .First();
            PlayedMatches = MatchService.GetAllPlayedMatchesPerUser(userId);
        }

        //public IActionResult OnPost()
        //{
        //    return RedirectToPage("/EditProfile", new {User.Id});
        //}
    }
}
