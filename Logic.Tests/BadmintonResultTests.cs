using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using Xunit;

namespace Logic.Tests
{
    public class BadmintonResultTests
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
            BadmintonResult badmintonResult = new BadmintonResult();

            badmintonResult.Validate(one, two);
        }
    }
}
