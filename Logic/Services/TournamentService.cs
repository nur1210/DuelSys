using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;
using Logic.Views;

namespace Logic.Services
{
    public class TournamentService
    {
        private readonly ITournamentDB _repository;
        private readonly MatchService _matchService;

        public TournamentService(ITournamentDB repository, MatchService matchService)
        {
            _repository = repository;
            _matchService = matchService;
        }

        public void CreateTournament(Tournament t) => _repository.CreateTournament(t);
        public void UpdateTournament(Tournament t, int tournamentId) => _repository.UpdateTournament(t, tournamentId);
        public void DeleteTournament(int tournamentId) => _repository.DeleteTournament(tournamentId);
        public List<Tournament> GetAllTournaments() => _repository.GetAllTournaments();

        public Tournament GetTournamentById(int tournamentId) =>
            GetAllTournaments().First(t => t.Id == tournamentId);
        public List<TournamentView> GetAllTournamentsForView() => _repository.GetAllTournamentsForView();

        public double GetTournamentOccupancyPercentage(int tournamentId) => GetAllTournamentsForView()
            .Where(x => x.Id == tournamentId)
            .Select(y => (y.RegisteredPlayers * 100) / y.MaxPlayers)
            .First();

        public List<User> GetAllUsersRegisteredToTournamentByTournamentId(int tournamentId) =>
            _repository.GetAllUsersRegisteredToTournamentByTournamentId(tournamentId);

        public bool GenerateTournamentSchedule(int tournamentId)
        {
            var tournament = GetTournamentById(tournamentId);
            var players = GetAllUsersRegisteredToTournamentByTournamentId(tournamentId);
            if (tournament.MinPlayers > players.Count) return false;
            var matches = tournament.System.GenerateTournamentSchedule(tournamentId, players);
            foreach (var match in matches)
            {
                _matchService.CreateMatch(match);
            }
            return true;
        }
    }
}
