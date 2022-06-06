using Logic.Interfaces;
using Logic.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Tennis: Sport
	{
        public Tennis(Sport sport, IRule rule): base(sport, rule)
        {
            MinPlayers = 4;
            MaxPlayers = 12;
        }
    }
}
