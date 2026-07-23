public class Solution {
    public int Search(int[] nums, int target) {
        /*  Pick L, R, and M
            If L < M < R, then we can easily find where to look for target:
                - If target < L, shift window left
                    (Should never be the case, if we start L = 0, R = n-1?)
                - If target > R, shift right
                    (Should never be the case, if we start L = 0, R = n-1?)

                - If target == M, return index of M
                - If target between L and M, set R to M - 1 and search again
                - If target between M and R, set L to M + 1 and search again
            
            If L > R, then there's a cut / rotation point in the center
                - If target > L, then target is between L and cut point
                - If target < R, then target is between cut point and R

        */

        /* PLAN: Find cut point first, and split array into two?
            - Then discard the subarray that is unneeded, and binary search again for target?
        */

        // Locate cut point. Cut point is defined as the index where the number is less than the prior number.
        // Ex: [3, 1, 2] <- cut point at index 1 (val 1)

        int lPtr = 0;
        int rPtr = nums.Length - 1;

        while (lPtr != rPtr) {
            int distance = rPtr - lPtr;
            int mPtr = lPtr + (distance / 2);

            // Grab actual values.
            int left = nums[lPtr];
            int right = nums[rPtr];
            int middle = nums[mPtr];

            // CASE: Left value is < right value. Cut point is at L, so stop searching.
            if (left < right) {
                break;
            }

            // CASE: Left, Middle > Right
            // EX: [2, 3, 1]
            //      L  M  R
            // Cut point is between M and R. Update L to be M + 1 and loop again.
            if (middle > right) {
                lPtr = mPtr + 1;

                continue;
            }

            // CASE: Left > Middle, Right
            // EX: [3, 1, 2]
            //      L  M  R
            // Cut point is between L and M. Update R to be M and loop again.
            if (left > middle) {
                rPtr = mPtr;

                continue;
            }
        }

        // Only search a specific half of the array if the array has been rotated. Otherwise, search the whole thing.
        if (nums[0] > nums[nums.Length - 1]) {
            // Determine whether to search left or right half of array, and update pointers accordingly.
            // Search left half.
            if (target >= nums[0]) {
                // Since cut point is at lPtr, set rPtr = lPtr and reset lPtr to 0.
                rPtr = lPtr;
                lPtr = 0;
            }
            // Search right half.
            else {
                // Since cut point is at lPtr, set rPtr to last index.
                rPtr = nums.Length - 1;
            }
        }

        // Search for the target in the subarray.
        while (lPtr != rPtr) {
            int distance = rPtr - lPtr;
            int mPtr = lPtr + (distance / 2);

            // Grab actual values.
            int left = nums[lPtr];
            int right = nums[rPtr];
            int middle = nums[mPtr];

            // CASE: Found target, return index.
            if (middle == target) {
                return mPtr;
            }

            // CASE: Target > middle - adjust left pointer.
            if (target > middle) {
                lPtr = mPtr + 1;
            }
            // CASE: Target < middle - adjust right pointer.
            else {
                rPtr = mPtr;
            }
        }

        // Check the left pointer to determine if the target was found. Return -1 if not.
        if (nums[lPtr] == target) {
            return lPtr;
        }

        return -1;
    }
}
