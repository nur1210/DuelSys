using Logic.Interfaces;

namespace Logic.Models;

public class RoundRobin : TournamentSystem, ITournamentSystem
{
    public RoundRobin(int id, string name) : base(id, name)
    {
    }

    public override List<Match> GenerateTournamentSchedule(int tournamentId, List<User> allPlayersInTheTournament)
    {
        var matches = new List<Match>();
        var match = 0;
        for (var i = 0; i < allPlayersInTheTournament.Count; i++)
        {
            for (var j = 1 + i; j < allPlayersInTheTournament.Count; j++)
            {
                matches.Add(new Match(match, tournamentId, allPlayersInTheTournament[i].Id, allPlayersInTheTournament[j].Id));
                match++;
            }
        }
        return matches;
    }

}