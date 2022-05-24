using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IRule
    {
        bool ShouldRun(int resultOne, int resultTwo);
        void RunRule(int resultOne, int resultTwo);
    }
}
