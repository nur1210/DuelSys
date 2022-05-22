using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic
{
    public interface IRuleResult
    {
        public bool ValidateResults(int resultOne, int resultTwo);
        //bool IsApplicable(List<Result> results, Sport sport);

        //void runRule(List<Result> results, Sport sport);
    }
}
