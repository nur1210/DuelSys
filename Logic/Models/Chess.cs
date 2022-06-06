using Logic.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Chess : Sport
    {
        public Chess(Sport s, IRule rule) : base(s, rule)
        {
            MinPlayers = 4;
            MaxPlayers = 10;
        }
    }
}
