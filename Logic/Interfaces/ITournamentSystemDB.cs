using Logic.DTOs;

namespace Logic.Interfaces;

public interface ITournamentSystemDB
{
    TournamentSystemDTO GetTournamentSystemById(int systemId);
    List<TournamentSystemDTO> GetAllTournamentSystems();
}