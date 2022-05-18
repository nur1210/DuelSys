using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Match
    {
        private int _id;
        private DateTime _date;
        private int _tournamentId;
        private int _firstPlayerId;
        private int _secondPlayerId;

        public int Id { get => _id; set => _id = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public int TournamentId { get => _tournamentId; set => _tournamentId = value; }
        public int FirstPlayerId { get => _firstPlayerId; set => _firstPlayerId = value; }
        public int SecondPlayerId { get => _secondPlayerId; set => _secondPlayerId = value; }

        public Match(int tournamentId, int firstPlayerId, int secondPlayerId)
        {
            _tournamentId = tournamentId;
            _firstPlayerId = firstPlayerId;
            _secondPlayerId = secondPlayerId;
        }

        public Match(int id, DateTime date, int tournamentId, int firstPlayerId, int secondPlayerId)
        {
            _id = id;
            _date = date;
            _tournamentId = tournamentId;
            _firstPlayerId = firstPlayerId;
            _secondPlayerId = secondPlayerId;
        }
    }
}
