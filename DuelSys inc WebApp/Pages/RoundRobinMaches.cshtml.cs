using Logic.Models;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    public class RoundRobinMatchesModel : PageModel
    {
        public ResultService ResultService { get; }
        public MatchService MatchService;
        [BindProperty] public List<Result> TournamentResults { get; set; }
        [BindProperty] public List<Match> TournamentPlayedMatches { get; set; }

        public RoundRobinMatchesModel(MatchService matchService, ResultService resultService)
        {
            ResultService = resultService;
            MatchService = matchService;
        }
        public void OnGet()
        {
            TournamentResults = ResultService.GetAllResultsForTournament(1);
            TournamentPlayedMatches = MatchService.GetAllPlayedMatchesPerTournament(1);
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/AddResult", 1);
        }
    }
}
