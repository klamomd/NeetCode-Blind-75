public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;

        // Base case - 1 element.
        if (n == 1) {
            return nums[0];
        }

        /*
            Since the houses are arranged in a circle, picking an arbitrary house as "first", we can either:
                - Choose to skip that house, and possibly rob one or both of the adjacent houses.
                - Choose to rob that house, skipping the adjacent houses. The house to the left is the last
                    house in the circle, in this situation.
        */

        // Create 2 sub arrays - one excluding the last element, and the other excluding the first element.
        int[] first = nums.Take(n-1).ToArray();
        int[] second = nums.Skip(1).ToArray();

        // Run HouseRobber1 on both solutions and return the maximum result.
        int result1 = HouseRobber1(first);
        int result2 = HouseRobber1(second);

        return Math.Max(result1, result2);
    }

    // Solution copied over from "House Robber I" problem.
    private int HouseRobber1(int[] nums) {
        int n = nums.Length;

        // Base case - empty array.
        if (n == 0) {
            return 0;
        }
        // Base case - 1 element.
        else if (n == 1) {
            return nums[0];
        }

        int[] max = new int[n];

        // First house max consists of choosing to rob the house.
        max[0] = nums[0];

        for (int i=1; i<n; i++) {
            int twoHousesAgo = 0;

            // Prevent OOB fetch.
            if (i >= 2) {
                twoHousesAgo = max[i - 2];
            }

            // Profit from robbing this house and the max profit 2 houses ago.
            int rob = nums[i] + twoHousesAgo;

            // Profit from skipping this house and robbing the last house.
            int skip = max[i - 1];

            // Max between robbing and skipping gets stored in max array.
            max[i] = Math.Max(rob, skip);
        }

        // Return the max of the last house.
        return max[n-1];
    }
}
