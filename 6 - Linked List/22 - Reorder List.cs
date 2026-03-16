/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public void ReorderList(ListNode head) {
        // EDGE CASE - empty list.
        if (head == null) {
            return;
        }

        var nodes = new List<ListNode>();

        // Iterate once through the list and store all nodes in order.
        var curr = head;
        while (curr != null) {
            nodes.Add(curr);
            curr = curr.next;
        }

        int l = 0;
        int r = nodes.Count - 1;

        var left = nodes[l];
        var right = nodes[r];
        while (l < r) {
            // Set right node as left's neighbor.
            left.next = right;
            l++;

            // If left pointer equals right pointer, there are no further nodes.
            // Set right node's neighbor to null, to remove any cycle.
            if (l == r) {
                right.next = null;
                break;
            }

            // Update left node.
            left = nodes[l];

            // Set left node as right's neighbor.
            right.next = left;
            r--;

            // If left pointer equals right pointer, there are no further nodes.
            // Set left node's neighbor to null, to remove any cycle.
            if (l == r) {
                left.next = null;
                break;
            }

            // Update right node.
            right = nodes[r];
        }
    }
}
