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
        [Fact]
        public void GenerateTournamentSchedule_ValidCall()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllTournaments())
                .Returns(GetSampleTournaments());

            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllUsersRegisteredToTournamentByTournamentId(1))
                .Returns(GetSampleUsers());


            var cls = mock.Create<TournamentService>();

            var expected = true;

            var actual = cls.GenerateTournamentSchedule(1);

            Assert.True(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GenerateTournamentSchedule_MinPlayer_Not_Reached()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllTournaments())
                .Returns(GetSampleTournaments());

            var users = GetSampleUsers().FindAll(x => x.Id > 1);
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllUsersRegisteredToTournamentByTournamentId(1))
                .Returns(users);


            var cls = mock.Create<TournamentService>();

            var expected = false;

            var actual = cls.GenerateTournamentSchedule(1);

            Assert.False(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GenerateTournamentSchedule_MaxPlayer_Reached()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllTournaments())
                .Returns(GetSampleTournaments());

            var users = GetSampleUsers();
            users.AddRange(GetSampleUsers());
            users.AddRange(GetSampleUsers());
            users.AddRange(GetSampleUsers());
            users.AddRange(GetSampleUsers());

            mock.Mock<ITournamentDB>()
                .Setup(x => x.GetAllUsersRegisteredToTournamentByTournamentId(1))
                .Returns(users);


            var cls = mock.Create<TournamentService>();

            var expected = false;

            var actual = cls.GenerateTournamentSchedule(1);

            Assert.False(actual);
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
    }
}
