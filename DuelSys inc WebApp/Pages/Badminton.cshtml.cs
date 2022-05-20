using System.Security.Claims;
using Logic.Models;
using Logic.Services;
using Logic.Views;
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
        public MatchService MatchService { get; }
        [BindProperty] public int TournamentId { get; set; }
        [BindProperty] public List<TournamentView> StartedTournaments { get; set; }
        public BadmintonModel(TournamentService tournamentService, UserService userService, Validation validation)
        {
            Validation = validation;
            TournamentService = tournamentService;
            UserService = userService;
        }

        public void OnGet()
        {
            StartedTournaments = TournamentService.GetAllBadmintonTournamentsForView()
                .Where(x => TournamentService.TournamentHasStarted(x.Id))
                .ToList();
        }

        public IActionResult OnPost()
        {
            var userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var tournamentId = TournamentId;
            UserService.RegisterUserToTournament(userId, tournamentId);
            return Page();
        }

        public IActionResult OnPostViewMatches()
        {
            return RedirectToPage("/RoundRobinMatches", new { TournamentId });
        }
    }
}
