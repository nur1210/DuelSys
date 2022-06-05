using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ChessResult : IRule
    {
        public void Validate(int resultOne, int resultTwo)
        {
            if (resultOne == resultTwo)
            {
                throw new Exception("Match cannot end in a draw");
            }

            if (resultOne > 1 || resultTwo > 1)
            {
                throw new Exception("Match result can be 1 or 0");
            }

            if (resultOne < 0 || resultTwo < 0)
            {
                throw new Exception("Match result cannot be negative");
            }
        }
    }
}
