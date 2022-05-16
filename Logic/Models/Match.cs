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
        private int _tournamentId;
        private int _firstPlayerId;
        private int _secondPlayerId;

        public int Id { get => _id; set => _id = value; }
        public int TournamentId { get => _tournamentId; set => _tournamentId = value; }
        public int FirstPlayerId { get => _firstPlayerId; set => _firstPlayerId = value; }
        public int SecondPlayerId { get => _secondPlayerId; set => _secondPlayerId = value; }

        public Match(int tournamentId, int firstPlayerId, int secondPlayerId)
        {
            _tournamentId = tournamentId;
            _firstPlayerId = firstPlayerId;
            _secondPlayerId = secondPlayerId;
        }

        public Match(int id, int tournamentId, int firstPlayerId, int secondPlayerId)
        {
            _id = id;
            _tournamentId = tournamentId;
            _firstPlayerId = firstPlayerId;
            _secondPlayerId = secondPlayerId;
        }
    }
}
