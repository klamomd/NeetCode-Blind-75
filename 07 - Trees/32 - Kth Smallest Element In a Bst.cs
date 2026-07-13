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

public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        var traversed = new List<int>();
        return InOrderTraversal(root, k, ref traversed);
    }

    // Traverse the tree in-order and build up a list of the smallest elements.
    // Once the list has length k, return the last element.
    public int InOrderTraversal(TreeNode root, int k, ref List<int> traversed) {
        // Null root - return immediately.
        if (root == null) {
            return -1;
        }

        // Traverse left side.
        int result = InOrderTraversal(root.left, k, ref traversed);
        
        // If a result was found, return that.
        if (result != -1) {
            return result;
        }
        
        // Add root to list.
        traversed.Add(root.val);

        // If we already have k elements, return the kth element (adjusted to k-1 due to one-indexing).
        if (traversed.Count >= k) {
            return traversed[k-1];
        }

        // Otherwise, traverse right.
        result = InOrderTraversal(root.right, k, ref traversed);

        // If a result was found, return that.
        if (result != -1) {
            return result;
        }

        // If we now have k elements, return the kth element (adjusted to k-1 due to one-indexing).
        if (traversed.Count >= k) {
            return traversed[k-1];
        }

        // Return -1 if no result found this time.
        return -1;
    }
}
