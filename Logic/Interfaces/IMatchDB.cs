using Logic.Models;

namespace Logic.Interfaces;

public interface IMatchDB
{
    void CreateMatch(Match m);
    List<Match> GetAllMatchesForTournament(int tournamentId);
    bool HasResult(int matchId);
    Match GetMatchByUsersIds(int firstUserId, int secondUserId);
    Dictionary<int, List<Match>> GetAllMatchesPerPlayer(int tournamentId);
}