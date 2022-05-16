using Logic.Models;

namespace Logic.Services;

public static class SportFactory
{
    private const string badminton = "Badminton";
    private const string tennis = "Tennis";

    private delegate Sport SportFactoryFn(Sport s);

    private static Dictionary<string, SportFactoryFn> _sportTypes = new()
    {
        {
            badminton,
            sport => new Badminton(sport)
        },
        {
            tennis,
            sport => new Tennis(sport)
        }
    };
    public static Sport CreateSport(Sport sport)
    {
        return _sportTypes[sport.Name](sport);
    }
}

