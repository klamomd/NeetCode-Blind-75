public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        int[] max = new int[n];

        // First house max consists of choosing to rob the house.
        max[0] = nums[0];

        for (int i=1; i<n; i++) {
            int twoHousesAgo = 0;

            // Only calculate max of 2 houses ago if we're not OOB.
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
