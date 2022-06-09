using Logic.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter.Xml;
using Logic.Exceptions;
using Xunit;

namespace Logic.Tests.Rules
{
    public class ChessRuleResultTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        public void Validate_ValidCall(int one, int two)
        {
            WinnerOrLoserRuleResult chessRuleResult = new();

            chessRuleResult.Validate(one, two);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(-1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(10, 12)]
        [InlineData(31, 30)]
        [InlineData(30, 31)]
        [InlineData(1000, 21)]
        [InlineData(-1, 20)]
        [InlineData(21, -5)]
        [InlineData(24, 24)]
        [InlineData(30, 30)]
        [InlineData(int.MaxValue, 30)]
        [InlineData(int.MaxValue, int.MinValue)]
        public void Validate_Values_Not_valid(int one, int two)
        {
            WinnerOrLoserRuleResult chessRuleResult = new();

            var actual = Assert.Throws<MatchResultException>(() => chessRuleResult.Validate(one, two));

            Assert.Equal(new MatchResultException().GetType(), actual.GetType());
        }
    }
}
