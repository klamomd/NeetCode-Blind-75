// Not sure if I implemented this quite right, but it works!

public class WordDictionary {
	Node root = new Node(' ');

	public WordDictionary() { }
	
	// Adds the string `word` into the prefix tree.
	public void AddWord(string word) {
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
	
	// Returns true if the string word is in the prefix tree (i.e., was inserted before), otherwise false.
	// Any '.' in the word will match any letter.
	public bool Search(string word) {
		var searchQuery = word.AsSpan();
		return root.Search(searchQuery);
	}
}

public class Node {
	public Dictionary<char, Node> Children = new Dictionary<char, Node>();
	public bool IsCompleteWord = false;
	public char NodeChar;

	public Node(char c) {
		NodeChar = c;
	}

	public bool Search(ReadOnlySpan<char> word)
	{
		// BASE CASE - Empty word - check for completed flag
		if (word.IsEmpty)
		{
			return IsCompleteWord;
		}
		
		char firstChar = word[0];
		
		// EXACT MATCH - First char of word is not a '.', so look for a child which matches this char and search its children for the rest of the word.
		if (firstChar != '.')
		{
			// No matching child
			if (!Children.ContainsKey(firstChar))
			{
				return false;
			}
			
			// Recurse search on the matching child.
			return Children[firstChar].Search(word[1..]);
		}
		
		// ANY MATCH - First char of word is a '.', so search all of the children for a matching word.
		foreach (char key in Children.Keys)
		{
			if (Children[key].Search(word[1..]))
			{
				return true;
			}
		}
		
		// No match found.
		return false;
	}
}
