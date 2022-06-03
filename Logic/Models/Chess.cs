using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Chess : Sport
    {
        public Chess(Sport s, List<IRule> rules) : base(s, rules)
        {
            MinPlayers = 4;
            MaxPlayers = 10;
        }

        public override bool ValidateResults(int resultOne, int resultTwo)
        {
            throw new NotImplementedException();
        }
    }
}
