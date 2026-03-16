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

    // ASSUMPTION: All numbers are distinct!

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        // EDGE CASE: Empty tree.
        if (preorder.Length == 0) {
            return null;
        }

        // Get value of root (first element in PO)
        int rootVal = preorder[0];

        // Get index of root in IO array
        int rootIndexIO = Array.IndexOf(inorder, rootVal);

        // DEBUG: Sanity check.
        if (rootIndexIO == -1) {
            throw new Exception($"{nameof(rootIndexIO)} was -1!");
        }
        
        // Split off left IO subtree.
        int[] leftSubTreeIO = inorder.Take(rootIndexIO).ToArray();
        int leftCount = leftSubTreeIO.Length;

        // Split off right IO subtree.
        int[] rightSubTreeIO = inorder.Skip(rootIndexIO + 1).ToArray();
        int rightCount = rightSubTreeIO.Length;
        
        // Split off left PO subtree.
        int[] leftSubTreePO = preorder.Skip(1).Take(leftCount).ToArray();

        // Split off right PO subtree.
        int[] rightSubTreePO = preorder.Skip(1 + leftCount).ToArray();

        // Build left node.
        TreeNode left = BuildTree(leftSubTreePO, leftSubTreeIO);

        // Build right node.
        TreeNode right = BuildTree(rightSubTreePO, rightSubTreeIO);

        // Build + return root node.
        return new TreeNode(rootVal, left, right);
    }
}
