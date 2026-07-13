public class Solution {
    public bool IsPalindrome(string s) {
        s = StandardizeString(s);

        int left = 0, right = s.Length - 1;

        while (left <= right) {
            if (s[left] != s[right]) {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    // Convert string to alphanumeric, removing whitespace / special chars, and setting all chars to same case.
    public string StandardizeString(string s) {
        var sb = new StringBuilder("");

        foreach (char c in s) {
            // Ignore non-alphanumeric characters.
            if (!char.IsLetterOrDigit(c)) {
                continue;
            }

            sb.Append(char.ToLower(c));
        }

        return sb.ToString();
    }
}
