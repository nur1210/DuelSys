
namespace Logic.Models;

public class Badminton : Sport, IRuleResult
{
    public Badminton(Sport sport) : base(sport)
    {
        MinPlayers = 4;
        MaxPlayers = 10;
    }

    public bool ValidateResults(int resultOne, int resultTwo)
    {
        List<int> results = new() {resultOne, resultTwo};
        if (results.Find(x => x is >= 21 and <= 30) is 0) return false;
        return resultOne is >= 21 and <= 30 && resultOne == resultTwo - 2 || resultOne == resultTwo + 2;
    }
}