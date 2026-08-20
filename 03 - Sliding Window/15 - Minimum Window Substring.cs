public class Solution {
	public string MinWindow(string s, string t) {
		// EDGE CASE: t has only 1 character.
		if (t.Length == 1)
		{
			return s.Contains(t[0]) ? t : "";
		}
		
		// I'm using both an int and string to track minimum substring because I want the default value to be an empty string without screwing up the math when checking if the first substring is better than the current minimum.
		int bestMinimum = int.MaxValue;
		string minString = "";
		
		// Number of characters left to find in s.
		int charsLeft = t.Length;

		// Left and right pointers.		
		int l = 0, r = 0;
		
		// Maps every character in 't' to its remaining count.
		Dictionary<char, int> remaining = t
			.GroupBy(c => c)
			.ToDictionary(g => g.Key, g => g.Count());
		
		// Loop while the left pointer is still in bounds.
		while (l < s.Length) {
			while (l < s.Length) {
				// Increment L until we find a char from t.
				if (remaining.ContainsKey(s[l])) {
					break;
				}
				
				l++;
			}
				
			/* {
				// TODO - Should the block of code below be done in the R loop?
				// TODO - Should the block of code below be done in the R loop?
				// TODO - Should the block of code below be done in the R loop?
				
					// SANITY CHECK: Make sure remaining count of s[l] is > 0?
					// 		Does it even matter? If t is "XXY" and S is "XXXXXXXXY", it doesn't matter that we've found too many Xs before we found a Y. (We'll find the shorter substring once we shrink L).
					
					// Add the current character to our window. Reduce the remaining count by 1, and decrement the number of chars left.
					
					remaining[s[l]]--;
					// remaining[s[l]] -= 1; ?
						
					charsLeft--;
					
					break;
			} */
			
			// If left pointer has gone past right, then reset right pointer.
			if (l > r)
			{
				// DEBUG:
				Console.WriteLine($"SANITY CHECK: left pointer ({l}) has exceeded right pointer ({r})!");
				
				r = l;
				// TODO - Will this break any math? Is there any situation where this will occur outside of the first iteration?
			}
			
			// TODO - R OOB reset?
			/*
				If t is "XXY" and S is "XXXXXXXXY", R will fall OOB but we will need to keep shrinking until L is pointing to -3!
			
			*/
			
			
			while (r < s.Length)
			{
				// Increment R until we find a char from t.
				if (!remaining.ContainsKey(s[r])) {
					r++;
					continue;
				}
				
				
				// TODO - SAME BUG AS BEFORE - DOUBLE-DIPPING HERE AFTER SHRINKING LEFT!
				// TODO - SAME BUG AS BEFORE - DOUBLE-DIPPING HERE AFTER SHRINKING LEFT!
				// TODO - SAME BUG AS BEFORE - DOUBLE-DIPPING HERE AFTER SHRINKING LEFT!:
				
				// Update the count for this character.
				remaining[s[r]]--;
				
				// If the character's count fell below 0, then it can still be part of our current window as a redundant character, but we'll do no further processing apart from incrementing the right pointer.
				if (remaining[s[r]] < 0) {
					r++;
					continue;
				}
				
				// Otherwise, decrement the number of chars left to find.
				charsLeft--;
				
				// If the number of chars to find has reached 0, then we've found all the chars in t.
				if (charsLeft == 0) {
					int currentLength = r - l + 1;

					// Update the best minimum substring if appropriate.					
					if (currentLength < bestMinimum) {
						// TODO - DELETE - Using Java-style substring:
						// minString = s.Substring(l, r + 1);
						minString = s.Substring(l, currentLength);
						bestMinimum = currentLength;
					}
					
					// Break out of the right pointer loop.
					break;
				}
				
				// Increment the right pointer.
				r++;
			}
			
			// Remove the left-most character from our window before resuming the left pointer loop.
			remaining[s[l]]++;

			// If this wasn't a redundant character (i.e. if the remaining number of this character is now > 0), also increment the number of chars left to find.
			if (remaining[s[l]] > 0)
			{
				charsLeft++;
			}
			
			// Finally, increment the left pointer.
			l++;
			
			// TODO - LAZY FIX FOR DOUBLE-DIPPING BUG - BETTER SOLUTION???
			// TODO - LAZY FIX FOR DOUBLE-DIPPING BUG - BETTER SOLUTION???
			// TODO - LAZY FIX FOR DOUBLE-DIPPING BUG - BETTER SOLUTION???
			// Remove the right-most character from our window to make sure we don't include it twice (if it is not OOB).
			if (r < s.Length)
			{
				remaining[s[r]]--;
				charsLeft++;	
			}
			
			// TODO - Can we just kick out if R is OOB?
			// TODO - Can we just kick out if R is OOB?
			// TODO - Can we just kick out if R is OOB?
		}
		
		// Return the minimum string found.
		return minString;
		
		/*
			Planning
			
			Convert T to a dictionary mapping char to remaining count
			
			Keep track of charsLeft ("tLength")
			
			
			while (L < OOB) {
				while (L < OOB) {
				
				
					// LEFTOFF - SECOND LOOP ITERATION
					// LEFTOFF - 
					// LEFTOFF - Need to update left loop to "add back" any characters that fall out of the window as we increment left pointer!!
					
					
					// ^^^^^^^^^^^^^^^^^
					// ^^^^^^^^^^^^^^^^^
					// ^^^^^^^^^^^^^^^^^
					// ^^^^^^^^^^^^^^^^^
					
					
					
				
					// Increment L until we find the first matching char (char exists as a key in $remaining)
					if (!remaining.ContainsKey(s[l])) {
						l++;
						continue;
					}
					
					
					
					// TODO - Should the block of code below be done in the R loop?
					// TODO - Should the block of code below be done in the R loop?
					// TODO - Should the block of code below be done in the R loop?
					
						// SANITY CHECK: Make sure remaining count of s[l] is > 0?
						// 		Does it even matter? If t is "XXY" and S is "XXXXXXXXY", it doesn't matter that we've found too many Xs before we found a Y. (We'll find the shorter substring once we shrink L).
						
						// Add the current character to our window. Reduce the remaining count by 1, and decrement the number of chars left.
						
						remaining[s[l]]--;
						// remaining[s[l]] -= 1; ?
							
						charsLeft--;
						
						break;
				}
				
				// SANITY CHECK: If r is before L, then set r to L!
				// SANITY CHECK: If r is before L, then set r to L!
				// SANITY CHECK: If r is before L, then set r to L!
				
				
				// LEFTOFF - Got confused about left / right pointer order and process...
				
				
				while (R < OOB) {
					// Increment R until we find a matching char (char exists as a key in $remaining).
					if (!remaining.ContainsKey(s[r])) {
						r++;
						continue;
					}
					
					// Update the count for this character.
					remaining[s[r]]--;
					
					// If the character's count fell below 0, then it can still be part of our current window, but we'll do no further processing.
					if (remaining[s[r]] < 0) {
						continue;
					}
					
					// Otherwise, decrement the number of chars left.
					charsLeft--;
					
					// If the number of chars has reached 0, then we've found all the chars in $t.
					if (charsLeft == 0) {
						// Update the minimum substring if appropriate.
						int currentLength = r - l + 1;
						
						if (currentLength < bestMinimum) {
							minString = s.Substring(l, r + 1);
						}
						
						// Break out of the right pointer loop.
						break;
					}
				}
				
				
				// Remove the left-most character from the window.
				remaining[s[l]]++;
				charsLeft++;
				l++;
			}
			
			return best;
		*/
	}
}
