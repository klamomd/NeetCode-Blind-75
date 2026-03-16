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
    public bool HasCycle(ListNode head) {
        // Track the nodes we've visited already.
        var visited = new HashSet<ListNode>();

        while (head != null) {
            // Return when we've found a cycle.
            if (visited.Contains(head)) {
                return true;
            }

            // Update the hashset and continue.
            visited.Add(head);
            head = head.next;
        }

        // No cycles found.
        return false;
    }
}
