
using Logic.Interfaces;

namespace Logic.Models;

public class Sport
{
    private int _id;
    private string _name;
    private int _minPlayers;
    private int _maxPlayers;
    private List<IRule> _rules;
    public int Id => _id;
    public string Name => _name;
    public int MinPlayers { get => _minPlayers;
        protected init => _minPlayers = value; }
    public int MaxPlayers { get => _maxPlayers;
        protected init => _maxPlayers = value; }
    public List<IRule> Rules { get => _rules; set => _rules = value; }

    public Sport(int id, string name, int minPlayers, int maxPlayers)
    {
        _id = id;
        _name = name;
        _minPlayers = minPlayers;
        _maxPlayers = maxPlayers;
    }

    public Sport(Sport s, List<IRule> rules)
    {
        _id = s.Id;
        _name = s.Name;
        _minPlayers = s.MinPlayers;
        _maxPlayers = s.MaxPlayers;
        _rules = rules;
    }

    public virtual bool ValidateResults(int resultOne, int resultTwo)
    {
        throw new NotImplementedException();
    }

}