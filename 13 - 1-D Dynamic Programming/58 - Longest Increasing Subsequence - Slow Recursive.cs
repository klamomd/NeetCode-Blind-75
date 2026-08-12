public class Solution {
	private Dictionary<(int, int), int> indexToLISCache = [];

	public int LengthOfLIS(int[] nums, int i = 0, int j = -1) {
		// BASE CASE: out of nums to check
		if (i >= nums.Length)
		{
			return 0;
		}
		
		// Check cache for existing result.
		if (indexToLISCache.ContainsKey((i, j)))
		{
			return indexToLISCache[(i, j)];
		}
		
		// "Take current element"
		int takeResult = 0;

		// Recurse only when first starting a sequence, or when we find an increasing element.
		if (j == -1 || nums[i] > nums[j])
		{
			takeResult = 1 + LengthOfLIS(nums, i + 1, i);
		}
		
		// "Skip current element"
		int skipResult = LengthOfLIS(nums, i + 1, j);
		
		// Pick the best option.
		int best = Math.Max(takeResult, skipResult);
		
		// Update cache.
		indexToLISCache[(i, j)] = best;
		
		return best;
	}
}