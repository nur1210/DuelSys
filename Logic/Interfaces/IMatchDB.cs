using Logic.Models;

namespace Logic.Interfaces;

public interface IMatchDB
{
    void CreateMatch(Match m);
    List<Match> GetAllMatchesForTournament(int tournamentId);
    bool HasResult(int matchId);
}