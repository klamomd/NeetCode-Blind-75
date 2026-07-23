public class Solution {
    public int MaxProduct(int[] nums) {
        int minProduct = nums[0];
        int maxProduct = nums[0];

        int bestMax = maxProduct;

        for (int i = 1; i < nums.Length; i++) {
            int curr = nums[i];

            // Track 3 values: Starting a new array (just using curr), multiplying by the previous max,
            // or multiplying by the previous min.
            var valuesList = new [] { curr, maxProduct * curr, minProduct * curr };
            
            // Update max and min product.
            maxProduct = valuesList.Max();
            minProduct = valuesList.Min();

            // If current maxProduct is larger than best max, then update best max.
            bestMax = Math.Max(bestMax, maxProduct);
        }

        return bestMax;
    }
}
