using Logic.Models;
using Logic.Views;

namespace Logic.Interfaces;

public interface ITournamentDB
{
    void CreateTournament(Tournament t);
    void UpdateTournament(Tournament t, int tournamentId);
    void DeleteTournament(int tournamentId);
    List<Tournament> GetAllTournaments();
    List<TournamentView> GetAllTournamentsForView();
    List<User> GetAllUsersRegisteredToTournamentByTournamentId(int tournamentId);
    List<int> GetAllStartedTournamentsIds();
    Tournament GetTournamentLeaderboard(int tournamentId);

}