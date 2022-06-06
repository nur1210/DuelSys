using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using Xunit;

namespace Logic.Tests
{
    public class MatchTests
    {
        [Theory]
        [MemberData(nameof(MatchData))]
        public void Match_Constructor_Test(int id, DateTime date, int tournamentId, int firstPlayerId, int secondPlayerId, List<Result> matchResults)
        {
            var match = new Match(id, date, tournamentId, firstPlayerId, secondPlayerId, matchResults);
        }


        [Fact]
        public void Match_Constructor_Test_Get_WinnerId()
        {
            var match = new Match(1, DateTime.Today, 1, 1, 2, new List<Result> {new(1, 1, 1, 21), new(2, 2, 1, 18)});

            var expected = 1;

            Assert.Equal(expected, match.WinnerId);
        }

        [Fact]
        public void Match_Constructor_Test_Get_WinnerId_Fails()
        {
            var match = new Match(1, DateTime.Today, 1, 1, 2, new List<Result> { new(1, 1, 1, 21), new(2, 2, 1, 18) });

            var expected = 2;

            Assert.NotEqual(expected, match.WinnerId);
        }

        [Fact]
        public void Match_Constructor_Test_Get_LoserId()
        {
            var match = new Match(1, DateTime.Today, 1, 1, 2, new List<Result> { new(1, 1, 1, 21), new(2, 2, 1, 18) });

            var expected = 2;

            Assert.Equal(expected, match.LoserId);
        }

        public static IEnumerable<object[]> MatchData =>
            new List<object[]>
            {
                new object[] { 1, DateTime.Today, 1, 1, 2, new List<Result>
                {
                    new(1, 1, 1, 21), new(2, 2, 1, 18)
                }},
                new object[] { 2, DateTime.Today, 1, 1, 3, new List<Result>
                {
                    new(3, 1, 2, 24), new(4, 3, 2, 22)
                } },
                new object[] { 3, DateTime.Today, 1, 1, 4, new List<Result>
                {
                    new(5, 1, 3, 21), new(6, 4, 3, 15)
                } },
                new object[] {4, DateTime.Today, 1, 2, 3, new List<Result>
                {
                    new(7, 2, 4, 30), new(8, 3, 4, 28)
                } },
                new object[] { 5, DateTime.Today, 1, 2, 4, new List<Result>
                {
                    new(9, 2, 5, 21), new(10, 4, 5, 15)
                } },
                new object[] { 6, DateTime.Today, 1, 3, 4, new List<Result>
                {
                    new(11, 3, 6, 21), new(12, 4, 6, 15)
                } }
            };
    }
}
