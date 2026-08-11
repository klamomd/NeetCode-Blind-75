public class Solution {
    public void SetZeroes(int[][] matrix) {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        // Track the index of each zeroed column
        var zeroedCols = new HashSet<int>(cols);

        // Track the index of each zeroed row
        var zeroedRows = new HashSet<int>(rows);

		// Find all rows and columns to zero out.
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (matrix[r][c] == 0) {
                    zeroedRows.Add(r);
                    zeroedCols.Add(c);
                }
            }
        }

        // Clear out rows.
        foreach (int rowIndex in zeroedRows) {
            matrix[rowIndex] = new int[cols];
        }

        // Clear out cols.
        foreach (int colIndex in zeroedCols) {
            for (int r = 0; r < rows; r++) {
                matrix[r][colIndex] = 0;
            }
        }
    }
}
