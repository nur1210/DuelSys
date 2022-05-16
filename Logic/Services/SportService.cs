using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using SportDTO = Logic.DTOs.SportDTO;

namespace Logic.Services
{
    public class SportService
    {
        private readonly ISportDB _repository;

        public SportService(ISportDB repository)
        {
            _repository = repository;
        }

        public Sport GetSportById(int sportId) => _repository.GetSportById(sportId);
        public List<Sport> GetAllSports() => _repository.GetAllSports();

    }
}
