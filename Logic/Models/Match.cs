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
        private List<Result> _matchResults;
        private int _winnerId;
        private int _loserId;

        public int Id { get => _id; set => _id = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public int TournamentId { get => _tournamentId; set => _tournamentId = value; }
        public int FirstPlayerId { get => _firstPlayerId; set => _firstPlayerId = value; }
        public int SecondPlayerId { get => _secondPlayerId; set => _secondPlayerId = value; }
        public List<Result> MatchResults { get => _matchResults; set => _matchResults = value; }
        public int WinnerId { get => _winnerId; set => _winnerId = value; }
        public int LoserId { get => _loserId; set => _loserId = value; }

        public Match(int id, DateTime date, int tournamentId, int firstPlayerId, int secondPlayerId)
        {
            _id = id;
            _date = date;
            _tournamentId = tournamentId;
            _firstPlayerId = firstPlayerId;
            _secondPlayerId = secondPlayerId;
        }

        public Match(int id, DateTime date, int tournamentId, int firstPlayerId, int secondPlayerId, List<Result> matchResults)
        {
            _id = id;
            _date = date;
            _tournamentId = tournamentId;
            _firstPlayerId = firstPlayerId;
            _secondPlayerId = secondPlayerId;
            _matchResults = matchResults;
            _winnerId = _matchResults
                .OrderByDescending(y => y.MatchResult)
                .Select(x => x.UserId)
                .First();
            _loserId = _winnerId == _firstPlayerId ? _secondPlayerId : _firstPlayerId;
        }
    }
}
