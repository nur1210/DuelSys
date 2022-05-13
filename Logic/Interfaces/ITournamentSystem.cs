using Logic.Models;

namespace Logic.Interfaces;

public interface ITournamentSystem
{
    List<Match> GenerateTournamentSchedule(int tournamentId, List<User> allPlayersInTheTournament);
}