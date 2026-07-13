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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        bool pIsNull = p == null;
        bool qIsNull = q == null;
        
        // Only 1 root is null.
        if (pIsNull != qIsNull) {
            return false;
        }

        // Both roots are null.
        if (pIsNull) {
            return true;
        }

        // Both roots not null, but value mismatch.
        if (p.val != q.val) {
            return false;
        }

        // Recurse left and right.
        return (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
    }
}
