using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.Models;
using Logic.Services;
using MaterialSkin.Controls;

namespace DuelSys_inc
{
    public partial class AddResult : MaterialForm
    {
        private readonly MatchService _matchService;
        private readonly ResultService _resultService;
        private readonly UserService _userService;
        private readonly List<Match> _matches;

        public AddResult(MatchService matchService, ResultService resultService, UserService userService)
        {
            InitializeComponent();
            _matchService = matchService;
            _resultService = resultService;
            _userService = userService;
            _matches = _matchService.GetAllMatchesForTournament(1);

            cbxPlayerOne.DisplayMember = "FirstName";
            cbxPlayerOne.ValueMember = "Id";
            cbxPlayerOne.DataSource = _matches
                .Where(m => matchService.HasResult(m.Id) == false)
                .Select(x => _userService.GetUserById(x.FirstPlayerId))
                .DistinctBy(y => y.FirstName)
                .ToList();

            UpdateComboBox();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var playerOne = Convert.ToInt32(cbxPlayerOne.SelectedValue);
            var playerTwo = Convert.ToInt32(cbxPlayerTwo.SelectedValue);
            var playerOneResult = tbxResultPlayerOne.Text;
            var playerTwoResult = tbxResultPlayerTwo.Text;
            foreach (var match in _matches.Where(match => match.FirstPlayerId == playerOne && match.SecondPlayerId == playerTwo))
            {
                _resultService.CreateResult(new Result(match.FirstPlayerId, match.Id, playerOneResult));
                _resultService.CreateResult(new Result(match.SecondPlayerId, match.Id, playerTwoResult));
            }
        }

        private void cbxPlayerOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            var playerOne = Convert.ToInt32(cbxPlayerOne.SelectedValue);
            cbxPlayerTwo.DisplayMember = "FirstName";
            cbxPlayerTwo.ValueMember = "Id";
            cbxPlayerTwo.DataSource = _matches
                .Where(m => _matchService.HasResult(m.Id) == false)
                .Where(x => x.FirstPlayerId == playerOne)
                .Select(y => _userService.GetUserById(y.SecondPlayerId))
                .ToList();
        }
    }
}
