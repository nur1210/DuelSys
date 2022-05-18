using Logic.Models;

namespace Logic.Interfaces;

public interface IResultDB
{
    void CreateResult(Result r);
    List<Result> GetAllResultsForTournament(int tournamentId);
    List<Result> GetAllResultsPerMatchById(int matchId, int userId);
}