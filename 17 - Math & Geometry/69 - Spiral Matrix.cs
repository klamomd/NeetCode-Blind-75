public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        // Return value
        var result = new List<int>();

        // Ptrs for tracking current x + y bounds
        int yMin = 0;
        int yMax = matrix.Length - 1;
        int xMin = 0;
        int xMax = matrix[0].Length - 1;

        while (yMin <= yMax && xMin <= xMax) {
            // Iterate top row - left to right
            for (int x = xMin; x <= xMax; x++) {
                result.Add(matrix[yMin][x]);
            }

            // Update yMin
            yMin++;

            // OOB check
            if (yMin > yMax) {
                break;
            }

            // Iterate right col - top to bottom
            for (int y = yMin; y <= yMax; y++) {
                result.Add(matrix[y][xMax]);
            }

            // Update xMax
            xMax--;
            
            // OOB check
            if (xMin > xMax) {
                break;
            }

            // Iterate bottom row - right to left
            for (int x = xMax; x >= xMin; x--) {
                result.Add(matrix[yMax][x]);
            }

            // Update yMax
            yMax--;
            
            // OOB check
            if (yMin > yMax) {
                break;
            }

            // Iterate left col - bottom to top
            for (int y = yMax; y >= yMin; y--) {
                result.Add(matrix[y][xMin]);
            }

            // Update xMin
            xMin++;

            // OOB check
            if (xMin > xMax) {
                break;
            }
        }

        return result;
    }
}
