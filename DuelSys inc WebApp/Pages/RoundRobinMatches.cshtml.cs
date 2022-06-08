 using AspNetCoreHero.ToastNotification.Abstractions;
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
        [BindProperty] public Leaderboard Leaderboard { get; set; }
        [BindProperty(SupportsGet = true)] public int TournamentId { get; set; }
        private readonly INotyfService _toastNotification;



        public RoundRobinMatchesModel(MatchService matchService, ResultService resultService, UserService userService, TournamentService tournamentService, INotyfService toastNotification)
        {
            ResultService = resultService;
            UserService = userService;
            TournamentService = tournamentService;
            _toastNotification = toastNotification;
            MatchService = matchService;
        }
        public void OnGet()
        {
            TournamentResults = ResultService.GetAllResultsForTournament(TournamentId);
            TournamentPlayedMatches = MatchService.GetAllPlayedMatchesPerTournament(TournamentId);
            PlayerIdAndFullName = UserService.GetAllUsersIdAndFullName();
            AllMatchesPerPlayer = MatchService.GetAllMatchesPerPlayer(TournamentId);
            Leaderboard = TournamentService.GetTournamentLeaderboard(TournamentId);
            _toastNotification.Information("Press the results", 10);
        }
    }
}
