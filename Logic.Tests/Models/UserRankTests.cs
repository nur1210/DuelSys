using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using Xunit;

namespace Logic.Tests.Models
{
    public class UserRankTests
    {
        [Theory, ClassData(typeof(MatchData))]
        public void Leaderboard_Constructor_Test(List<Match> matches)
        {
            var userRank = new UserRank(1, matches);

            var expected = 3;

            var actual = userRank.Wins;

            Assert.Equal(expected, actual);
        }


        [Theory, ClassData(typeof(MatchData))]
        public void Leaderboard_Constructor_Test2(List<Match> matches)
        {
            var userRank = new UserRank(2, matches);

            var expected = 2;

            var actual = userRank.Wins;

            Assert.Equal(expected, actual);
        }


        [Theory, ClassData(typeof(MatchData))]
        public void Leaderboard_Constructor_Test3(List<Match> matches)
        {
            var userRank = new UserRank(3, matches);

            var expected = 1;

            var actual = userRank.Wins;

            Assert.Equal(expected, actual);
        }


        [Theory, ClassData(typeof(MatchData))]
        public void Leaderboard_Constructor_Test4(List<Match> matches)
        {
            var userRank = new UserRank(4, matches);

            var expected = 0;

            var actual = userRank.Wins;

            Assert.Equal(expected, actual);
        }

        private class MatchData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new List<Match>()
                    {
                        new(1, DateTime.Today, 1, 1, 2, new List<Result>
                        {
                            new(1, 1, 1, 21), new(2, 2, 1, 18)
                        }),
                        new(2, DateTime.Today, 1, 1, 3, new List<Result>
                        {
                            new(3, 1, 2, 24), new(4, 3, 2, 22)
                        }),
                        new(3, DateTime.Today, 1, 1, 4, new List<Result>
                        {
                            new(5, 1, 3, 21), new(6, 4, 3, 15)
                        }),
                        new(4, DateTime.Today, 1, 2, 3, new List<Result>
                        {
                            new(7, 2, 4, 30), new(8, 3, 4, 28)
                        }),
                        new(5, DateTime.Today, 1, 2, 4, new List<Result>
                        {
                            new(9, 2, 5, 21), new(10, 4, 5, 15)
                        }),
                        new(6, DateTime.Today, 1, 3, 4, new List<Result>
                        {
                            new(11, 3, 6, 21), new(12, 4, 6, 15)
                        }),
                    }
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
