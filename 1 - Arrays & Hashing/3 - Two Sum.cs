public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Map value to index
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            int diff = target - nums[i];

            // See if there's already a match in dict.
            if (dict.ContainsKey(diff)) {
                return [dict[diff], i];
            }

            // Update dict otherwise.
            dict.Add(nums[i], i);
        }

        // Default case - should never be reached, if assumptions are correct.
        return [];
    }
}
