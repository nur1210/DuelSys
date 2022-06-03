using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic.Services
{
    public static class Calculator
    {
        public static double WinRatio(List<Result> matchResults, int userId)
        {
            var result = Convert.ToDouble(matchResults.Where(x => x.UserId == userId).Select(y => y.MatchResult).First());
            var secondResult = matchResults.Where(x => x.UserId != userId).Select(y => y.MatchResult).First();
            var sum = result + secondResult;
            var ratio = result / sum * 100;
            return ratio;
        }
    }
}
