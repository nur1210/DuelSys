using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
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

        public List<TournamentView> GetAllTournamentsForView(string? sportName) =>
            _repository.GetAllTournamentsForView()
                .Where(x => x.SportName == sportName)
                .ToList();

        public List<TournamentView> GetAllFilteredTournaments(int? filter, List<TournamentView>? tournamentsList) => filter switch
        {
            1 => tournamentsList
                .Where(x => TournamentHasStarted(x.Id) == false && x.StartDate > DateTime.Now.AddDays(7))
                .ToList(),
            2 => tournamentsList
                .Where(x => TournamentHasStarted(x.Id) && x.EndDate > DateTime.Now)
                .ToList(),
            3 => tournamentsList
                .Where(x => TournamentHasStarted(x.Id) && x.EndDate < DateTime.Now)
                .ToList(),
            4 => tournamentsList
                .Where(x => TournamentHasStarted(x.Id) == false && x.StartDate < DateTime.Now.AddDays(7))
                .ToList(),
            _ => GetAllTournamentsForView(tournamentsList.Select(x => x.SportName).FirstOrDefault())
        };
        public double GetTournamentOccupancyPercentage(int tournamentId) => _repository.GetAllTournamentsForView()
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
            var matches = tournament.System.GenerateTournamentSchedule(tournament, players);
            foreach (var match in matches)
            {
                _matchService.CreateMatch(match);
            }
            return true;
        }

        public bool TournamentHasStarted(int tournamentId) =>
            _repository.GetAllStartedTournamentsIds().Contains(tournamentId);

        //public Dictionary<User, int> GetTournamentLeaderboard(int tournamentId)
        //{
        //    Dictionary<User, int> leaderboard = new();
        //    var users = GetAllUsersRegisteredToTournamentByTournamentId(tournamentId);
        //    var tournamentLeaderboard = _repository.GetTournamentLeaderboard(tournamentId);
        //    foreach (var user in users)
        //    {
        //        var wins = tournamentLeaderboard.Matches
        //            .Count(match => user.Id == match.WinnerId);
        //        leaderboard.Add(user, wins);
        //    }

        //    return leaderboard;
        //}

        public Leaderboard GetTournamentLeaderboard(int tournamentId) =>
            _repository.GetTournamentLeaderboard(tournamentId);
    }
}
