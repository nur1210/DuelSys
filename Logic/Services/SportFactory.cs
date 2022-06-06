using System.Formats.Asn1;
using System.Xml;
using Logic.Models;
using Logic.Rules;

namespace Logic.Services;

public static class SportFactory
{
    private const string badminton = "Badminton";
    private const string tennis = "Tennis";
    private const string chess = "Chess";

    private delegate Sport SportFactoryFn(Sport s);

    private static Dictionary<string, SportFactoryFn> _sportTypes = new()
    {
        {
            badminton, (sport) => new Badminton(sport, new BadmintonRuleResult())
        },
        {
            tennis, (sport) => new Tennis(sport, new TennisRuleResult())
        },
        {
            chess, (sport) => new Chess(sport, new ChessRuleResult())
        }
    };
    public static Sport CreateSport(Sport sport)
    {
        return _sportTypes[sport.Name](sport);
    }
}

