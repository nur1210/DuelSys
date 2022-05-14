using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Models;

namespace Logic.Services
{
    public static class TournamentSystemFactory
    {
        private const string RoundRobin = "Round Robin";

        private delegate TournamentSystem TournamentSystemFactoryFn(TournamentSystem ts);

        private static Dictionary<string, TournamentSystemFactoryFn> _tournamentSystemTypes = new()
        {
            {
                RoundRobin,
                tournamentSystem => new RoundRobin(tournamentSystem)
            }
        };
        public static TournamentSystem CreateTournamentSystem(TournamentSystem ts)
        {
            return _tournamentSystemTypes[ts.Name](ts);
        }
    }
}
