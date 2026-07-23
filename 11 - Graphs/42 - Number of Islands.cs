public class Solution {
    /*
        NOTE: Yes, I understand that there's a lot of duplicated code here and that I'm not following the DRY
            principle properly. I'm sure there's a better way to organize this, and to consolidate the duplicate
            code, but keeping each direction separate like that helped me keep track of everything in my head.
    */

    private int rows = 0;
    private int cols = 0;

    public int NumIslands(char[][] grid) {
        rows = grid.Length;
        cols = grid[0].Length;

        int islands = 0;

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                // Water
                if (grid[r][c] == '0') {
                    continue;
                }

                // Island
                // Update number of islands
                islands++;

                // Mark all '1's connected to this island as 0.
                MarkConnectedAsZeroes(r, c, ref grid);
            }
        }

        return islands;
    }

    // Returns true if the cell above [r,c] is in-bounds. newR and newC contain the index of that cell.
    private bool TryGetUpIndex(int r, int c, out int newR, out int newC) {
        newR = r - 1;
        newC = c;

        if (newR < 0) {
            return false;
        }

        return true;
    }

    // Returns true if the cell below [r,c] is in-bounds. newR and newC contain the index of that cell.
    private bool TryGetDownIndex(int r, int c, out int newR, out int newC) {
        newR = r + 1;
        newC = c;

        if (newR >= rows) {
            return false;
        }

        return true;
    }

    // Returns true if the cell to the left of [r,c] is in-bounds. newR and newC contain the index of that cell.
    private bool TryGetLeftIndex(int r, int c, out int newR, out int newC) {
        newR = r;
        newC = c - 1;

        if (newC < 0) {
            return false;
        }

        return true;
    }

    // Returns true if the cell to the left of [r,c] is in-bounds. newR and newC contain the index of that cell.
    private bool TryGetRightIndex(int r, int c, out int newR, out int newC) {
        newR = r;
        newC = c + 1;

        if (newC >= cols) {
            return false;
        }

        return true;
    }

    private void MarkConnectedAsZeroes(int currentR, int currentC, ref char[][] grid) {
        int r = currentR;
        int c = currentC;

        // Set current cell as 0.
        grid[r][c] = '0';

        // Check for adjacent island tiles.
        int nextR, nextC;
        if (TryGetUpIndex(r, c, out nextR, out nextC)) {
            // Recurse if island found.
            if (grid[nextR][nextC] == '1') {
                MarkConnectedAsZeroes(nextR, nextC, ref grid);
            }
        }

        if (TryGetDownIndex(r, c, out nextR, out nextC)) {
            // Recurse if island found.
            if (grid[nextR][nextC] == '1') {
                MarkConnectedAsZeroes(nextR, nextC, ref grid);
            }
        }

        if (TryGetLeftIndex(r, c, out nextR, out nextC)) {
            // Recurse if island found.
            if (grid[nextR][nextC] == '1') {
                MarkConnectedAsZeroes(nextR, nextC, ref grid);
            }
        }

        if (TryGetRightIndex(r, c, out nextR, out nextC)) {
            // Recurse if island found.
            if (grid[nextR][nextC] == '1') {
                MarkConnectedAsZeroes(nextR, nextC, ref grid);
            }
        }
    }
}
