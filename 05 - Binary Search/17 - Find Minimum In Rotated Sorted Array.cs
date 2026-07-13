public class Solution {
    public int FindMin(int[] nums) {
        // Edge case - nums has one element.
        if (nums.Length == 1) {
            return nums[0];
        }

        int l = 0;
        int r = nums.Length - 1;

        // Edge case - nums hasn't been rotated, or has been rotated n times.
        if (nums[l] < nums[r]) {
            return nums[l];
        }
        
        while (l < r) {
            int m = l + ((r - l) / 2);

            int left = nums[l];
            int mid = nums[m];
            
            // If mid is smaller than left, then continue searching in the left half of our search area.
            if (mid < left) {
                r = m;
            }
            // If mid is pointing to the same number as left, then we've reached the end of our search.
            else if (mid == left) {
                break;
            }
            // Otherwise, continue searching in the right half of our search area.
            else {
                l = m;
            }
        }

        // Return the lesser of left and right.
        return Math.Min(nums[l], nums[r]);
    }
}
