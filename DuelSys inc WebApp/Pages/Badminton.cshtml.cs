using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    public class BadmintonModel : PageModel
    {
        public TournamentService TournamentService { get; set; }
        public BadmintonModel(TournamentService tournamentService)
        {
            TournamentService = tournamentService;
        }

        public void OnGet()
        {
        }
    }
}
