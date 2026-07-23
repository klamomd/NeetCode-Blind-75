public class Solution {
    // This makes use of the fact that XORing the same number twice will result in `0`.
    public int MissingNumber(int[] nums) {
        int n = nums.Length;

        int mask = 0;

        // XOR the mask with all digits from 0 to n.
        for (int i=0; i<=n; i++) {
            mask ^= i;
        }

        // XOR the mask with all digits in `nums`.
        foreach (int i in nums) {
            mask ^= i;
        }

        // The missing number remains in the mask.
        return mask;
    }
}
