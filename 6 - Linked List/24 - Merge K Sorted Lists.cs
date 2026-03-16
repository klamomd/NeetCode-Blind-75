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
    public ListNode MergeKLists(ListNode[] lists) {
        // Map any given value to all nodes containing that value.
        var nodesByValues = new Dictionary<int, List<ListNode>>();

        // Iterate through each list.
        foreach (var head in lists) {
            var curr = head;

            while (curr != null) {
                int val = curr.val;
                
                // Add the current value / node to the map.
                if (!nodesByValues.ContainsKey(val)) {
                    nodesByValues[val] = new List<ListNode> { curr };
                } else {
                    nodesByValues[val].Add(curr);
                }

                curr = curr.next;
            }
        }

        // Sort the values we've found in ascending order.
        var sortedKeys = nodesByValues.Keys.ToList();
        sortedKeys.Sort();

        // Use an empty node as an anchor to build the rest of the list on.
        var anchor = new ListNode();
        var current = anchor;

        // Iterate through all values, and add each node with that value to the new list.
        foreach (var key in sortedKeys) {
            var nodes = nodesByValues[key];

            foreach (var node in nodes) {
                current.next = node;
                current = current.next;
            }
        }

        // Null out final node's neighbor, to remove any unintentional cycle.
        current.next = null;

        // Ignore the first, empty node and return the remainder of the list.
        return anchor.next;
    }
}
