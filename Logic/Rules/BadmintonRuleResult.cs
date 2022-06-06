using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Rules
{
    public class BadmintonRuleResult : IRule
    {
        public void Validate(int resultOne, int resultTwo)
        {
            if (resultOne < 21 && resultTwo < 21)
                throw new Exception("The winner's score must be at least 21");

            if (resultOne < 0 || resultTwo < 0)
                throw new Exception("THe result must be a positive number");

            if (resultOne > 30 || resultTwo > 30)
                throw new Exception("Maximum score cannot exceed 30");

            if (resultOne == resultTwo)
                throw new Exception("Match cannot end in a draw");

            if (resultOne < 20 || resultTwo < 20)
                return;

            if (resultOne == 30 || resultTwo == 30)
                return;

            var abs = Math.Abs(resultOne - resultTwo);
            if (abs != 2)
                throw new Exception("Match difference should be at least of 2 points");
        }
    }
}
