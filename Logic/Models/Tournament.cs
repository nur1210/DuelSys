using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Services;

namespace Logic.Models
{
    public class Tournament
    {
        private int _id;
        private string _description;
        private string _location;
        private int _minPlayers;
        private int _maxPlayers;
        private DateTime _startDate;
        private DateTime _endDate;
        private SportDTO _sport;
        private TournamentSystemDTO _system;
        private List<Match> _matches;

        public int Id { get => _id; set => _id = value; }
        public string Description { get => _description; set => _description = value; }
        public string Location { get => _location; set => _location = value; }
        public int MinPlayers { get => _minPlayers; set => _minPlayers = value; }
        public int MaxPlayers { get => _maxPlayers; set => _maxPlayers = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public SportDTO Sport { get => _sport; set => _sport = value; }
        public TournamentSystemDTO System { get => _system; set => _system = value; }
        public List<Match> Matches { get => _matches; set => _matches = value; }


        public Tournament(string description, string location, DateTime startDate, DateTime endDate, SportDTO sport, TournamentSystemDTO system)
        {
            _description = description;
            _location = location;
            _minPlayers = sport.MinPlayers;
            _maxPlayers = sport.MaxPlayers;
            _startDate = startDate < DateTime.Now.AddDays(7) ? DateTime.Now.AddDays(10) : startDate;
            _endDate = endDate < _startDate ? _endDate.AddHours(1) : endDate;
            _sport = sport;
            _system = system;
        }

        public Tournament(int id, string description, string location, int minPlayers, int maxPlayers, DateTime startDate, DateTime endDate, SportDTO sport, TournamentSystemDTO system)
        {
            _id = id;
            _description = description;
            _location = location;
            _minPlayers = minPlayers;
            _maxPlayers = maxPlayers;
            _startDate = startDate;
            _endDate = endDate;
            _sport = sport;
            _system = system;
        }
    }
}
