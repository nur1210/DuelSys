using Logic.DTOs;
using Logic.Models;

namespace Logic.Interfaces;

public interface ITournamentSystemDB
{
    TournamentSystem GetTournamentSystemById(int systemId);
    List<TournamentSystem> GetAllTournamentSystems();
}