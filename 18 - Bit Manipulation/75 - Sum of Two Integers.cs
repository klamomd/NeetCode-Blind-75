public class Solution {
	public int GetSum(int a, int b) {
		int carry = 0;
		int result = 0;

		for (int i=0; i<32; i++) {
			int aBit = (a >> i) & 1;
			int bBit = (b >> i) & 1;
			
			// Calculate current bit.
			int currentBit = aBit ^ bBit ^ carry;
			
			// Update carry.
			if ((aBit + bBit + carry) >= 2)
			{
				carry = 1;
			}
			else
			{
				carry = 0;
			}
			
			// Set result bit.
			if (currentBit != 0) {
				result |= 1 << i;
			}
		}
		
		return result;
	}
}
