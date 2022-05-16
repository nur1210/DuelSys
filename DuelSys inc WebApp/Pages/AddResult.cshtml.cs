using System.Dynamic;
using System.Runtime.Serialization;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DuelSys_inc_WebApp.Pages
{
    public class AddResultModel : PageModel
    {
        public MatchService MatchService { get; }
        public ResultService ResultService { get; set; }

        [BindProperty(SupportsGet = true)] public int TournamentId { get; set; }
        [BindProperty] public string PlayerOneResult { get; set; }
        [BindProperty] public string PlayerTwoResult { get; set; }

        public AddResultModel(MatchService matchService, ResultService resultService)
        {
            MatchService = matchService;
            ResultService = resultService;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {

        }
    }
}
