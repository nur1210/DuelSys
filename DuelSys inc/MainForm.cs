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
        //private readonly TournamentSystem _tournamentSystem;
        private readonly BindingSource _source = new();

        public MainForm(TournamentService tournamentService, SportService sportService, TournamentSystemService tournamentSystemService)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.DeepOrange700, TextShade.WHITE);
            _tournamentService = tournamentService;
            _sportService = sportService;
            _tournamentSystemService = tournamentSystemService;

            UpdateGridView();
            UpdateListBox();

            cbxSport.ValueMember = "Id";
            cbxSport.DisplayMember = "Name";
            cbxSport.DataSource = _sportService.GetAllSports();

            cbxTournamentSystem.ValueMember = "Id";
            cbxTournamentSystem.DisplayMember = "Name";
            cbxTournamentSystem.DataSource = _tournamentSystemService.GetAllTournamentSystems();
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
            cbxSport.SelectedItem = tournament.Sport;
            cbxSport.DisplayMember = "Name";
            cbxTournamentSystem.SelectedItem = tournament.System;
            cbxTournamentSystem.DisplayMember = "Name";
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
            if (_tournamentService.GenerateTournamentSchedule(tournamentId))
            {
                MessageBox.Show(@"Tournament schedule created successfully!");
            }
            MessageBox.Show(@"Unable to create tournament schedule");
        }
    }
}
