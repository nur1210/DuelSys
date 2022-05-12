using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Models;

namespace Logic.Views
{
    public class TournamentView
    {
        private int _id;
        private string _description;
        private string _location;
        private int _registeredPlayers;
        private int _minPlayers;
        private int _maxPlayers;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _sportName;
        private string _systemName;

        public int Id { get => _id; set => _id = value; }
        public string Description { get => _description; set => _description = value; }
        public string Location { get => _location; set => _location = value; }
        public int RegisteredPlayers { get => _registeredPlayers; set => _registeredPlayers = value; }
        public int MinPlayers { get => _minPlayers; set => _minPlayers = value; }
        public int MaxPlayers { get => _maxPlayers; set => _maxPlayers = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public string SportName { get => _sportName; set => _sportName = value; }
        public string SystemName { get => _systemName; set => _systemName = value; }

        public TournamentView(int id, string description, string location, int registeredPlayers, int minPlayers, int maxPlayers, DateTime startDate, DateTime endDate, string sportName, string systemName)
        {
            _id = id;
            _description = description;
            _location = location;
            _registeredPlayers = registeredPlayers;
            _minPlayers = minPlayers;
            _maxPlayers = maxPlayers;
            _startDate = startDate;
            _endDate = endDate;
            _sportName = sportName;
            _systemName = systemName;
        }
    }
}
