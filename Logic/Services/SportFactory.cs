using System.Formats.Asn1;
using System.Xml;
using Logic.Models;

namespace Logic.Services;

public static class SportFactory
{
    private const string badminton = "Badminton";
    private const string tennis = "Tennis";
    private const string chess = "Chess";

    private delegate Sport SportFactoryFn(Sport s, List<IRule> rules);

    private static Dictionary<string, SportFactoryFn> _sportTypes = new()
    {
        {
            badminton, (sport, rules) => new Badminton(sport, rules)
        },
        {
            tennis, (sport, rules) => new Tennis(sport, rules)
        },
        {
            chess, (sport, rules) => new Chess(sport, rules)
        }
    };
    public static Sport CreateSport(Sport sport)
    {
        var rules = new List<IRule> {new BadmintonResult()};
        return _sportTypes[sport.Name](sport, rules);
    }
}

