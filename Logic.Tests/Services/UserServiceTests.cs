using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            var actual = cls.RegisterUserToTournament(1, 1);

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

        [Fact]
        public void GetUserBestRank_ValidCall_UserId_1()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllStartedTournaments())
                .Returns(GetSampleTournament());

            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetTournamentLeaderboard(1))
                .Returns(GetSampleLeaderboards());

            var cls = mock.Create<UserService>();

            var expected = 1; //The expected rank for the user with Id 1

            var actual = cls.GetUserBestRank(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetUserBestRank_ValidCall_UserId_2()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllStartedTournaments())
                .Returns(GetSampleTournament());

            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetTournamentLeaderboard(1))
                .Returns(GetSampleLeaderboards());

            var cls = mock.Create<UserService>();

            var expected = 2; //The expected rank for the user with Id 2

            var actual = cls.GetUserBestRank(2);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetUserBestRank_ValidCall_UserId_4()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllStartedTournaments())
                .Returns(GetSampleTournament());

            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetTournamentLeaderboard(1))
                .Returns(GetSampleLeaderboards());

            var cls = mock.Create<UserService>();

            var expected = 4; //The expected rank for the user with Id 4

            var actual = cls.GetUserBestRank(4);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetUserBestRank_Throw_Exception()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllStartedTournaments())
                .Returns(GetSampleTournament());

            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetTournamentLeaderboard(1))
                .Returns(GetSampleLeaderboards());

            var cls = mock.Create<UserService>();

            var expected = "User is not ranked";

            var actual = Assert.Throws<ArgumentException>(() => cls.GetUserBestRank(5));

            Assert.Equal(expected, actual.Message);
        }


        private List<Tournament> GetSampleTournaments()
        {
            var list = new List<Tournament>
            {
                new(1,
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
                        "Round Robin")),
                new(2,
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
                        "Round Robin")),
                new(3,
                    "World cup",
                    "Windhoek",
                    4,
                    12,
                    DateTime.Today.AddDays(6),
                    DateTime.Today.AddDays(6),
                    new Sport(1,
                        "Chess",
                        4,
                        12),
                    new TournamentSystem(1,
                        "Round Robin")),
                new(4,
                    "World cup",
                    "Windhoek",
                    4,
                    12,
                    DateTime.Today.AddDays(6),
                    DateTime.Today.AddDays(6),
                    new Sport(1,
                        "Tennis",
                        4,
                        12),
                    new TournamentSystem(1,
                        "Round Robin")),
            };

            return list;
        }

        private List<Tournament> GetSampleTournament()
        {
            var list = new List<Tournament>
            {
                new(1,
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
            };
            return list;
        }

        private Leaderboard GetSampleLeaderboards()
        {
            var leaderboard = new Leaderboard(1, new List<UserRank>
                {
                    new(1, new List<Match>
                    {
                        new(1, DateTime.Today, 1, 1, 2, new List<Result>()
                        {
                            new(1, 1, 1, 21), new(2, 2, 1, 18)
                        }),
                        new(2, DateTime.Today, 1, 1, 3, new List<Result>()
                        {
                            new(3, 1, 2, 24), new(4, 3, 2, 22)
                        }),
                        new(3, DateTime.Today, 1, 1, 4, new List<Result>()
                        {
                            new(5, 1, 3, 21), new(6, 4, 3, 15)
                        }),
                    }),
                    new(2, new List<Match>
                    {
                        new(1, DateTime.Today, 1, 2, 1, new List<Result>()
                        {
                            new(1, 1, 1, 21), new(2, 2, 1, 18)
                        }),
                        new(4, DateTime.Today, 1, 2, 3, new List<Result>()
                        {
                            new(7, 2, 4, 30), new(8, 3, 4, 28)
                        }),
                        new(5, DateTime.Today, 1, 2, 4, new List<Result>()
                        {
                            new(9, 2, 5, 21), new(10, 4, 5, 15)
                        }),
                    }),
                    new(3, new List<Match>
                    {
                        new(2, DateTime.Today, 1, 1, 3, new List<Result>()
                        {
                            new(3, 1, 2, 24), new(4, 3, 2, 22)
                        }),
                        new(4, DateTime.Today, 1, 2, 3, new List<Result>()
                        {
                            new(7, 2, 4, 30), new(8, 3, 4, 28)
                        }),
                        new(6, DateTime.Today, 1, 3, 4, new List<Result>()
                        {
                            new(11, 3, 6, 21), new(12, 4, 6, 15)
                        }),
                    }),
                    new(4, new List<Match>
                    {
                        new(3, DateTime.Today, 1, 1, 4, new List<Result>()
                        {
                            new(5, 1, 3, 21), new(6, 4, 3, 15)
                        }),
                        new(5, DateTime.Today, 1, 2, 4, new List<Result>()
                        {
                            new(9, 2, 5, 21), new(10, 4, 5, 15)
                        }),
                        new(6, DateTime.Today, 1, 3, 4, new List<Result>()
                        {
                            new(11, 3, 6, 21), new(12, 4, 6, 15)
                        }),
                    })
                }
            );
            return leaderboard;
        }
    }
}
