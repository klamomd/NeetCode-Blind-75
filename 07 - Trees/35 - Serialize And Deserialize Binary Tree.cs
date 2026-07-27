/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Codec {
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        // EDGE CASE
        if (root == null) {
            return "N,";
        }

        // Simply append the root value, then the result from serializing left, then right.
        return root.val + "," + Serialize(root.left) + Serialize(root.right);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        // EDGE CASE
        if (data == "") {
            return null;
        }

        // Remove last comma, if present.
        // (Using a while loop "just in case", though there should never be a situation where 2+ commas are at the end.)
        while (data[data.Length - 1] == ',') {
            data = data.Substring(0, data.Length - 1);
        }

        // Split data on commas and feed into queue.
        Queue<string> chunkedData = new();

        foreach (var substring in data.Split(',')) {
            chunkedData.Enqueue(substring);
        }
        
        // Deserialize queue
        return Deserialize(ref chunkedData);
    }

    // Recursive deserialize function. Queue is passed by reference, since we want to persist changes made during each recurse
    // (each recurse will pop off and act on the first chunk).
    private TreeNode Deserialize(ref Queue<string> chunkedData) {
        // EDGE CASE
        if (chunkedData.Count == 0) {
            return null;
        }

        // Pull first chunk.
        string currentChunk = chunkedData.Dequeue();

        // No node here, return null.
        if (currentChunk == "N") {
            return null;
        }

        // NOTE: This assumes that all chunks will be valid integers. Add actual error checking if used elsewhere.
        var root = new TreeNode(int.Parse(currentChunk));

        // Build left tree.
        root.left = Deserialize(ref chunkedData);
        
        // Build right tree.
        root.right = Deserialize(ref chunkedData);
        
        return root;     
    }
}
