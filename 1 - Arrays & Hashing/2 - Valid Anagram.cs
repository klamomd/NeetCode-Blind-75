public class Solution {
    public bool IsAnagram(string s, string t) {
        var sChars = new int[26];

        // Count up # of each char in s.
        foreach (char c in s) {
            int index = CharToIndex(c);
            sChars[index]++;
        }

        foreach (char c in t) {
            int index = CharToIndex(c);

            // More of this char in t than in s.
            if (sChars[index] == 0) {
                return false;
            }

            // Decrement char count.
            sChars[index]--;
        }

        // Final check for any chars in s that aren't in t.
        for (int i = 0; i < 26; i++) {
            if (sChars[i] != 0) {
                return false;
            }
        }

        return true;
    }

    // Returns a 0-based index for the given char (ex: 'a': 0, 'z': 25).
    // Assumes that all passed chars are lowercase English letters.
    public int CharToIndex(char c) {
        return (int)(c - 'a');
    }


    /*
    // First attempt - not efficient:

    public bool IsAnagram(string s, string t) {
        var sChars = new Dictionary<char, int>();

        foreach (char c in s) {
            if (sChars.ContainsKey(c))
                sChars[c]++;
            else
                sChars[c] = 1;
        }

        foreach (char c in t) {
            if (!sChars.ContainsKey(c))
                return false;

            sChars[c]--;

            if (sChars[c] <= 0)
                sChars.Remove(c);
        }

        return sChars.Count == 0;
    }
    */
}
