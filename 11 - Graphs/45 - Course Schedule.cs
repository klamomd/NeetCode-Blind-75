public class Solution {
	public bool CanFinish(int numCourses, int[][] prerequisites) {
		// Map each course to all the courses it requires.
		Dictionary<int, List<int>> prereqMap = prerequisites
			.GroupBy(p => p[0])
			.ToDictionary(
				g => g.Key,
				g => g.Select(p => p[1]).ToList()
			);
		
		// Track course nodes we are visiting during our DFS.
		HashSet<int> visited = [];
			
		// Determine if a course can be completed by running a DFS.
		bool CanCourseBeCompletedDFS(int course)
		{
			// Course already visited - loop found! Course CANNOT be completed.
			if (visited.Contains(course))
			{
				return false;
			}
			
			// No courses required! Course can be completed.
			if (!prereqMap.ContainsKey(course))
			{
				return true;
			}
			
			// Mark course as visited.
			visited.Add(course);
			
			foreach (int p in prereqMap[course])
			{
				// If this prereq can't be completed, then our course can't be completed.
				if (!CanCourseBeCompletedDFS(p))
				{
					return false;
				}
			}
			
			// Remove course from visited.
			visited.Remove(course);
			
			// Empty the prereqs for this course so we don't have to recalculate them.
			prereqMap[course] = new List<int>();
			
			// Course can be completed.
			return true;
		}
		
		// Iterate from 0 to (N - 1) and check that each course can be completed.
		for (int i = 0; i < numCourses; i++)
		{
			// Fail out if any course cannot be completed.
			if (!CanCourseBeCompletedDFS(i))
			{
				return false;
			}
		}
		
		// All courses can be completed.
		return true;
	}
}
