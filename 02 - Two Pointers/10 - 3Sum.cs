public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        // Get the array into ascending order to simplify the search later.
        Array.Sort(nums);

        var triples = new List<List<int>>();

        for (int i=0; i<nums.Length - 2; i++) {
            // For these 3 numbers to sum to 0, J and K need to sum to -I.
            int expected = -nums[i];

            // Create 2 pointers, at the first and last numbers to the right of i.
            int j = i + 1;
            int k = nums.Length - 1;
            while (j < k) {
                int sum = nums[j] + nums[k];

                // If the sum is too small, increment the left pointer to use a bigger number.
                if (sum < expected) {
                    j++;
                }

                // If the sum is too large, decrement the right pointer to use a smallernumber.
                else if (sum > expected) {
                    k--;
                }

                // Otherwise, store the triple we've found.
                else {
                    var triple = new List<int> {nums[i], nums[j], nums[k]};
                    triple.Sort();
                    triples.Add(triple);

                    // Keep going to try and find further triples.
                    j++;
                    k--;
                }
            }
        }

        // Return only distinct triples.
        var distinctTriples = triples
            .Select(t => (t[0], t[1], t[2]))
            .Distinct()
            .Select(t => new List<int> { t.Item1, t.Item2, t.Item3 })
            .ToList();

        return distinctTriples;
    }
}
