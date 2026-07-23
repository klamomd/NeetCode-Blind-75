public class PrefixTree {
    Node root = new Node(' ');

    public PrefixTree() { }
    
    // Inserts the string `word` into the prefix tree.
    public void Insert(string word) {
        // Pointer the the current node.
        var curr = root;

        for (int i=0; i<word.Length; i++) {
            char c = word[i];

            // Create a new child for this character, if needed.
            if (!curr.Children.ContainsKey(c)) {
                curr.Children[c] = new Node(c);
            }

            // Update the current node.
            curr = curr.Children[c];

            // If we're at the end of the word, set the "IsCompleteWord" flag on the node.
            if (i == word.Length - 1) {
                curr.IsCompleteWord = true;
            }
        }
    }
    
    /*
       TODO - "Search" and "StartsWith" are similar enough that they could be combined into a single function.
       
       Simply use a boolean parameter to indicate which type of lookup we're doing, and modify the behavior at
       2 points based on that boolean:
        - When at the end of `word`, to determine whether we need to check / return the "IsCompleteWord" flag.
        - When at the very end of the function, to determine what to return.
    */
    // Returns true if the string word is in the prefix tree (i.e., was inserted before), otherwise false.
    public bool Search(string word) {
        var curr = root;

        int charPtr = 0;
        while (charPtr < word.Length) {
            char c = word[charPtr];

            // If there is no child for the current character, the word doesn't exist.
            if (!curr.Children.ContainsKey(c)) {
                return false;
            }

            // Update the current node.
            curr = curr.Children[c];

            // If we're at the end of the word, check the "IsCompleteWord" flag.
            if (charPtr == word.Length - 1) {
                return curr.IsCompleteWord;
            }

            // Don't forget to increment!
            charPtr++;
        }

        // We shouldn't ever get here, but return false if we do.
        return false;
    }
    

    public bool StartsWith(string prefix) {
        var curr = root;

        int charPtr = 0;
        while (charPtr < prefix.Length) {
            char c = prefix[charPtr];

            // If there is no child for the current character, the word doesn't exist.
            if (!curr.Children.ContainsKey(c)) {
                return false;
            }

            // Update the current node.
            curr = curr.Children[c];

            // Don't forget to increment!
            charPtr++;
        }

        // If we did not hit a case where a node had no matching children, then we should have found a valid prefix.
        return true;
    }
}

public class Node {
    public Dictionary<char, Node> Children = new Dictionary<char, Node>();
    public bool IsCompleteWord = false;
    public char NodeChar;

    public Node(char c) {
        NodeChar = c;
    }
}
