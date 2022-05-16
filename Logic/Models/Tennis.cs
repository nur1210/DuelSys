using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
	public class Tennis: Sport
	{
        public Tennis(Sport sport): base(sport)
        {
            MinPlayers = 4;
            MaxPlayers = 12;
        }

        public override TournamentLeaderboard GenerateTournamentLeaderBoard()
        {
            return new TournamentLeaderboard();
        }
    }
}
