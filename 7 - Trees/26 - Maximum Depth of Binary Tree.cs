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
    public int MaxDepth(TreeNode root) {
        // EDGE CASE - empty tree.
        if (root == null) {
            return 0;
        }

        // Recurse left and right.
        int leftDepth = MaxDepth(root.left);
        int rightDepth = MaxDepth(root.right);

        // Return the maximum depth found, plus 1 for the root node.
        int maxDepthOfChildren = Math.Max(leftDepth, rightDepth);
        
        return maxDepthOfChildren + 1;
    }
}
