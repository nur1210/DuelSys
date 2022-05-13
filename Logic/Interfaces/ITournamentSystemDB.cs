using Logic.DTOs;
using Logic.Models;

namespace Logic.Interfaces;

public interface ITournamentSystemDB
{
    TournamentSystemDTO GetTournamentSystemById(int systemId);
    List<TournamentSystemDTO> GetAllTournamentSystems();
}