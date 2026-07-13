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
    public bool IsValidBST(TreeNode root, int? isLessThan = null, int? isGreaterThan = null) {
        // Root value is not less than the specified value.
        if (isLessThan.HasValue && root.val >= isLessThan) {
            return false;
        }

        // Root value is not greater than the specified value.
        if (isGreaterThan.HasValue && root.val <= isGreaterThan) {
            return false;
        }

        if (root.left != null) {
            // Left node is not less than root, or is not a valid BST itself.
            if (root.left.val >= root.val || !IsValidBST(root.left, root.val, isGreaterThan)) {
                return false;
            }
        }

        if (root.right != null) {
            // Right node is not greater than root, or is not a valid BST itself.
            if (root.right.val <= root.val || !IsValidBST(root.right, isLessThan, root.val)) {
                return false;
            }
        }

        // Everything checks out!
        return true;
    }
}
