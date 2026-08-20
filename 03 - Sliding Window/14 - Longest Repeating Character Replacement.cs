public class Solution {
	public int CharacterReplacement(string s, int k) {
		// BASE CASE: String only has 1 character.
		if (s.Length == 1)
		{
			return 1;
		}
		
		// Sliding window pointers
		int l = 0, r = 0;
		
		// Frequency of each char in the current substring
		int[] freq = new int[26];
		
		// Best repeating char length found
		int bestLength = 0;
		
		while (r <= s.Length)
		{
			int windowSize = r - l;
			
			// Grab the count of the most frequent character.
			int mostFrequent = GetMostFrequent(freq);
			
			// Calculate current k.
			int currK = windowSize - mostFrequent;
			
			// If current k is still within the max: update the best length, add the right-most character (if not OOB), and continue.
			if (currK <= k)
			{
				bestLength = int.Max(bestLength, windowSize);
				
				// Check if the right pointer is OOB - break out if so.
				if (r == s.Length)
				{
					break;
				}
				
				// Add the right-most character to the window.
				int rightFreqIndex = GetCharIndex(s[r]);
				freq[rightFreqIndex]++;

				r++;
				continue;
			}
			
			// Otherwise: remove the left-most character from the window and continue.
			int leftFreqIndex = GetCharIndex(s[l]);
			freq[leftFreqIndex]--;
			
			// Make sure to increment left pointer.
			l++;
		}
		
		return bestLength;
	}
	
	// Given an int array representing frequency, returns the highest value in the array.
	private int GetMostFrequent(int[] freq)
	{
		int best = 0;
		
		foreach (int i in freq)
		{
			best = int.Max(best, i);
		}
		
		return best;
	}
	
	// Given an uppercase English alphabet character, returns the 0-based index of that character.
	private int GetCharIndex(char c)
	{
		return c - 'A';
	}
}
