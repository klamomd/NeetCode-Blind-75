public class Solution {
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
