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
        void Validate(int resultOne, int resultTwo);
    }
}
