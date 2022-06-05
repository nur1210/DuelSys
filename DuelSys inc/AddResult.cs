using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using MaterialSkin;
using MaterialSkin.Controls;

namespace DuelSys_inc
{
    public partial class AddResult : MaterialForm
    {
        private readonly Tournament _tournament;
        private readonly MatchService _matchService;
        private readonly ResultService _resultService;
        private readonly UserService _userService;
        private readonly List<Match> _matches;

        public AddResult(Tournament tournament, MatchService matchService, ResultService resultService, UserService userService)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.DeepOrange700, TextShade.WHITE);
            _tournament = tournament;
            _matchService = matchService;
            _resultService = resultService;
            _userService = userService;
            _matches = _matchService.GetAllMatchesForTournament(_tournament.Id);

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
            var playerOneResult = Convert.ToInt32(tbxResultPlayerOne.Text);
            var playerTwoResult = Convert.ToInt32(tbxResultPlayerTwo.Text);

            try
            {
                _tournament.Sport.ValidateResults(playerOneResult, playerTwoResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbxResultPlayerOne.Clear();
                tbxResultPlayerTwo.Clear();
                return;
            }

            var match = _matches.First(match => match.FirstPlayerId == playerOne && match.SecondPlayerId == playerTwo);

            _resultService.CreateResult(new Result(match.FirstPlayerId, match.Id, playerOneResult));
            _resultService.CreateResult(new Result(match.SecondPlayerId, match.Id, playerTwoResult));

            MessageBox.Show(@"The results registered successfully");
            tbxResultPlayerOne.Clear();
            tbxResultPlayerTwo.Clear();


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
