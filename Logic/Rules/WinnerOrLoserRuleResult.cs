using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Exceptions;

namespace Logic.Rules
{
    public class WinnerOrLoserRuleResult : IRule
    {
        public void Validate(int resultOne, int resultTwo)
        {
            if (resultOne == resultTwo)
            {
                throw new MatchResultException("Match cannot end in a draw");
            }

            if (resultOne > 1 || resultTwo > 1)
            {
                throw new MatchResultException("Match result can be 1 or 0");
            }

            if (resultOne < 0 || resultTwo < 0)
            {
                throw new MatchResultException("Match result cannot be negative");
            }
        }
    }
}
