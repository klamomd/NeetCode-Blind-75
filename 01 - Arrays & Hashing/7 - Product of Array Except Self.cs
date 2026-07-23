public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        
        int[] result = new int[n];

        // Initialize result with '1's, or our products will zero out.
        for (int i=0; i<n; i++) {
            result[i] = 1;
        }

        // Iterate through all numbers. Each result that does not share the same index will be multiplied by
        // that number.
        for (int i = 0; i < n; i++) {
            int currentNumber = nums[i];

            // Lazily update all other products by adding 1..(n-1) to the current index, wrapping the resulting
            // index if OOB, and then multiplying the product with the current number in-place.
            for (int j = 1; j < n; j++) {
                int index = (i + j) % n;

                result[index] *= currentNumber;
            }
        }

        return result;
    }
}
