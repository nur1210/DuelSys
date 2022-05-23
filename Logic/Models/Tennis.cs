using Logic.Interfaces;
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

        public override bool ValidateResults(int resultOne, int resultTwo)
        {
            throw new NotImplementedException();
        }
    }
}
