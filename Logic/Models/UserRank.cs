using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class UserRank
    {
        //private int _tournamentId;
        private int _userId;
        private int _wins;
        private int _sumResults;

        //public int TournamentId { get => _tournamentId; set => _tournamentId = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public int Wins { get => _wins; set => _wins = value; }
        public int SumResults { get => _sumResults; set => _sumResults = value; }

        public UserRank(int userId, List<Match> matches)
        {
            //_tournamentId = tournamentId;
            _userId = userId;
            _wins = matches.Count(x => x.WinnerId == _userId);
            _sumResults = matches.Sum(x => x.MatchResults.Sum(y => y.MatchResult));
        }
    }
}
