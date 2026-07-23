public class Solution {
    public void Rotate(int[][] matrix) {
        RotateSquare(ref matrix);
    }

    // Rotates the current depth "square" of the matrix, and recurses to the next depth.
    private void RotateSquare(ref int[][] matrix, int currentDepth = 0) {
        // OOB check.
        if (currentDepth < 0) {
            currentDepth = 0;
        }

        int matrixMax = matrix.Length - 1;

        // Calculate the indices representing the bounds of the current square. At the most shallow depth (0), min = 0 and
        // max = matrixMax.
        int min = currentDepth;
        int max = (matrixMax) - currentDepth;

        // BASE CASE: If min >= max, then we either have a single cell to "rotate", or we've just rotated the innermost square.
        //  In either case, we're done rotating.
        if (min >= max) {
            return;
        }

        // Loop through all cells in the top row of the current square (apart from the last cell, or we'd be reprocessing it).
        for (int c = min; c < max; c++) {
            // Define current cell coords.
            int currentCellRow = min;
            int currentCellCol = c;

            // Calculate next cell coords.
            int nextCellRow = currentCellCol;
            int nextCellCol = matrixMax - currentCellRow;

            // Set up swap space with current cell value.
            int swap = matrix[currentCellRow][currentCellCol];

            // Rotate this cell and its 4 counterparts (at 90 degree rotations).
            for (int i = 0; i < 4; i++) {
                // Update the current cell coords.
                currentCellRow = nextCellRow;
                currentCellCol = nextCellCol;

                // Calculate next cell coords.
                nextCellRow = currentCellCol;
                nextCellCol = matrixMax - currentCellRow;

                // Swap the current cell's value with the swap space's value.
                int tmp = swap;
                swap = matrix[currentCellRow][currentCellCol];
                matrix[currentCellRow][currentCellCol] = tmp;
            }
        }

        // Recurse on the next deepest square.
        RotateSquare(ref matrix, currentDepth + 1);
    }
}
