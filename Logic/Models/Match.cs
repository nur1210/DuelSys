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

        public int Id => _id;
        public DateTime Date => _date;
        public int TournamentId => _tournamentId;
        public int FirstPlayerId => _firstPlayerId;
        public int SecondPlayerId => _secondPlayerId;
        public List<Result> MatchResults => _matchResults;
        public int WinnerId => _winnerId;
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
