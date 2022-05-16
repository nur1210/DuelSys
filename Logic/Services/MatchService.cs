using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class MatchService
    {
        private readonly IMatchDB _repository;

        public MatchService(IMatchDB repository)
        {
            _repository = repository;
        }

        public void CreateMatch(Match m) => _repository.CreateMatch(m);

        public List<Match> GetAllMatchesForTournament(int tournamentId) =>
            _repository.GetAllMatchesForTournament(tournamentId);

        public bool HasResult(int matchId) => _repository.HasResult(matchId);
    }
}
