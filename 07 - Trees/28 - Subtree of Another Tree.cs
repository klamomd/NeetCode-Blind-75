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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        bool rootIsNull = root == null;
        bool subRootIsNull = subRoot == null;

        // Both roots are null.
        if (rootIsNull && subRootIsNull) {
            return true;
        }

        // Only one root is null.
        if (rootIsNull != subRootIsNull) {
            return false;
        }

        // Root value matches subroot value. Dig deeper to check that all child nodes match.
        if (root.val == subRoot.val) {
            if (IsSameTree(root, subRoot)) {
                return true;
            }
        }

        // If we reach here, then either the values mismatched, or the root's children did not match the subroot's
        // children. Continue checking all child nodes until the tree is exhausted.
        return (IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot));
    }

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
