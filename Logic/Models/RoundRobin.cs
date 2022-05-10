namespace Logic.Models;

public class RoundRobin : TournamentSystem
{
    protected override List<Match> GenerateTournamentSchedule(int tournamentId)
    {
        var players = new List<User>(); //Get all users for tournament
        var matches = new List<Match>();
        var match = 0;
        for (var i = 0; i < players.Count; i++)
        {
            for (var j = 1 + i; j < players.Count; j++)
            {
                matches.Add(new Match(match, tournamentId, players[i].Id, players[j].Id));
                match++;
            }
        }
        return matches;
    }
}