public class Solution {
	public int EraseOverlapIntervals(int[][] intervals) {
		// BASE CASE - No overlapping intervals
		if (intervals.Length == 1)
		{
			return 0;
		}
		
		// Sort the intervals by start time
		Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
		
		// Set up a variable to track the end time of the last interval
		int lastEnd = int.MinValue;
		
		int erasedIntervals = 0;
		
		foreach (var i in intervals)
		{
			int start = i[0];
			int end = i[1];
			
			// No overlap. Update lastEnd and continue.
			if (start >= lastEnd)
			{
				lastEnd = end;
				continue;
			}
			
			// Overlap. Remove the interval with the later end time and continue.
			erasedIntervals++;
			lastEnd = int.Min(end, lastEnd);
		}
		
		return erasedIntervals;
	}
}
