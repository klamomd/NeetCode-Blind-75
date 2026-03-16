public class Solution {
    public int LongestConsecutive(int[] nums) {
        // Remove duplicates and sort list.
        List<int> sorted = nums.Distinct().ToList();
        sorted.Sort();

        // EDGE CASE - Arrays of size 0 or 1 will only have 0 or 1 consecutive numbers, respectively.
        if (sorted.Count <= 1) {
            return sorted.Count;
        }

        int expected = sorted[0];
        int ctr = 0;
        int max = 0;
        
        int i = 0;

        do {
            // Grab number and increment i afterwards.
            int curr = sorted[i++];

            // Matches expected number, so sequence continues.
            if (curr == expected) {
                ctr++;
                expected++;
            }

            // Break in sequence, so reset.
            else {
                // First, determine if the last sequence was longer than our current max. Update if so.
                if (ctr > max) {
                    max = ctr;
                }

                // Reset ctr to 1 (to include the current number) and expected (to the current number + 1);
                ctr = 1;
                expected = curr + 1;
            }

        } while (i < sorted.Count);

        // One final check for if we beat the current max, in case the longest sequence is at the end.
        if (ctr > max) {
            max = ctr;
        }

        return max;
    }
}
