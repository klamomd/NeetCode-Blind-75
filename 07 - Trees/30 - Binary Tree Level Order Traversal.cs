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
    public List<List<int>> LevelOrder(TreeNode root) {
        // Initialize list with the root.
        var retList = new List<List<int>>();

        // Edge case: null root.
        if (root == null) {
            return retList;
        }

        // Store nodes that need to be explored in a queue.
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            var currentLevel = new List<int>();

            // Iterate only through the nodes currently in the queue.
            var queueSize = queue.Count;

            for (int i=0; i<queueSize; i++) {
                var node = queue.Dequeue();

                // Add node value to current level list.
                currentLevel.Add(node.val);

                // Add any children to queue, if not null.
                if (node.left != null) {
                    queue.Enqueue(node.left);
                }

                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }

            retList.Add(currentLevel);
        }

        return retList;
    }
}
