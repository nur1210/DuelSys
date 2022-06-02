using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Leaderboard
    {
        private int _tournamentId;
        private List<UserRank> _usersRanks;
        private Dictionary<int, UserRank> _leaderboard;

        public int TournamentId { get => _tournamentId; set => _tournamentId = value; }
        public Dictionary<int, UserRank> RankedLeaderboard { get => _leaderboard; private set => _leaderboard = value; }

        public Leaderboard(int tournamentId, List<UserRank> users)
        {
            _tournamentId = tournamentId;
            _usersRanks = users
                .OrderByDescending(x => x.Wins)
                .ThenByDescending(x => x.SumResults)
                .ToList();

            Dictionary<int, UserRank> dictionary = new();
            for (var i = 1; i <= _usersRanks.Count; i++)
            {
                dictionary.Add(i, _usersRanks[i - 1]);
            }
            _leaderboard = dictionary;
        }
    }
}
