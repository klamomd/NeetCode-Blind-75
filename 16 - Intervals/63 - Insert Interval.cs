public class Solution {
	public int[][] Insert(int[][] intervals, int[] newInterval) {
		// Results list.
		List<int[]> res = new();
		
		// LOOP - Copy non-overlapping intervals before newInterval (NI).
		int i = 0;
		while (i < intervals.Length && intervals[i][1] < newInterval[0])
		{
			res.Add(intervals[i]);
			i++;
		}
		
		// OOB - add NI to end and return.
		if (i >= intervals.Length)
		{
			res.Add(newInterval);
			
			return res.ToArray();
		}
		
		// Combine overlapping intervals into a single interval.
		if (IsOverlapping(intervals[i], newInterval))
		{
			int[] combinedInterval = {
				int.Min(newInterval[0], intervals[i][0]),
				int.Max(newInterval[1], intervals[i][1])
				};
			i++;
			
			// While not OOB, find all overlapping intervals and update the end time of our combined interval.
			while (
				i < intervals.Length &&
				IsOverlapping(intervals[i], combinedInterval))
			{
				// Update the end time to the latter end time.
				combinedInterval[1] = int.Max(intervals[i][1], combinedInterval[1]);
				i++;
			}
			
			res.Add(combinedInterval);
		}
		// Otherwise, insert the new interval.
		else
		{
			res.Add(newInterval);
		}
		
		// LOOP - Copy non-overlapping intervals after newInterval (NI).
		while (i < intervals.Length)
		{
			res.Add(intervals[i]);
			i++;
		}
		
		return res.ToArray();
	}
	
	// Returns true if the 2 intervals overlap (i.e. at least 1 point is shared between the 2 intervals).
	public bool IsOverlapping(int[] interval1, int[] interval2) {
		int start1 = interval1[0],
			start2 = interval2[0],
			end1 = interval1[1],
			end2 = interval2[1];
		
		return start1 <= end2 && start2 <= end1;
	}
}
