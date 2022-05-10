using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Interfaces;

namespace Logic.Services
{
    public class TournamentSystemService
    {
        private readonly ITournamentSystemDB _repository;

        public TournamentSystemService(ITournamentSystemDB repository)
        {
            _repository = repository;
        }

        public TournamentSystemDTO GetTournamentSystemById(int systemId) => _repository.GetTournamentSystemById(systemId);
        public List<TournamentSystemDTO> GetAllTournamentSystems() => _repository.GetAllTournamentSystems();
    }
}
