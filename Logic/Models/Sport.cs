using Logic.DTOs;

namespace Logic.Models;

public abstract class Sport
{
    private int _id;
    private string _name;
    private int _minPlayers;
    private int _maxPlayers;
    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public int MinPlayers { get => _minPlayers; set => _minPlayers = value; }
    public int MaxPlayers { get => _maxPlayers; set => _maxPlayers = value; }

    public Sport(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public Sport(SportDTO s)
    {
        _id = s.Id;
        _name = s.Name;
        _minPlayers = s.MinPlayers;
        _maxPlayers = s.MaxPlayers;
    }

    public abstract TournamentLeaderboard GenerateTournamentLeaderBoard();
}

public static class SportFactory
{
    private const string badminton = "badminton";
    private const string football = "football";

    private delegate Sport SportFactoryFn(SportDTO s);

    private static Dictionary<string, SportFactoryFn> _sportTypes = new()
    {
        {
            badminton, sport => new Badminton(sport)
        }
    };
    public static Sport CreateSport(SportDTO sport)
    {
        return _sportTypes[sport.Name](sport);
    }
}