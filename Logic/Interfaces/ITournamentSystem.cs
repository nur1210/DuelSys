using Logic.Models;

namespace Logic.Interfaces;

public interface ITournamentSystem
{
    List<Match> GenerateTournamentSchedule(Tournament tournament, List<User> allPlayersInTheTournament);
}