using Logic.Models;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    public class RoundRobinMatchesModel : PageModel
    {
        public ResultService ResultService { get; }
        public UserService UserService { get; }
        public MatchService MatchService { get; }
        [BindProperty] public List<Result> TournamentResults { get; set; }
        [BindProperty] public List<Match> TournamentPlayedMatches { get; set; }
        [BindProperty] public Dictionary<int, string> PlayerIdAndFullName { get; set; }
        [BindProperty] public Dictionary<int, List<Match>> AllMatchesPerPlayer { get; set; }
        [BindProperty(SupportsGet = true)] public int TournamentId { get; set; }


        public RoundRobinMatchesModel(MatchService matchService, ResultService resultService, UserService userService)
        {
            ResultService = resultService;
            UserService = userService;
            MatchService = matchService;
        }
        public void OnGet()
        {
            TournamentResults = ResultService.GetAllResultsForTournament(TournamentId);
            TournamentPlayedMatches = MatchService.GetAllPlayedMatchesPerTournament(TournamentId);
            PlayerIdAndFullName = UserService.GetAllUsersIdAndFullName();
            AllMatchesPerPlayer = MatchService.GetAllMatchesPerPlayer(TournamentId);
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/AddResult", 1);
        }
    }
}
