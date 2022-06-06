using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace Logic.Tests
{
    public class BadmintonRuleResultTests
    {
        [Theory]
        [InlineData(1,21)]
        [InlineData(15,21)]
        [InlineData(30,29)]
        [InlineData(30,28)]
        [InlineData(21,19)]
        [InlineData(19,21)]
        [InlineData(22,20)]
        [InlineData(24,22)]
        [InlineData(26,24)]
        [InlineData(24,26)]
        public void Validate_ValidCall(int one, int two)
        {
            BadmintonRuleResult badmintonResult = new();

            badmintonResult.Validate(one, two);
        }

        [Theory]
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
            BadmintonRuleResult badmintonResult = new();

            var accusal = Assert.Throws<Exception>(() => badmintonResult.Validate(one, two));

            Assert.Equal(new Exception().GetType(), accusal.GetType());
        }
    }
}
