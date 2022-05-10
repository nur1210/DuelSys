namespace Logic.Models;

public abstract class TournamentSystem
{
    private int _id;
    private string _name;
    private List<Match> _matches;

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public List<Match> Matches { get => _matches; set => _matches = value; }


    protected abstract List<Match> GenerateTournamentSchedule(int tournamentId);
}