
using Logic.Interfaces;
using Logic.Rules;

namespace Logic.Models;

public class Badminton : Sport
{
    public Badminton(Sport sport, IRule rule) : base(sport, rule)
    {
        MinPlayers = 4;
        MaxPlayers = 10;
    }

}