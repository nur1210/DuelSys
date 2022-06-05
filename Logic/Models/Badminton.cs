
using Logic.Interfaces;

namespace Logic.Models;

public class Badminton : Sport
{
    public Badminton(Sport sport, IRule rule) : base(sport, rule)
    {
        MinPlayers = 4;
        MaxPlayers = 10;
    }

    //public override void ValidateResults(int resultOne, int resultTwo)
    //{
    //    List<int> results = new() { resultOne, resultTwo };
    //    if (results.Find(x => x is >= 21 and <= 30) is 0) return false;
    //    return resultOne is >= 21 and <= 30 && resultOne == resultTwo - 2 || resultOne == resultTwo + 2;
    //}

}