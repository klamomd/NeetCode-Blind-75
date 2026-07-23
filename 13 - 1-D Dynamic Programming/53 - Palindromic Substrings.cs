public class Solution {
    public int CountSubstrings(string s) {
        int palindromeCount = 0;

        // Look for odd length palindromes.
        for (int i = 0; i < s.Length; i++) {
            int leftPtr = i;
            int rightPtr = i;

            while (leftPtr >= 0 && rightPtr < s.Length) {
                // Break on mismatch.
                if (s[leftPtr] != s[rightPtr]) {
                    break;
                }

                // Otherwise, we found a valid palindrome, so update the count.
                palindromeCount++;

                // Continue expanding outward.
                leftPtr--;
                rightPtr++;
            }
        }

        // Look for even length palindromes.
        for (int i = 0; i < s.Length; i++) {
            // Index for the second center character.
            int j = i + 1;

            // OOB check - make sure j is within the string.
            if (j >= s.Length) {
                break;
            }

            // Only continue if both center characters match.
            if (s[i] != s[j]) {
                continue;
            }

            int leftPtr = i;
            int rightPtr = j;

            while (leftPtr >= 0 && rightPtr < s.Length) {
                // Break on mismatch.
                if (s[leftPtr] != s[rightPtr]) {
                    break;
                }

                // Otherwise, we found a valid palindrome, so update the count.
                palindromeCount++;

                // Continue expanding outward.
                leftPtr--;
                rightPtr++;
            }
        }

        return palindromeCount;
    }
}
