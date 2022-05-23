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
        public TournamentService TournamentService { get; }
        public MatchService MatchService { get; }
        [BindProperty] public List<Result> TournamentResults { get; set; }
        [BindProperty] public List<Match> TournamentPlayedMatches { get; set; }
        [BindProperty] public Dictionary<int, string> PlayerIdAndFullName { get; set; }
        [BindProperty] public Dictionary<int, List<Match>> AllMatchesPerPlayer { get; set; }
        [BindProperty] public Dictionary<User, int> Leaderboard { get; set; }
        [BindProperty(SupportsGet = true)] public int TournamentId { get; set; }


        public RoundRobinMatchesModel(MatchService matchService, ResultService resultService, UserService userService, TournamentService tournamentService)
        {
            ResultService = resultService;
            UserService = userService;
            TournamentService = tournamentService;
            MatchService = matchService;
        }
        public void OnGet()
        {
            TournamentResults = ResultService.GetAllResultsForTournament(TournamentId);
            TournamentPlayedMatches = MatchService.GetAllPlayedMatchesPerTournament(TournamentId);
            PlayerIdAndFullName = UserService.GetAllUsersIdAndFullName();
            AllMatchesPerPlayer = MatchService.GetAllMatchesPerPlayer(TournamentId);
            Leaderboard = TournamentService.GetTournamentLeaderboard(TournamentId);
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/AddResult", 1);
        }
    }
}
