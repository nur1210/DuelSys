using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class ResultService
    {
        private readonly IResultDB _repository;

        public ResultService(IResultDB repository)
        {
            _repository = repository;
        }

        public void CreateResult(Result r) => _repository.CreateResult(r);

        public List<Result> GetAllResultsForTournament(int tournamentId) =>
            _repository.GetAllResultsForTournament(tournamentId);

        public List<Result> GetAllResultsPerMatchById(int matchId, int userId) => _repository.GetAllResultsPerMatchById(matchId, userId);
    }
}
