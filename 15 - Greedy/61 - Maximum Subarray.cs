public class Solution {
    public int MaxSubArray(int[] nums) {
        int maxSum = Int32.MinValue;
        int currSum = 0;

        foreach (int num in nums) {
            currSum += num;

            // If the current number is greater than the current sum, reset the current sum.
            if (num > currSum) {
                currSum = num;
            }

            maxSum = Math.Max(currSum, maxSum);
        }

        return maxSum;
    }
}
