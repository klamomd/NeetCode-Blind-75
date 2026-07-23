public class Solution {
    public string LongestPalindrome(string s) {
        
        string maxPalindrome = "";

        // Look for odd length palindromes.
        for (int i = 0; i < s.Length; i++) {
            int leftPtr = i - 1;
            int rightPtr = i + 1;

            while (leftPtr >= 0 && rightPtr < s.Length) {
                // Break on mismatch.
                if (s[leftPtr] != s[rightPtr]) {
                    break;
                }

                // Otherwise, continue expanding outward.
                leftPtr--;
                rightPtr++;
            }

            // After the loop breaks, we're either OOB or on the first mismatch. Shrink pointers back by one
            // to find the palindrome centered around i.
            leftPtr++;
            rightPtr--;

            int palindromeLength = rightPtr - leftPtr + 1;
            if (palindromeLength > maxPalindrome.Length) {
                maxPalindrome = s.Substring(leftPtr, palindromeLength);
            }
        }

        // Edge case check: if max palindrome was found to be s, then there is no larger palindrome.
        if (maxPalindrome == s) {
            return maxPalindrome;
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

            int leftPtr = i - 1;
            int rightPtr = j + 1;

            while (leftPtr >= 0 && rightPtr < s.Length) {
                // Break on mismatch.
                if (s[leftPtr] != s[rightPtr]) {
                    break;
                }

                // Otherwise, continue expanding outward.
                leftPtr--;
                rightPtr++;
            }

            // After the loop breaks, we're either OOB or on the first mismatch. Shrink pointers back by one to find the
            // palindrome centered around i.
            leftPtr++;
            rightPtr--;

            int palindromeLength = rightPtr - leftPtr + 1;
            if (palindromeLength > maxPalindrome.Length) {
                maxPalindrome = s.Substring(leftPtr, palindromeLength);
            }
        }

        return maxPalindrome;
    }
}
