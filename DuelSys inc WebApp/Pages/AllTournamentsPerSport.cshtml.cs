using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Enums;
using AspNetCoreHero.ToastNotification.Toastify.Models;
using Logic.Exceptions;
using Logic.Models;
using Logic.Services;
using Logic.Validator;
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
        private readonly INotyfService _toastNotification;
        public TournamentService TournamentService { get; set; }
        public UserService UserService { get; set; }
        [BindProperty] public int TournamentId { get; set; }
        [BindProperty(SupportsGet = true)] public int TournamentStageFilter { get; set; }
        [BindProperty(SupportsGet = true)] public string TournamentSportName { get; set; }
        [BindProperty] public List<TournamentView> GetAllTournamentViews { get; set; }
        [BindProperty] public List<TournamentView> GetAllFilteredTournaments { get; set; }
        [BindProperty] public List<TournamentView> GetAllStartedTournaments { get; set; }
        [BindProperty] public string Error { get; set; }

        public BadmintonModel(TournamentService tournamentService, UserService userService, Validation validation, INotyfService toastNotification)
        {
            Validation = validation;
            _toastNotification = toastNotification;
            TournamentService = tournamentService;
            UserService = userService;
        }

        public void OnGet()
        {
            GetAllTournamentViews = TournamentService.GetAllTournamentsForView(TournamentSportName);
            GetAllFilteredTournaments =
                    TournamentService.GetAllFilteredTournaments(TournamentStageFilter, GetAllTournamentViews);
            GetAllStartedTournaments =
            GetAllTournamentViews.Where(x => TournamentService.TournamentHasStarted(x.Id)).ToList();
        }

        public IActionResult OnPost()
        {
            var userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var tournamentId = TournamentId;
            if (UserService.RegisterUserToTournament(userId, tournamentId))
            {
                _toastNotification.Success("Registered successfully!");
            }
            else
            {
                _toastNotification.Warning("Not able to register");
            }
            return Page();
        }

        public IActionResult OnPostViewMatches()
        {
            return RedirectToPage("/RoundRobinMatches", new { TournamentId });
        }

        public IActionResult OnPostFilter()
        {
            var sportName = Request.Form["sportName"];
            return RedirectToPage("/AllTournamentsPerSport", new { TournamentStageFilter, TournamentSportName = sportName });
        }
    }
}
