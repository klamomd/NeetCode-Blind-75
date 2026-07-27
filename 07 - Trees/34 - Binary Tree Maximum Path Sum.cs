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
    private int BestSum = -1001;

    public int MaxPathSum(TreeNode root) {
        int bestSumThroughNode = DFS(root);

        // Return the best sum found between those that go through the root node, and those that don't.
        return Math.Max(BestSum, bestSumThroughNode);
    }

    // Returns the best sum found on that path that goes through the given node.
    private int DFS(TreeNode node) {
        // BASE CASE - no node
        if (node == null) return -1001;

        int leftSum = DFS(node.left);
        int rightSum = DFS(node.right);

        // Calculate best sum if splitting on this node. Update best sum if appropriate.
        int splitSum = node.val + leftSum + rightSum;
        BestSum = Math.Max(BestSum, splitSum);

        // Calculate best sum if not splitting here.
        int localBestSum = node.val;    // Node value must be included for non-empty path.

        localBestSum = Math.Max(localBestSum, node.val + leftSum);
        localBestSum = Math.Max(localBestSum, node.val + rightSum);

        // Update best sum if appropriate.
        BestSum = Math.Max(BestSum, localBestSum);
        
        // Return the local best sum, since during recurse, we want to know the best sum THROUGH this node.
        return localBestSum;
    }
}
