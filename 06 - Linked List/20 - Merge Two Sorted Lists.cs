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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode anchor = new ListNode();

        ListNode curr = anchor;

        // Continue loop while both list pointers are valid.
        while (list1 != null && list2 != null) {
            // Attach and increment the smaller of the 2 nodes.
            if (list1.val < list2.val) {
                curr.next = list1;
                list1 = list1.next;
            } else {
                curr.next = list2;
                list2 = list2.next;
            }

            curr = curr.next;
        }

        // Attach any nodes we did not get to.
        if (list1 != null) {
            curr.next = list1;
        } else if (list2 != null) {
            curr.next = list2;
        }

        // Ignore the first, empty node and return the remainder of the list.
        return anchor.next;
    }
}