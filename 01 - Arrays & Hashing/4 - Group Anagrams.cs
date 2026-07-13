public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        // Map a key string to the list of strings that share that same key.
        // A string's key is an int[26] containing the count of each character in that string, joined to a string with ','.
        var anagrams = new Dictionary<string, List<string>>();

        foreach (string s in strs) {
            int[] key = new int[26];

            foreach (char c in s) {
                // Determine character's index, then increment that character's count.
                int charIndex = GetCharIndex(c);
                key[charIndex]++;
            }

            // Join key into a string.
            string keyString = string.Join(',', key);

            // Update anagrams dictionary.
            if (!anagrams.ContainsKey(keyString))
                anagrams.Add(keyString, new List<string> { s });
            else
                anagrams[keyString].Add(s);
        }
        
        // Bunch all dictionary values into a single List of Lists (to match return type), and return that.
        var result = new List<List<string>>();
        foreach (var key in anagrams.Keys) {
            result.Add(anagrams[key]);
        }

        return result;
    }

    // Subtract 'a' from the character to get a 0-based index for that char. (Ex: 'a' = 0, 'z' = 25)
    private int GetCharIndex(char c) {
        return c - 'a';
    }
}