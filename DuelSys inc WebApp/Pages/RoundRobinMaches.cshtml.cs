using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages.Shared
{
    public class RoundRobinMatchesModel : PageModel
    {
        public MatchService MatchService;
        public TournamentService TournamentService;

        public RoundRobinMatchesModel(MatchService matchService, TournamentService tournamentService)
        {
            MatchService = matchService;
            TournamentService = tournamentService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/AddResult", 1);
        }
    }
}
