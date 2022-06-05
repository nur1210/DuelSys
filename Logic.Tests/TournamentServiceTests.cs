using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.Moq;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using Logic.Views;
using Xunit;

namespace Logic.Tests
{
    public class TournamentServiceTests
    {
        //[Fact]
        //public void GenerateTournamentSchedule_ValidCall()
        //{
        //    var tournamentId = GetSampleTournament().Id;
        //    using var mock = AutoMock.GetLoose();
        //    foreach (var match in getSampleMatches())
        //    {
        //        mock.Mock<IMatchDB>()
        //            .Setup(x => x.CreateMatch(match));
        //    }

        //    var cls = mock.Create<TournamentService>();
        //    var expected = true;

        //    var actual = cls.GenerateTournamentSchedule(tournamentId);

        //    Assert.True(actual);
        //    Assert.Equal(expected, actual);

        //}

        [Fact]
        public void GenerateTournamentSchedule_ValidCall()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllTournaments())
                .Returns(GetSampleTournaments());

            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllUsersRegisteredToTournamentByTournamentId(1))
                .Returns(GetSampleUsers);


            var cls = mock.Create<TournamentService>();

            var expected = true;

            var actual = cls.GenerateTournamentSchedule(1);

            Assert.True(actual);
            Assert.Equal(expected, actual);

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

        private List<Tournament> GetSampleTournaments()
        {
            var list = new List<Tournament>();
            list.Add(new Tournament(
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
                    "Round Robin"))
            );

            list.Add(new Tournament(
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
                    "Round Robin"))
            );
            return list;
        }
        private List<TournamentView> GetSampleTournamentsView()
        {
            var list = new List<TournamentView>();
            list.Add(new TournamentView(
                1,
                "World cup",
                "Windhoek",
                10,
                4,
                12,
                new DateTime(2022, 10, 12),
                new DateTime(2022, 10, 18),
                "Badminton",
                "Round Robin"
            ));
            list.Add(new TournamentView(
                2,
                "World cup",
                "Windhoek",
                10,
                4,
                12,
                new DateTime(2022, 10, 12),
                new DateTime(2022, 10, 18),
                "Badminton",
                "Round Robin"
            ));
            return list;
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
