public class Solution {
    public int NumDecodings(string s) {
        int decodings;
        if (TryGetNumDecodings(s, out decodings)) {
            return decodings;
        }

        return 0;
    }

    // Recursive function.
    // Returns a bool indicating whether the string is valid.
    // Out parameter contains the number of decodings, if valid.
    public bool TryGetNumDecodings(string s, out int decodings) {
        decodings = 0;

        // Edge case - empty string. Return true, so as not to confuse recursive function.
        if (s.Length == 0) {
            decodings = 1;

            return true;
        }

        // Edge case - only 1 char.
        if (s.Length == 1) {
            decodings = 1;

            // Only return true if we don't start with 0.
            return s[0] != '0';
        }

        /*
            If string starts with 0:
                - Return false - no possible decodings.
            If string starts with 1:
                - decodings = TryGetNumDecodings(s[1..]) + TryGetNumDecodings(s[2..]) [or 0 for either if not true]
            If string starts with 2:
                - If next digit is 0-6, then decodings is calculated the same as above.
                - Otherwise, decodings is calculated the same as below.
            If string starts with 3-9:
                - decodings = TryGetNumDecodings(s[1..]);
        */
        switch (s[0]) {
            // If string starts with 0, then it has no decodings, as it cannot start with 0.
            case '0':
                return false;

            case '1':
                int leftDecodings;
                int rightDecodings;

                // Get the number of decodings for the substring with 1 fewer chars.
                if (!TryGetNumDecodings(s.Substring(1), out leftDecodings)) {
                    leftDecodings = 0;
                }

                // If we have more than 2 characters, also get the number of decodings for the substring with 2 fewer chars.
                if (!TryGetNumDecodings(s.Substring(2), out rightDecodings)) {
                    rightDecodings = 0;
                }
               
                // Add the number of decodings, set the out var, and return true.
                decodings = leftDecodings + rightDecodings;
                return true;

            /*
                If string starts with 2:
                    - If next digit is 0-6, then handle it the same as if string starts with 1.
                    - Otherwise, handle it the same as if string starts with 3-9.
            */
            case '2':
                // Next digit is 0-6.
                if (s[1] <= '6') {
                    goto case '1';
                }
                // Next digit is 7-9.
                else {
                    goto default;
                }

            // If string starts with 3-9, decodings = TryGetNumDecodings(s[1..])
            default:
                int substringDecodings;
                // If substrings don't contain a valid decoding, then neither does the full string.
                if (!TryGetNumDecodings(s.Substring(1), out substringDecodings)) {
                    return false;
                }

                // Otherwise, the full string has the same number of decodings as the substring.
                decodings = substringDecodings;
                return true;
        }
    }
}
