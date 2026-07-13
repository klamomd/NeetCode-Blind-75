public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int length = s.Length;
        if (length <= 1) {
            return length;
        }

        int l = 0;
        int r = 1;

        var chars = new HashSet<char>();
        chars.Add(s[l]);

        int longest = 1;
        while (r < length) {
            char curr = s[r];
            if (chars.Contains(curr)) {
                // First check whether our existing substring beat our longest one, and update if so.
                if (chars.Count > longest) {
                    longest = chars.Count;
                }

                // Remove letters from the front of the window until we stop seeing duplicates.
                while (chars.Contains(curr)) {
                    chars.Remove(s[l]);
                    l++;
                }
            }

            // Add the current character and slide right.
            chars.Add(curr);
            r++;
        }

        // Final check for whether our current substring beat our longest one.
        if (chars.Count > longest) {
            longest = chars.Count;
        }

        return longest;
    }
}
