public class Solution {
    public bool CanJump(int[] nums) {
        // BASE CASE: Nums has 1 element.
        if (nums.Length == 1) {
            return true;
        }

        // Store the reachable indices in a set.
        var reachable = new HashSet<int> { 0 };

        for (int i = 0; i < nums.Length; i++) {
            // Skip unreachable steps.
            if (!reachable.Contains(i)) {
                continue;
            }

            // Skip steps that can't jump to any other steps.
            int jumpLength = nums[i];
            if (jumpLength == 0) {
                continue;
            }

            // Calculate all possible jump indices from the current step.
            for (int j = 1; j <= jumpLength; j++) {
                reachable.Add(i + j);
            }
        }

        // We can jump to the last step if the set of reachable indices contains that step.
        return reachable.Contains(nums.Length - 1);
    }
}
