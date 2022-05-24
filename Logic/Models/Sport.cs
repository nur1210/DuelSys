
using Logic.Interfaces;

namespace Logic.Models;

public class Sport
{
    private int _id;
    private string _name;
    private int _minPlayers;
    private int _maxPlayers;
    private List<IRule> _rules = new() {new BadmintonResult()};
    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public int MinPlayers { get => _minPlayers; set => _minPlayers = value; }
    public int MaxPlayers { get => _maxPlayers; set => _maxPlayers = value; }
    public List<IRule> Rules { get => _rules; set => _rules = value; }

    public Sport(int id, string name, int minPlayers, int maxPlayers)
    {
        _id = id;
        _name = name;
        _minPlayers = minPlayers;
        _maxPlayers = maxPlayers;
    }

    public Sport(Sport s)
    {
        _id = s.Id;
        _name = s.Name;
        _minPlayers = s.MinPlayers;
        _maxPlayers = s.MaxPlayers;
    }

    public virtual bool ValidateResults(List<Result> results)
    {
        foreach (var rule in _rules.Where(rule => rule.ShouldRun(results)))
        {
            rule.RunRule(results);
            return true;
        }

        return false;
    }
}