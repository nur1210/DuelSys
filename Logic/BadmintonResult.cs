using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Logic
{
    public class BadmintonResult : IRule
    {
        private readonly IResultDB _repository;

        public bool ShouldRun(List<Result> results)
        {
            var range = Enumerable.Range(21, 9);
            if (results.Find(x => range.Contains(x.MatchResult)) is null) return false;
            var resultOne = results[0].MatchResult;
            var resultTwo = results[1].MatchResult;
            return resultOne is >= 21 and <= 30 && resultOne == resultTwo - 2 || resultOne == resultTwo + 2;
        }

        public void RunRule(List<Result> results)
        {
            foreach (var result in results)
            {
                _repository.CreateResult(result);
            }
        }
    }
}
