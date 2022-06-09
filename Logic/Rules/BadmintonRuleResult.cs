using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Exceptions;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Rules
{
    public class BadmintonRuleResult : IRule
    {
        public void Validate(int resultOne, int resultTwo)
        {
            if (resultOne < 21 && resultTwo < 21)
                throw new MatchResultException("The winner's score must be at least 21");

            if (resultOne < 0 || resultTwo < 0)
                throw new MatchResultException("THe result must be a positive number");

            if (resultOne > 30 || resultTwo > 30)
                throw new MatchResultException("Maximum score cannot exceed 30");

            if (resultOne == resultTwo)
                throw new MatchResultException("Match cannot end in a draw");

            if (resultOne < 20 || resultTwo < 20)
                return;

            var abs = Math.Abs(resultOne - resultTwo);
            if (abs != 2 && resultOne != 30 && resultTwo != 30)
                throw new MatchResultException("Game difference should be at least of 2 points");
        }
    }
}
