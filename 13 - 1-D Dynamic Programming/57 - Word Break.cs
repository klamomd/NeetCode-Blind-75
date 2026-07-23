public class Solution {
    // Wrapper function - ensures wordDict is sorted by length (desc) before calling the recursive function.
    public bool WordBreak(string s, List<string> wordDict) {
        wordDict = wordDict.OrderByDescending(word => word.Length).ToList();

        return WordBreakRecurse(s, wordDict);
    }

    HashSet<string> badResults = new HashSet<string>();

    private bool WordBreakRecurse(string s, List<string> wordDict) {
        // If we've already found that this string cannot be broken down, then return false immediately.
        if (badResults.Contains(s)) {
            return false;
        }

        // Foreach word in wordDict, try to pare off that word from s, and then recurse.
        foreach (string word in wordDict) {
            // If the string doesn't start with this word, then continue to the next one.
            if (!s.StartsWith(word)) {
                continue;
            }

            // BASE CASE: s is equal to the current word.
            if (s == word) {
                return true;
            }

            // Pare off the current word, and recurse.
            string substring = s.Substring(word.Length);

            // Successful recursion, return true.
            if (WordBreak(substring, wordDict)) {
                return true;
            }
        }

        // Cache the fact that we can't break down this word.
        badResults.Add(s);

        return false;
    }
}
