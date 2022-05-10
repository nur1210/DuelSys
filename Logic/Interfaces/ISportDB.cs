using Logic.DTOs;

namespace Logic.Interfaces;

public interface ISportDB
{
    SportDTO GetSportById(int sportId);
    List<SportDTO> GetAllSports();
}