using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class UserRank
    {
        private int _userId;
        private int _wins;
        private int _sumResults;

        public int UserId => _userId;
        public int Wins => _wins;
        public int SumResults => _sumResults;

        public UserRank(int userId, List<Match> matches)
        {
            _userId = userId;
            _wins = matches.Count(x => x.WinnerId == _userId);
            _sumResults = matches.Sum(x => x.MatchResults.Sum(y => y.MatchResult));
        }
    }
}
