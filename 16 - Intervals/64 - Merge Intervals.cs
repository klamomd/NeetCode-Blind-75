public class Solution {
	public int[][] Merge(int[][] intervals) {
		// BASE CASE - No intervals to merge.
		if (intervals.Length == 0)
		{
			return intervals;
		}
		
		// List to track result.
		List<int[]> result = new();

		// Sort intervals by start time.
		Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });
		
		// Start and end points of the current interval.
		int mergeStart = intervals[0][0];
		int mergeEnd = intervals[0][1];
		
		// Iterate through intervals (skipping the first) and merge overlapping ones.
		for (int i = 1; i < intervals.Length; i++)
		{
			int start = intervals[i][0];
			int end = intervals[i][1];
			
			// If this new interval overlaps our current interval, then merge it as well (update the end value if needed).
			if (DoOverlap(mergeStart, mergeEnd, start, end)) {
				mergeEnd = int.Max(mergeEnd, end);
			}
			// Otherwise, our previous interval has no more overlaps, so add it to the result. 
			else
			{
				// Add the merged interval to the result.
				result.Add([mergeStart, mergeEnd]);
				
				// Reset the start and end points to track the new interval.
				mergeStart = start;
				mergeEnd = end;
			}
		}
		
		// Make sure that the final interval we were working on is added to the list, when we fall OOB.
		result.Add([mergeStart, mergeEnd]);
		
		// Convert result and return.
		return result.ToArray();
	}
	
	// Returns true if the 2 intervals overlap, else false.
	private bool DoOverlap(int start1, int end1, int start2, int end2)
	{
		return start1 <= end2 && start2 <= end1;
	}
}
