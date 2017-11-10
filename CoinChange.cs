using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CoinChange
{
    public class CoinChange
    {
        [Fact]
        public void NoCoinsNoSolution() =>
            Assert.Equal(0, Change(1, Enumerable.Empty<int>()));

        [Fact]
        public void OneCoinOneSimpleSolution() =>
            Assert.Equal(1, Change(3, new[] { 3 }));

        [Fact]
        public void OneCoinOneComplexSolution() =>
            Assert.Equal(1, Change(9, new[] { 3 }));

        [Fact]
        public void OneCoinNoSolution() =>
            Assert.Equal(0, Change(3, new[] { 2 }));

        [Fact]
        public void MultipleCoinsNoSolution() =>
            Assert.Equal(0, Change(1, new[] { 2, 3 }));

        [Fact]
        public void MultipleCoinsMultipleSimpleSolution() =>
            Assert.Equal(2, Change(6, new[] { 2, 3 }));

        [Fact]
        public void MultipleCoinsOneComplexSolution() =>
            Assert.Equal(1, Change(5, new[] { 2, 3 }));

        [Fact]
        public void MultipleCoinsMultipleComplexSolutions() =>
            Assert.Equal(5, Change(5, new[] { 1, 2, 3 }));

        [Fact]
        public void HackerRankSample() =>
            Assert.Equal(5, Change(10, new[] { 2, 5, 3, 6 }));

        public static int Change(int n, IEnumerable<int> coins)
        {
            int[] m = new int[n + 1];
            foreach (int coin in coins)
                for (int j = 0; j < n; j++)
                    if ((j == 0 || m[j] != 0) && j + coin <= n)
                        m[j + coin] += Math.Max(m[j], 1);
            return m[n];
        }
    }
}
