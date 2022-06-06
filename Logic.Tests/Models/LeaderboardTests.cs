using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace Logic.Tests
{
    public class LeaderboardTests
    {
        [Fact]
        public void Leaderboard_Constructor_Test()
        {
            var leaderboard = new Leaderboard(1, SampleUsersRanks());

            var expected = 1; //The expected userId at the first rank in the leaderboard

            var actual = leaderboard.RankedLeaderboard.Values.Select(x => x.UserId).First();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(UserRankData))]
        public void Leaderboard_Constructor_Test_Throw_Exception(UserRank userRank)
        {
            var userRanks = new List<UserRank> {userRank};

            var expected = "Leaderboard cannot be calculate";

            var actual = Assert.Throws<ArgumentException>(() => new Leaderboard(1, userRanks));

            Assert.Equal(expected, actual.Message);
        }

        private static List<UserRank> SampleUsersRanks()
        {
            var userRanks = new List<UserRank>()
            {
                new(1, new List<Match>
                {
                    new(1, DateTime.Today,1,1,2,new List<Result>()
                    {
                        new(1,1,1,21), new(2,2,1,18)
                    }),
                    new(2, DateTime.Today,1,1,3,new List<Result>()
                    {
                        new(3,1,2,24), new(4,3,2,22)
                    }),
                    new(3, DateTime.Today,1,1,4,new List<Result>()
                    {
                        new(5,1,3,21), new(6,4,3,15)
                    }),
                }),
                new(2, new List<Match>
                {
                    new(1, DateTime.Today,1,2,1,new List<Result>()
                    {
                        new(1,1,1,21), new(2,2,1,18)
                    }),
                    new(4, DateTime.Today,1,2,3,new List<Result>()
                    {
                        new(7,2,4,30), new(8,3,4,28)
                    }),
                    new(5, DateTime.Today,1,2,4,new List<Result>()
                    {
                        new(9,2,5,21), new(10,4,5,15)
                    }),
                }),
                new(3, new List<Match>
                {
                    new(2, DateTime.Today,1,1,3,new List<Result>()
                    {
                        new(3,1,2,24), new(4,3,2,22)
                    }),
                    new(4, DateTime.Today,1,2,3,new List<Result>()
                    {
                        new(7,2,4,30), new(8,3,4,28)
                    }),
                    new(6, DateTime.Today,1,3,4,new List<Result>()
                    {
                        new(11,3,6,21), new(12,4,6,15)
                    }),
                }),
                new(4, new List<Match>
                {
                    new(3, DateTime.Today,1,1,4,new List<Result>()
                    {
                        new(5,1,3,21), new(6,4,3,15)
                    }),
                    new(5, DateTime.Today,1,2,4,new List<Result>()
                    {
                        new(9,2,5,21), new(10,4,5,15)
                    }),
                    new(6, DateTime.Today,1,3,4,new List<Result>()
                    {
                        new(11,3,6,21), new(12,4,6,15)
                    }),
                }),
            };
            return userRanks;
        }

        private class UserRankData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new UserRank(1, new List<Match>
                    {
                        new(1, DateTime.Today,1,1,2,new List<Result>()
                        {
                            new(1,1,1,21), new(2,2,1,18)
                        }),
                        new(2, DateTime.Today,1,1,3,new List<Result>()
                        {
                            new(3,1,2,24), new(4,3,2,22)
                        }),
                        new(3, DateTime.Today,1,1,4,new List<Result>()
                        {
                            new(5,1,3,21), new(6,4,3,15)
                        }),
                    }),
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
