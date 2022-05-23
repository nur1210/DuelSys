using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using Logic.Views;
using MaterialSkin;
using MaterialSkin.Controls;

namespace DuelSys_inc
{
    public partial class MainForm : MaterialForm
    {
        private readonly TournamentService _tournamentService;
        private readonly SportService _sportService;
        private readonly TournamentSystemService _tournamentSystemService;
        private readonly BindingSource _source = new();
        private readonly MatchService _matchService;
        private readonly ResultService _resultService;
        private readonly UserService _userService;

        public MainForm(TournamentService tournamentService, SportService sportService, TournamentSystemService tournamentSystemService, MatchService matchService, ResultService resultService, UserService userService)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.DeepOrange700, TextShade.WHITE);
            _tournamentService = tournamentService;
            _sportService = sportService;
            _tournamentSystemService = tournamentSystemService;
            _matchService = matchService;
            _resultService = resultService;
            _userService = userService;

            UpdateGridView();
            UpdateListBox();

            cbxSport.ValueMember = "Id";
            cbxSport.DisplayMember = "Name";
            cbxSport.DataSource = _sportService.GetAllSports();

            cbxTournamentSystem.ValueMember = "Id";
            cbxTournamentSystem.DisplayMember = "Name";
            cbxTournamentSystem.DataSource = _tournamentSystemService.GetAllTournamentSystems();

            btnAddResults.Enabled = false;
        }

        private void UpdateGridView()
        {
            dgvTournaments.Rows.Clear();
            _source.DataSource = typeof(TournamentView);
            foreach (var tournament in _tournamentService.GetAllTournamentsForView())
            {
                _source.Add(tournament);
            }
            dgvTournaments.DataSource = _source;
            dgvTournaments.AutoGenerateColumns = true;
            dgvTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTournaments.ForeColor = Color.Black;
        }

        private void UpdateListBox()
        {
            lbxTournaments.DisplayMember = "Description";
            lbxTournaments.ValueMember = "Id";
            lbxTournaments.DataSource = _tournamentService.GetAllTournaments();
        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            var description = tbxDescription.Text;
            var location = tbxLocation.Text;
            var startDate = dtpStartDate.Value;
            var endDate = dtpEndDate.Value;
            var sportId = (int)cbxSport.SelectedValue;
            var sport = _sportService.GetSportById(sportId);
            var tournamentSystemId = (int)cbxTournamentSystem.SelectedValue;
            var tournamentSystem = _tournamentSystemService.GetTournamentSystemById(tournamentSystemId);

            _tournamentService.CreateTournament(new Tournament(description, location, startDate, endDate, sport, tournamentSystem));
        }

        private void lbxTournaments_DoubleClick(object sender, EventArgs e)
        {
            var tournament = (Tournament)lbxTournaments.SelectedItem;
            lblId.Text = tournament.Id.ToString();
            tbxDescription.Text = tournament.Description;
            tbxLocation.Text = tournament.Location;
            dtpStartDate.Value = tournament.StartDate;
            dtpEndDate.Value = tournament.EndDate;
            cbxSport.DisplayMember = "Name";
            cbxSport.SelectedItem = tournament.Sport;
            cbxTournamentSystem.DisplayMember = "Name";
            cbxTournamentSystem.SelectedItem = tournament.System;
            btnEditTournament.Enabled = true;
        }

        private void btnEditTournament_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(lblId.Text);
            var description = tbxDescription.Text;
            var location = tbxLocation.Text;
            var startDate = dtpStartDate.Value;
            var endDate = dtpEndDate.Value;
            var sportId = (int)cbxSport.SelectedValue;
            var sport = _sportService.GetSportById(sportId);
            var tournamentSystemId = (int)cbxTournamentSystem.SelectedValue;
            var tournamentSystem = _tournamentSystemService.GetTournamentSystemById(tournamentSystemId);

            _tournamentService.UpdateTournament(new Tournament(description, location, startDate, endDate, sport, tournamentSystem), id);
        }

        private void dgvTournaments_DoubleClick(object sender, EventArgs e)
        {
            int? i = dgvTournaments.CurrentCell.RowIndex;
            if (i is -1 or null) return;
            var tournamentId = Convert.ToInt32(dgvTournaments.Rows[i.Value].Cells[0].Value);
            if (!_tournamentService.TournamentHasStarted(tournamentId))
            {
                MessageBox.Show(_tournamentService.GenerateTournamentSchedule(tournamentId)
                    ? @"Tournament schedule created successfully!"
                    : @"Unable to create tournament schedule");
            }
            else
            {
                MessageBox.Show(@"This tournament has already started");
            }
        }

        private void btnAddResults_Click(object sender, EventArgs e)
        {
            int? i = dgvTournaments.CurrentCell.RowIndex;
            if (i is -1 or null) return;
            var tournamentId = Convert.ToInt32(dgvTournaments.Rows[i.Value].Cells[0].Value);
            if (!_tournamentService.TournamentHasStarted(tournamentId)) return;
            var tournament = _tournamentService.GetTournamentById(tournamentId);
            AddResult addResult = new(tournament, _matchService, _resultService, _userService);
            addResult.ShowDialog();
        }

        private void dgvTournaments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int? i = dgvTournaments.CurrentCell.RowIndex;
            if (i is -1 or null) return;
            var tournamentId = Convert.ToInt32(dgvTournaments.Rows[i.Value].Cells[0].Value);
            btnAddResults.Enabled = _tournamentService.TournamentHasStarted(tournamentId);
        }
    }
}
