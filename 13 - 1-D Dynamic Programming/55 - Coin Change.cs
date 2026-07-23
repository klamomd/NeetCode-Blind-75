public class Solution {
    public int CoinChange(int[] coins, int amount) {
        // Base case - amount is 0. No coins required.
        if (amount == 0) {
            return 0;
        }

        // Ignore coins that are too large.
        coins = coins.Where(c => c <= amount).OrderByDescending(c => c).ToArray();

        // Base case - ran out of coin denominations.
        // Return -1 because there is no way to get the non-zero amount.
        if (coins.Length == 0) {
            return -1;
        }

        // Determine how many of the largest denomination we can use.
        int largest = coins[0];

        // Determine the most coins we could use, when using the largest denomination.
        int coinCount = amount / largest;

        // If we can reach the desired amount with just this denomination, return immediately.
        if (amount % largest == 0) {
            return coinCount;
        }

        // Create a subarray of coins, without the largest denomination.
        int[] coinSubArray = coins.Skip(1).ToArray();

        // Use a variable to track the minimum found.
        int currentMinimum = int.MaxValue;

        while (coinCount >= 0) {
            // Determine the remaining amount, given the current number of largest denomination coins.
            int remainingAmount = amount - (coinCount * largest);

            // Recurse.
            int recurseReturnValue = CoinChange(coinSubArray, remainingAmount);

            // If we were able to find a solution, then sum the result and the number of coins used so far,
            // and update the current minimum if appropriate.
            if (recurseReturnValue != -1) {
                int sum = coinCount + recurseReturnValue;
                currentMinimum = Math.Min(currentMinimum, sum);
            }

            // If we failed to find a solution using this many of the largest coins, then try using 1 fewer.
            coinCount--;
        }

        // If the current minimum is still set to int.MaxValue, then return -1, since we found no solutions.
        if (currentMinimum == int.MaxValue) {
            return -1;
        }

        // Otherwise, return the current minimum.
        return currentMinimum;
    }
}
