public class Solution {
    public string Encode(IList<string> strs) {
        // Base case - nothing to encode.
        if (strs.Count == 0)
            return null;

        var encoded = new StringBuilder("");

        // Encode and append each individual string, with semicolon delimiter.
        for (int i = 0; i < strs.Count; i++) {
            var s = strs[i];
            
            encoded.Append(EncodeIndividualString(s));

            // Append a semicolon, if we're not on the last string.
            if (i != strs.Count - 1) {
                encoded.Append(";");
            }
        }

        return encoded.ToString();
    }

    // Encodes a string by replacing each char with its integer value, with each value delimited by a comma.
    public string EncodeIndividualString(string s) {
        var encoded = new StringBuilder("");

        for (int i = 0; i < s.Length; i++) {
            // Convert and append character.
            char c = s[i];
            encoded.Append(((int)c).ToString());

            // Append a comma, if we're not on the last character.
            if (i != s.Length - 1) {
                encoded.Append(",");
            }
        }

        return encoded.ToString();
    }

    public List<string> Decode(string s) {
        // Base case - nothing to decode.
        if (s == null)
            return new List<string>();

        // Split the string on its delimiter (semicolon), decode each value, and then combine the results into a list.
        var result = s.Split(';').Select(str => DecodeIndividualString(str)).ToList();

        return result;
    }

    public string DecodeIndividualString(string str) {
        // Split out int strings.
        var intStrings = str.Split(',').ToList();

        var decoded = new StringBuilder("");

        foreach (string s in intStrings) {
            // Skip any empty strings to avoid parse failures.
            if (s == "") {
                continue;
            }

            // Parse the integer, convert it to a character, and append it to the decoded string.
            int i = int.Parse(s);
            decoded.Append((char)i);
        }

        return decoded.ToString();
    }
}
