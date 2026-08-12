public class Solution {
	// Dictionary to cache any results already calculated.
	// Takes the pointers for the first char in "text1" and "text2" (in that order) as a tuple for the key.
	Dictionary<(int ptr1, int ptr2), int> cache;
	
	public int LongestCommonSubsequence(string text1, string text2)
	{
		// Reset cache.
		cache = new();
		
		return LongestCommonSubsequenceRecurse(text1.AsSpan(), text2.AsSpan(), 0, 0);
	}
	
	// Takes both strings (as readonly spans to avoid reallocation), and a pointer representing the start of each string.
	private int LongestCommonSubsequenceRecurse(ReadOnlySpan<char> text1, ReadOnlySpan<char> text2, int ptr1, int ptr2) {
		// BASE CASE - One or both strings are empty - return 0
		if (ptr1 >= text1.Length || ptr2 >= text2.Length)
		{
			return 0;
		}
		
		// Check for cached result, and return it if available.
		if (cache.TryGetValue((ptr1, ptr2), out int cachedValue))
		{
			return cachedValue;
		}
		
		// If the first character is the same, pare it off and recurse on the substrings.
		if (text1[ptr1] == text2[ptr2])
		{
			// Increment pointers and recurse. Add 1 to the result to account for the current character.
			int result = LongestCommonSubsequenceRecurse(text1, text2, ptr1 + 1, ptr2 + 1);
			result += 1;
			
			// Update cache.
			cache[(ptr1, ptr2)] = result;
			
			return result;
		}
		
		// If the first characters do not match, remove the first character from one string and recurse. Repeat for the other string.
		int left = LongestCommonSubsequenceRecurse(text1, text2, ptr1 + 1, ptr2);
		int right = LongestCommonSubsequenceRecurse(text1, text2, ptr1, ptr2 + 1);
		
		// Find the best result.
		int best = Math.Max(left, right);
		
		// Update cache.
		cache[(ptr1, ptr2)] = best;
		
		return best;
	}
}