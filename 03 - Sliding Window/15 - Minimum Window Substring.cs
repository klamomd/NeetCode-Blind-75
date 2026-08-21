public class Solution {
	public string MinWindow(string s, string t) {
		// EDGE CASE: t has only 1 character.
		if (t.Length == 1)
		{
			return s.Contains(t[0]) ? t : "";
		}
		
		// Minimum window substring found.
		ReadOnlySpan<char> minString = ReadOnlySpan<char>.Empty;
		
		// ReadOnlySpan of s, to make grabbing substrings more efficient (for test cases with huge strings).
		ReadOnlySpan<char> sSpan = s.AsSpan();
		
		// Number of characters left to find in s.
		int charsLeft = t.Length;

		// Left and right pointers.		
		int l = 0, r = 0;
		
		// Maps every character in 't' to its remaining count.
		Dictionary<char, int> remaining = t
			.GroupBy(c => c)
			.ToDictionary(g => g.Key, g => g.Count());
		
		// Increment left pointer until we find the first character from T.
		while (l < sSpan.Length)
		{
			if (remaining.ContainsKey(s[l]))
			{
				break;
			}
			
			l++;
		}
		
		// EDGE CASE: If left pointer is now OOB, there are no characters from T in S.
		if (l >= sSpan.Length)
		{
			return "";
		}
		
		// Update right pointer to match left pointer.
		r = l;
		
		// Loop until R falls OOB.
		while (l < sSpan.Length && r < sSpan.Length)
		{
			// GROW:
			while (r < sSpan.Length && charsLeft > 0)
			{
				// Matching character found at R.
				if (remaining.ContainsKey(s[r]))
				{
					// Update remaining count.
					remaining[s[r]]--;
					
					// If this was not a redundant char (count did not go below 0), then update the number of remaining chars too.
					if (remaining[s[r]] >= 0) {
						charsLeft--;
					}
				}

				// If the number of remaining chars reaches 0, we have found a substring containing all chars in T.
				if (charsLeft == 0) {
					// Update best if appropriate.
					int currentLength = r - l + 1;
					if (minString.IsEmpty || currentLength < minString.Length)
					{
						minString = sSpan.Slice(l, currentLength);
					}
					
					// Break out of the "grow" loop.
					break;
				}
				
				// Increment R.
				r++;
			}
			
			// If R fell OOB, then the current substring does not contain all chars in T, and we can skip the "shrink" loop.
			if (r >= sSpan.Length)
			{
				break;
			}
				
			// SHRINK:
			while (l < sSpan.Length && charsLeft == 0) {
				// Remove the character at L from the substring.
				// If the character exists in T, update the remaining count.
				if (remaining.ContainsKey(s[l])) {
					remaining[s[l]]++;
					
					// If this was not a redundant char (remaining count is now > 0), then increment the number of chars we have left to find.
					if (remaining[s[l]] > 0) {
						charsLeft++;
					}
				}
				
				// Increment L.
				l++;
				
				// If the number of chars we have left to find is still 0, then this is still a substring containing all chars in T.
				if (charsLeft == 0) {
					// Update best if appropriate.
					int currentLength = r - l + 1;
					if (minString.IsEmpty || currentLength < minString.Length)
					{
						minString = sSpan.Slice(l, currentLength);
					}
				}
			}
				
			// Increment R, to avoid reprocessing the right-most character if/when we enter the "grow" loop again.
			r++;
		}
		
		return minString.IsEmpty ? "" : minString.ToString();
	}
}
