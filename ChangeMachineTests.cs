using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CoinChange
{
    public class ChangeMachineTests
    {
        [Fact]
        public void OneSolutionForZeroSum() =>
            Assert.Equal(1, WaysToMakeChange(0, Enumerable.Empty<int>()));

        [Fact]
        public void NoCoinsNoSolution() =>
            Assert.Equal(0, WaysToMakeChange(1, Enumerable.Empty<int>()));

        [Fact]
        public void OneCoinOneSimpleSolution() =>
            Assert.Equal(1, WaysToMakeChange(3, new[] { 3 }));

        [Fact]
        public void OneCoinOneComplexSolution() =>
            Assert.Equal(1, WaysToMakeChange(9, new[] { 3 }));

        [Fact]
        public void OneCoinNoSolution() =>
            Assert.Equal(0, WaysToMakeChange(3, new[] { 2 }));

        [Fact]
        public void MultipleCoinsNoSolution() =>
            Assert.Equal(0, WaysToMakeChange(1, new[] { 2, 3 }));

        [Fact]
        public void MultipleCoinsMultipleSimpleSolution() =>
            Assert.Equal(2, WaysToMakeChange(6, new[] { 2, 3 }));

        [Fact]
        public void MultipleCoinsOneComplexSolution() =>
            Assert.Equal(1, WaysToMakeChange(5, new[] { 2, 3 }));

        [Fact]
        public void MultipleCoinsMultipleComplexSolutions() =>
            Assert.Equal(5, WaysToMakeChange(5, new[] { 1, 2, 3 }));

        [Fact]
        public void HackerRankSample() =>
            Assert.Equal(5, WaysToMakeChange(10, new[] { 2, 5, 3, 6 }));

        public static int WaysToMakeChange(int sum, IEnumerable<int> coins)
        {
            return new ChangeMachine(coins).WaysToMakeChange(sum);
        }
    }
}
