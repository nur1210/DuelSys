using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Exceptions
{
    public class MatchResultException : Exception
    {
        public MatchResultException()
        {
        }

        public MatchResultException(string message) : base(message)
        {
        }
    }
}
