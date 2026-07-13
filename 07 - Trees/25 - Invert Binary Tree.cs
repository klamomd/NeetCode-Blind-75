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
    public TreeNode InvertTree(TreeNode root) {
        // EDGE CASE - Empty tree.
        if (root == null) {
            return root;
        }

        // Swap left and right children.
        var swap = root.left;
        root.left = root.right;
        root.right = swap;

        // Recurse left + right.
        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }
}
