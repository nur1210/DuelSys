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
        public Validation Validation;
        public TournamentService TournamentService { get; set; }
        public UserService UserService { get; set; }
        [BindProperty] public int TournamentId { get; set; }
        public BadmintonModel(TournamentService tournamentService, UserService userService, Validation validation)
        {
            Validation = validation;
            TournamentService = tournamentService;
            UserService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var tournamentId = TournamentId;
            UserService.RegisterUserToTournament(userId, tournamentId);
            return Page();
        }
    }
}
