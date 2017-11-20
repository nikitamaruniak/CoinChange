using System.Collections.Generic;

namespace CoinChange
{
    public class ChangeMachine
    {
        public ChangeMachine(IEnumerable<int> coins)
        {
            this.coins = coins;
        }

        private IEnumerable<int> coins;

        public int WaysToMakeChange(int sum)
        {
            int[] waysBySum = new int[sum + 1];
            waysBySum[0] = 1;
            foreach (int coin in coins)
                for (int baseSum = 0; baseSum <= sum - coin; baseSum++)
                    waysBySum[baseSum + coin] += waysBySum[baseSum];
            return waysBySum[sum];
        }
    }
}
