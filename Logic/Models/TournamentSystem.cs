using Logic.Interfaces;

namespace Logic.Models;

public class TournamentSystem : ITournamentSystem
{
    private int _id;
    private string _name;
    private List<Match> _matches;

    public int Id => _id;
    public string Name => _name;
    public List<Match> Matches { get => _matches; set => _matches = value; }


    public TournamentSystem(int id, string name)
    {
        _id = id;
        _name = name;
    }
    public TournamentSystem(TournamentSystem ts)
    {
        _id = ts.Id;
        _name = ts.Name;
    }

    public virtual List<Match> GenerateTournamentSchedule(Tournament tournament, List<User> allPlayersInTheTournament) => new();
}