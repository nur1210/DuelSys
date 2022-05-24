using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic
{
    public interface IRule
    {
        bool ShouldRun(List<Result> results);
        void RunRule(List<Result> results);
    }
}
