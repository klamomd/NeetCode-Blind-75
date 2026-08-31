public class Solution {
	public int CountComponents(int n, int[][] edges) {
		// Initialize arrays.
		int[] parent = new int[n];
		int[] size = new int[n];

		for (int i = 0; i < n; i++)
		{
			parent[i] = i;
			size[i] = 1;
		}

		int totalComponents = n;
		foreach (int[] edge in edges) {
			// Reduce number of components for each group we combine.
			if (Union(edge[0], edge[1])) {
				totalComponents--;
			}
		}

		return totalComponents;

		// Function declarations.
		// Declaring these inside CountComponents because they depend on `parent` and `size`, and for some reason the
		// 	possibility of concurrent calls to `CountComponents` bothers me too much to leave them as globals, but not
		// 	enough to bother to organize this code as I would for if I ACTUALLY expected it to be tested concurrently.

		// Locate the parent of the current node.
		int Find(int x)
		{
			if (parent[x] != x)
			{
				parent[x] = Find(parent[x]);
			}

			return parent[x];
		}

		// Combine the two groups containing `a` and `b`. Returns false if already in the same group, otherwise true.
		bool Union(int a, int b)
		{
			int rootA = Find(a);
			int rootB = Find(b);

			if (rootA == rootB)
				return false;

			// Attach smaller group to larger group.
			if (size[rootA] < size[rootB])
			{
				(rootA, rootB) = (rootB, rootA);
			}

			parent[rootB] = rootA;
			size[rootA] += size[rootB];

			return true;
		}
	}
}
