public class Solution {
    public int MaxArea(int[] heights) {
        int l = 0;
        int r = heights.Length - 1;

        int maxArea = 0;
        while (l < r) {
            int left = heights[l];
            int right = heights[r];

            int width = r - l;
            int height = Math.Min(left, right);

            // Check if we found a new max, and update if so.
            int area = width * height;
            if (area > maxArea)
                maxArea = area;

            // Update the index of the smaller of the 2 heights.
            if (left < right) {
                l++;
            } else {
                r--;
            }
        }

        return maxArea;
    }
}
