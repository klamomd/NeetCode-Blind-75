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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // END CASE: Found a node where the value is either:
        // - Equal to either P or Q, OR
        // - Greater than p and less than q, OR
        // - Less than p and greater than q

        // If the root is equal to P or Q, then we've found the lowest common ancestor.
        if (root.val == p.val || root.val == q.val) {
            return root;
        }

        bool pLessThan = p.val < root.val;
        bool qLessThan = q.val < root.val;

        // One value on either side of root indicates that we've found the lowest common ancestor.
        if (pLessThan != qLessThan) {
            return root;
        }

        // Both values on left side of root - search left child.
        if (pLessThan && qLessThan) {
            return LowestCommonAncestor(root.left, p, q);
        }

        // Both values on right side of root - search right child.
        else {
            return LowestCommonAncestor(root.right, p, q);
        }
    }
}
