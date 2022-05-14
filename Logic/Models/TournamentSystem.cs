using Logic.Interfaces;

namespace Logic.Models;

public class TournamentSystem : ITournamentSystem
{
    private int _id;
    private string _name;
    private List<Match> _matches;

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
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

    public virtual List<Match> GenerateTournamentSchedule(int tournamentId, List<User> allPlayersInTheTournament) => new();
}