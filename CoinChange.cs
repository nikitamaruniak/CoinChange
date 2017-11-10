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

        public static int Change(int n, IEnumerable<int> coins)
        {
            int[] m = new int[n + 1];
            foreach (int coin in coins)
                for (int j = coin; j <= n; j += coin)
                    m[j] += 1;
            return m[n];
        }
    }
}
