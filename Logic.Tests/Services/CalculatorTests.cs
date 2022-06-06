using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using Logic.Services;
using Microsoft.VisualBasic;
using Xunit;

namespace Logic.Tests.Services
{
    public class CalculatorTests
    {
        [Theory, ClassData(typeof(ResultsData))]
        public void WinRatio_Valid_test(List<Result> results)
        {
            var ratio = Calculator.WinRatio(results, 1);

            var expected = ratio is < 100 and > 0;

            var actual = ratio;

            Assert.InRange(actual, 0, 100);
        }

        private class ResultsData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new List<Result>()
                    {
                        new(1, 1, 1, 21), 
                        new(2, 2, 1, 18),
                        new(3, 1, 2, 24), 
                        new(4, 3, 2, 22),
                        new(5, 1, 3, 21), 
                        new(6, 4, 3, 15),
                        new(7, 2, 4, 30), 
                        new(8, 3, 4, 28),
                        new(9, 2, 5, 21), 
                        new(10, 4, 5, 15),
                        new(11, 3, 6, 21), 
                        new(12, 4, 6, 15)
                    }
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
