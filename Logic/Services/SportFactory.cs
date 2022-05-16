using Logic.DTOs;
using Logic.Models;

namespace Logic.Services;

public static class SportFactory
{
    private const string badminton = "badminton";
    private const string football = "football";

    private delegate Sport SportFactoryFn(Sport s);

    private static Dictionary<string, SportFactoryFn> _sportTypes = new()
    {
        {
            badminton, sport => new Badminton(sport)
        }
    };
    public static Sport CreateSport(Sport sport)
    {
        return _sportTypes[sport.Name](sport);
    }
}