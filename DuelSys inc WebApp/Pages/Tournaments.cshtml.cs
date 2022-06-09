using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    [Authorize]
    public class TournamentsModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public string TournamentSportName { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/AllTournamentsPerSport", new {TournamentSportName});
        }
    }
}
