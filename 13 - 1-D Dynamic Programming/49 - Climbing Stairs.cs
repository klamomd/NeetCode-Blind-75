public class Solution {
    Dictionary<int, int> ways = new Dictionary<int, int>();

    public int ClimbStairs(int n) {
        // Base case. If there's 1 step, then there is 1 way to climb to the next step.
        // Also return 1 for 0 steps, to allow this recursion to work for n = 2.
        if (n <= 1) {
            return 1;
        }

        // Avoid duplicate work by using cached results.
        if (ways.ContainsKey(n)) {
            return ways[n];
        }

        // Calculate work for the first time.
        var waysForN = ClimbStairs(n - 1) + ClimbStairs(n - 2);

        // Cache results.
        ways[n] = waysForN;

        return waysForN;
    }
}
