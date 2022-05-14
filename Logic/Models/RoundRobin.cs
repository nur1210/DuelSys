using Logic.Interfaces;

namespace Logic.Models;

public class RoundRobin : TournamentSystem, ITournamentSystem
{
    public RoundRobin(TournamentSystem tournamentSystem) : base(tournamentSystem)
    {
    }

    public override List<Match> GenerateTournamentSchedule(int tournamentId, List<User> allPlayersInTheTournament)
    {
        Matches = new List<Match>();
        var match = 0;
        for (var i = 0; i < allPlayersInTheTournament.Count; i++)
        {
            for (var j = 1 + i; j < allPlayersInTheTournament.Count; j++)
            {
                Matches.Add(new Match(match, tournamentId, allPlayersInTheTournament[i].Id, allPlayersInTheTournament[j].Id));
                match++;
            }
        }
        return Matches;
    }

}