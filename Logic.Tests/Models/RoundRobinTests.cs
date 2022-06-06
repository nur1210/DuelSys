using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Logic.Interfaces;
using Logic.Models;
using Xunit;

namespace Logic.Tests.Models
{
    public class RoundRobinTests
    {
        [Fact]
        public void GenerateRoundRobinSchedule_ValidCall()
        {
            var roundRobin = new RoundRobin(new TournamentSystem(1, "Round Robin"));

            var expected = getSampleMatches();

            var actual = roundRobin.GenerateTournamentSchedule(GetSampleTournament(), GetSampleUsers());

            Assert.True(actual != null);
            Assert.Equal(expected.Count, actual.Count);
            foreach (var actualMatch in actual)
            {
                foreach (var expectedMatch in expected.Where(expectedMatch => actualMatch.Id == expectedMatch.Id))
                {
                    Assert.Equal(expectedMatch.Date, actualMatch.Date);
                }
            }
        }

        [Fact]
        public void GenerateRoundRobinSchedule_No_Players_Registered_To_Tournament()
        {
            var roundRobin = new RoundRobin(new TournamentSystem(1, "Round Robin"));

            var expected = "Invalid call";

            var actual = Assert.Throws<ArgumentException>(() => roundRobin.GenerateTournamentSchedule(GetSampleTournament(), new List<User>()));

            Assert.Equal(expected, actual.Message);
        }

        [Fact]
        public void GenerateRoundRobinSchedule_With_Different_TournamentSystem()
        {
            var tournamentSystem = new RoundRobin(new TournamentSystem(2, "Single elimination"));

            var tournament = GetSampleTournament();
            tournament.System.Name = tournamentSystem.Name;

            var expected = "Invalid call";

            var actual = Assert.Throws<ArgumentException>(() => tournamentSystem.GenerateTournamentSchedule(tournament, GetSampleUsers()));

            Assert.Equal(expected, actual.Message);
        }


        private List<User> GetSampleUsers()
        {
            List<User> users = new List<User>
            {
                new(1, "Mariia", "Parakhina", "mariia@gmail.com", "12345", false),
                new(2, "Nur", "Nechuhstan", "nur@gmail.com", "12345", false),
                new(3, "Alex", "Dumi", "alex@gmail.com", "12345", false),
                new(4, "Lyubo", "Lo", "lyubo@gmail.com", "12345", false),
            };
            return users;
        }

        private Tournament GetSampleTournament()
        {
            var tournament = new Tournament(
                1,
                "World cup",
                "Windhoek",
                4,
                12,
                new DateTime(2022, 10, 12),
                new DateTime(2022, 10, 18),
                new Sport(1,
                    "Badminton",
                    4,
                    12),
                new TournamentSystem(1,
                    "Round Robin")
            );
            return tournament;
        }

        private List<Match> getSampleMatches()
        {
            List<Match> list = new List<Match>();
            list.Add(new Match(1, new DateTime(2022, 10, 13), 1, 1, 2));
            list.Add(new Match(2, new DateTime(2022, 10, 14), 1, 1, 3));
            list.Add(new Match(3, new DateTime(2022, 10, 15), 1, 1, 4));
            list.Add(new Match(4, new DateTime(2022, 10, 16), 1, 2, 3));
            list.Add(new Match(5, new DateTime(2022, 10, 17), 1, 2, 4));
            list.Add(new Match(6, new DateTime(2022, 10, 18), 1, 3, 4));
            return list;
        }
    }
}
