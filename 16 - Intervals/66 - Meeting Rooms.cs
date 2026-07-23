/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        // Sort intervals by start time.
        intervals.Sort(
            Comparer<Interval>.Create((a, b) => a.start.CompareTo(b.start))
        );

        // Check that the end time of each interval does not overlap the start time of the next interval.
        for (int i=0; i<intervals.Count - 1; i++) {
            var current = intervals[i];
            var next = intervals[i+1];

            if (current.end > next.start) {
                return false;
            }
        }
        
        return true;
    }
}
