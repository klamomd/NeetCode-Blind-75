// Basically just copied my solution from https://github.com/klamomd/BitBurner/blob/main/contracts/solved/uniqueGridPaths1.js, added caching to use dynamic programming, and added comments.

public class Solution {
	// First key (M, N) is the size of the grid (M = Rows, N = Columns), so we can use the same cache for different grids.
	// The nested key (R, C) is which cell to start in.
	// The nested value will be the number of unique paths to the bottom-right of the grid.
    private Dictionary< (int m, int n),
				Dictionary< (int r, int c), int >> gridPathsCache = new();


	// Tried something new with this XML comment ¯\_(ツ)_/¯

	/// <summary>
	/// 	Counts the number of paths to the bottom-right cell from the given position, in a grid of M x N size, only moving right or down.
	/// </summary>
	/// <param name="rows">Number of rows in the grid (aka 'M')</param>
	/// <param name="cols">Number of columns in the grid (aka 'N')</param>
	/// <param name="r">The row index to start our search at (defaults to 0).</param>
	/// <param name="c">The column index to start our search at (defaults to 0).</param>
	/// <returns>The number of paths.</returns>
	public int UniquePaths(int rows, int cols, int r = 0, int c = 0) {
		// OOB - no paths.
		if (r >= rows || c >= cols) {
			return 0;
		}

		// Base case - we are in the bottom-right cell - only 1 path here.
		if (r >= rows - 1 && c >= cols - 1) {
			return 1;
		}
		
		var start = (r, c);
		var localCache = GetOrCreateGridCache(rows, cols);
		
		// Return cached value, if available.
		if (localCache.ContainsKey(start))
		{
			return localCache[start];
		}

		// Count paths starting from the right, then from below. Return the sum.
		int rightPaths = UniquePaths(rows, cols, r, c + 1);
		int downPaths = UniquePaths(rows, cols, r + 1, c);

		int result = rightPaths + downPaths;
		
		// Update cache
		localCache[start] = result;
		
		return result;
	}
	
	// Returns the grid cache for the given grid dimensions. Initializing the cache if necessary.
	public Dictionary< (int r, int c), int > GetOrCreateGridCache(int rows, int cols)
	{
		// Grab the current grids pathCache
		var cacheKey = (rows, cols);
		
		var cache = gridPathsCache.GetValueOrDefault(cacheKey);
		
		// Initialize + add cache for current grid if not done yet.
		if (cache == null)
		{
			cache = new Dictionary< (int r, int c), int >();
			
			gridPathsCache[cacheKey] = cache;
		}
		
		return cache;
	}
}

// Take 2: Changed the way the caching is done slightly, to try and speed up access slightly. Performance seemed better, but memory took a hit.
/* public class Solution {
	// Cache - maps a starting cell (R, C) to the number of unique paths from that cell.
    private Dictionary<(int r, int c), int> gridPathsCache;
	
	// Returns the number of unique paths from the top-left cell to the bottom-right, only moving right / down, for the given grid size.
	// NOT PARALLEL-SAFE! (But I guess neither was the last one..)
	public int UniquePaths(int rows, int cols) {
		// Refresh the cache for every call.
		gridPathsCache = new();
		
		return UniquePathsRecurse(rows, cols);
	}


	// Tried something new with this XML comment ¯\_(ツ)_/¯

	/// <summary>
	/// 	Counts the number of paths to the bottom-right cell from the given position, in a grid of M x N size, only moving right or down.
	/// </summary>
	/// <param name="rows">Number of rows in the grid (aka 'M')</param>
	/// <param name="cols">Number of columns in the grid (aka 'N')</param>
	/// <param name="r">The row index to start our search at (defaults to 0).</param>
	/// <param name="c">The column index to start our search at (defaults to 0).</param>
	/// <returns>The number of paths.</returns>
	private int UniquePathsRecurse(int rows, int cols, int r = 0, int c = 0) {
		// OOB - no paths.
		if (r >= rows || c >= cols) {
			return 0;
		}

		// Base case - we are in the bottom-right cell - only 1 path here.
		if (r >= rows - 1 && c >= cols - 1) {
			return 1;
		}
		
		var start = (r, c);
		
		// Return cached value, if available.
		if (gridPathsCache.ContainsKey(start))
		{
			return gridPathsCache[start];
		}

		// Count paths starting from the right, then from below. Return the sum.
		int rightPaths = UniquePathsRecurse(rows, cols, r, c + 1);
		int downPaths = UniquePathsRecurse(rows, cols, r + 1, c);

		int result = rightPaths + downPaths;
		
		// Update cache
		gridPathsCache[start] = result;
		
		return result;
	}
}*/