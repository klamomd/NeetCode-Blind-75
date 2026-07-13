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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var nodes = new List<ListNode>();

        // Iterate once through the list and store all nodes in order.
        ListNode curr = head;
        while (curr != null) {
            nodes.Add(curr);
            curr = curr.next;
        }

        // Edge case - removing head.
        if (n == nodes.Count) {
            return head.next;
        }
        // Edge case - removing tail.
        else if (n == 1) {
            nodes[nodes.Count - 2].next = null;
            return head;
        }
        // Main case - removing node somewhere in the middle.
        else {
            var node = nodes[nodes.Count - (n+1)];
            node.next = node.next.next;
            return head;
        }
    }
}
