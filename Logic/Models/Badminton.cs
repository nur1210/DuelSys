
using Logic.Interfaces;

namespace Logic.Models;

public class Badminton : Sport
{
    public Badminton(Sport sport) : base(sport)
    {
        MinPlayers = 4;
        MaxPlayers = 10;
    }

    public override bool ValidateResults(List<Result> results)
    {
        foreach (var rule in Rules.Where(rule => rule.ShouldRun(results)))
        {
            rule.RunRule(results);
            return true;
        }

        return false;
    }
}