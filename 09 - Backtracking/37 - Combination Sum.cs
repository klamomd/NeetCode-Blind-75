public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        var retList = new List<List<int>>();

        // BASE CASE: nums is empty.
        if (nums.Length == 0) {
            return retList;
        }

        // BASE CASE: 1 int in nums.
        if (nums.Length == 1) {
            // If target has been reached, add the current digit to the return list
            if (target % nums[0] == 0) {
                List<int> combo = new List<int>();
                for (int i = 0; i < target / nums[0]; i++) combo.Add(nums[0]);
                retList.Add(combo);
            }
            return retList;
        }

        // Foreach in nums, pare off all nums after, and pass recursively.
        for (int i=0; i<nums.Length; i++) {
            int current = nums[i];

            // If target has been exceeded, continue.
            if (current > target) {
                continue;
            }

            // If target has been reached, add the current digit to the return list, and then continue.
            if (current == target) {
                retList.Add(new List<int> { current });
                continue;
            }

            // If the target has not been reached, recurse with a sub array.
            int sumNeeded = target - current;

            int[] subArray = nums.Skip(i).ToArray();

            var combos = CombinationSum(subArray, sumNeeded);

            // Add the current number to every list in the returned sums, and add the resulting list
            // to the return value.
            foreach (var list in combos) {
                list.Add(current);
                retList.Add(list);
            }
        }

        return retList;
    }
}
