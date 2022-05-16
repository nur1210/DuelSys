using Logic.Models;

namespace Logic.Interfaces;

public interface ISportDB
{
    Sport GetSportById(int sportId);
    List<Sport> GetAllSports();
}