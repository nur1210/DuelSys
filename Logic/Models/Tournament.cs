using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Sport _sport;
        private TournamentSystem _system;
        private List<User> _players;
        private List<Match> _matches;
        private Leaderboard _leaderboard;

        public int Id => _id;
        public string Description => _description;
        public string Location => _location;
        public int MinPlayers => _minPlayers;
        public int MaxPlayers { get => _maxPlayers; set => _maxPlayers = value; }
        public DateTime StartDate => _startDate;
        public DateTime EndDate => _endDate;
        public Sport Sport => _sport;
        public TournamentSystem System => _system;
        public List<User> Players { get => _players; set => _players = value; }
        public List<Match> Matches { get => _matches; set => _matches = value; }
        public Leaderboard Leaderboard { get => _leaderboard; set => _leaderboard = value; }


        public Tournament(string description, string location, DateTime startDate, DateTime endDate, Sport sport,
            TournamentSystem system)
        {
            _description = description;
            _location = location;
            _minPlayers = sport.MinPlayers;
            _maxPlayers = sport.MaxPlayers;
            _startDate = startDate < DateTime.Now.AddDays(7) ? DateTime.Now.AddDays(10) : startDate;
            _endDate = endDate < _startDate ? _endDate.AddDays(1) : endDate;
            _sport = sport;
            _system = system;
        }

        public Tournament(int id, string description, string location, int minPlayers, int maxPlayers,
            DateTime startDate, DateTime endDate, Sport sport, TournamentSystem system)
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
