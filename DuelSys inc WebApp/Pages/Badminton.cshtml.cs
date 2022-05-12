using System.Security.Claims;
using Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    [Authorize]
    public class BadmintonModel : PageModel
    {
        public TournamentService TournamentService { get; set; }
        public UserService UserService { get; set; }
        [BindProperty] public int TournamentId { get; set; }
        public BadmintonModel(TournamentService tournamentService, UserService userService)
        {
            TournamentService = tournamentService;
            UserService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserService.RegisterUserToTournament(userId, TournamentId);
            return Page();
        }
    }
}
