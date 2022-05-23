using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic.Interfaces
{
    public interface IRuleResult
    {
        public bool ValidateResults(int resultOne, int resultTwo);
    }
}
