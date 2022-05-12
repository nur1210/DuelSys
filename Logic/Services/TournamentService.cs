using System;
using System.Collections.Generic;
using System.Linq;
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

        public TournamentService(ITournamentDB repository)
        {
            _repository = repository;
        }

        public void CreateTournament(Tournament t) => _repository.CreateTournament(t);
        public void UpdateTournament(Tournament t, int tournamentId) => _repository.UpdateTournament(t, tournamentId);
        public void DeleteTournament(int tournamentId) => _repository.DeleteTournament(tournamentId);
        public List<Tournament> GetAllTournaments() => _repository.GetAllTournaments();
        public List<TournamentView> GetAllTournamentsForView() => _repository.GetAllTournamentsForView();

        public double GetTournamentOccupancyPercentage(int tournamentId) => GetAllTournamentsForView()
            .Where(x => x.Id == tournamentId)
            .Select(y => (y.RegisteredPlayers * 100) / y.MaxPlayers)
            .First();

    }
}
