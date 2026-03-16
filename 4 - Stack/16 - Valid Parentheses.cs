public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        foreach (char c in s) {
            switch (c) {
                case ')':
                    if (!PopStack('(', ref stack)) {
                        return false;
                    }
                    break;
                case '}':
                    if (!PopStack('{', ref stack)) {
                        return false;
                    }
                    break;
                case ']':
                    if (!PopStack('[', ref stack)) {
                        return false;
                    }
                    break;
                case '(':
                case '{':
                case '[':
                    stack.Push(c);
                    break;
                default:
                    // This case should never be hit.
                    return false;
            }
        }

        return stack.Count == 0;
    }

    // Returns true if the expected char was found, otherwise false.
    private bool PopStack(char expected, ref Stack<char> stack) {
        if (stack.Count == 0) {
            return false;
        }

        char c = stack.Pop();

        return c == expected;
    }
}
