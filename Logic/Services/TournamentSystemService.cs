using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class TournamentSystemService: TournamentSystem
    {
        private readonly ITournamentSystemDB _repository;
        private readonly ITournamentSystem _tournamentSystem;

        public TournamentSystemService(ITournamentSystemDB repository, TournamentSystem tournamentSystem)
        {
            _repository = repository;
            _tournamentSystem = tournamentSystem;
        }

        public TournamentSystemDTO GetTournamentSystemById(int systemId) => _repository.GetTournamentSystemById(systemId);
        public List<TournamentSystemDTO> GetAllTournamentSystems() => _repository.GetAllTournamentSystems();

        public override List<Match>
            GenerateTournamentSchedule(int tournamentId, List<User> allPlayersInTheTournament) =>
            _tournamentSystem.GenerateTournamentSchedule(tournamentId, allPlayersInTheTournament);
    }
}
