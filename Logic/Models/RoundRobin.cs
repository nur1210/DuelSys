using Logic.Interfaces;

namespace Logic.Models;
public class RoundRobin : TournamentSystem
{
    public RoundRobin(TournamentSystem tournamentSystem) : base(tournamentSystem)
    {
    }

    public override List<Match> GenerateTournamentSchedule(Tournament tournament, List<User> allPlayersInTheTournament)
    {
        if (!tournament.System.Name.Equals("Round Robin") || allPlayersInTheTournament.Count <= 0)
        {
            throw new ArgumentException("Invalid call");
        }
        var tournamentLength = tournament.EndDate.DayOfYear - tournament.StartDate.DayOfYear;
        var numberOfMatches = allPlayersInTheTournament.Count * (allPlayersInTheTournament.Count - 1) / 2;
        var matchRate = 0.0;
        Matches = new List<Match>();
        var match = 0;
        for (var i = 0; i < allPlayersInTheTournament.Count; i++)
        {
            for (var j = 1 + i; j < allPlayersInTheTournament.Count; j++)
            {
                Matches.Add(new Match(match, tournament.StartDate.AddDays(matchRate), tournament.Id,
                    allPlayersInTheTournament[i].Id, allPlayersInTheTournament[j].Id));

                matchRate += (double)tournamentLength / numberOfMatches;
                match++;
            }
        }
        return Matches;
    }

}