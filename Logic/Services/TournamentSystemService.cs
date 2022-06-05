using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class TournamentSystemService
    {
        private readonly ITournamentSystemDB _repository;

        public TournamentSystemService(ITournamentSystemDB repository)
        {
            _repository = repository;
        }

        public TournamentSystem GetTournamentSystemById(int systemId) => _repository.GetTournamentSystemById(systemId);
        public List<TournamentSystem> GetAllTournamentSystems() => _repository.GetAllTournamentSystems();
    }
}
