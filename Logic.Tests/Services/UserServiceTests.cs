using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using Xunit;

namespace Logic.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public void RegisterUserToTournament_ValidCall()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllTournaments())
                .Returns(GetSampleTournaments());

            var cls = mock.Create<UserService>();

            var expected = true;

            var actual = cls.RegisterUserToTournament(1,1);

            Assert.True(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RegisterUserToTournament_StartDate_Not_Valid()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllTournaments())
                .Returns(GetSampleTournaments());

            var cls = mock.Create<UserService>();

            var expected = false;

            var actual = cls.RegisterUserToTournament(1, 2);

            Assert.False(actual);
            Assert.Equal(expected, actual);
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
                2,
                "World cup",
                "Windhoek",
                4,
                12,
                DateTime.Today.AddDays(6),
                DateTime.Today.AddDays(6),
                new Sport(1,
                    "Badminton",
                    4,
                    12),
                new TournamentSystem(1,
                    "Round Robin"))
            );
            return list;
        }
    }
}
