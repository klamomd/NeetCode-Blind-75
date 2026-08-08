/*
// Definition for a Node.
public class Node {
	public int val;
	public IList<Node> neighbors;

	public Node() {
		val = 0;
		neighbors = new List<Node>();
	}

	public Node(int _val) {
		val = _val;
		neighbors = new List<Node>();
	}

	public Node(int _val, List<Node> _neighbors) {
		val = _val;
		neighbors = _neighbors;
	}
}
*/

public class Solution {
	private Dictionary<Node, Node> cloneMap = new();

	public Node CloneGraph(Node node) {
		// Edge case - empty graph.
		if (node == null)
		{
			return null;
		}
		
		// If this node has already been visited and cloned, return the existing clone.
		if (cloneMap.ContainsKey(node))
		{
			return cloneMap[node];
		}
		
		// Clone the node and add to map.
		var clone = new Node(node.val);
		
		cloneMap[node] = clone;
		
		// Clone all neighbors and add as neighbors to clone.
		foreach (var neighbor in node.neighbors)
		{
			var clonedNeighbor = CloneGraph(neighbor);
			
			// Skip null neighbors (shouldn't happen, but adding CYA handling b/c why not?).
			if (clonedNeighbor == null)
			{
				continue;
			}
			
			// Add to clone's neighbors.
			clone.neighbors.Add(clonedNeighbor);
		}
		
		return clone;
	}
}
