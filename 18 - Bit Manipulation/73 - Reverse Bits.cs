public class Solution {
    public uint ReverseBits(uint n) {
        uint reverse = 0;

        for (int i=0; i<32; i++) {
            uint mask = ((uint) 1) << i;
            uint reverseMask = ((uint) 1) << (31 - i);

            bool isBitSet = (mask & n) > 0;

            // If the current bit is set, update the corresponding bit in the result.
            if (isBitSet) {
                reverse = reverse | reverseMask;
            }
        }

        return reverse;    
    }
}
