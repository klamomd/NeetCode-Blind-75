public class Solution {
    // No, this isn't very efficient, and I don't care to make it more efficient ATM ¯\_(ツ)_/¯
    public int[] CountBits(int n) {
        int[] ret = new int[n+1];

        // Iterate through each number 0..n, grab its HammingWeight, and store it in the return array.
        for (uint i = 0; i < n+1; i++) {
            ret[i] = HammingWeight(i);
        }

        return ret;
    }

    // Copied from my solution for "Number of 1 Bits" problem.
    public int HammingWeight(uint n) {
        int ctr = 0;

        uint mask = 1;
        for (int i=0; i<32; i++) {
            // Increment counter if the mask finds a `1` at position `i`.
            if ((n & mask) > 0)
                ctr++;

            // Leftshift the mask by 1, to align with the next position.
            mask = mask << 1;
        }

        // Return the number of `1`s we found.
        return ctr;
    }
}
