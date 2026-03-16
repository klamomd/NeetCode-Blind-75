public class Solution {
    public bool Exist(char[][] board, string word) {
        int xLength = board.Length;
        int yLength = board[0].Length;

        // Use a hashset passed by reference to track which cells are visited.
        var visited = new HashSet<(int X, int Y)>();

        // Iterate across every cell to try and find the specified word.
        for (int x = 0; x < xLength; x++) {
            for (int y = 0; y < yLength; y++) {
                char current = board[x][y];

                if (FindWord(board, word, x, y, ref visited)) {
                    return true;
                }
            }
        }

        return false;
    }

    // Build a list of tuples representing any valid adjacent cells (valid meaning in-bounds and not visited).
    public List<(int X, int Y)> GetValidAdjacentCells(
        int x,
        int y,
        int xLength,
        int yLength,
        ref HashSet<(int X, int Y)> visited
        ) {
        var retList = new List<(int X, int Y)>();

        // Left
        if (IsValid(x - 1, y, xLength, yLength, ref visited)) {
            retList.Add((x - 1, y));
        }

        // Top
        if (IsValid(x, y - 1, xLength, yLength, ref visited)) {
            retList.Add((x, y - 1));
        }

        // Right
        if (IsValid(x + 1, y, xLength, yLength, ref visited)) {
            retList.Add((x + 1, y));
        }

        // Bottom
        if (IsValid(x, y + 1, xLength, yLength, ref visited)) {
            retList.Add((x, y + 1));
        }

        return retList;
    }

    // Returns true if the cell is in-bounds and not visited.
    public bool IsValid(int x, int y, int xLength, int yLength, ref HashSet<(int X, int Y)> visited) {
        return (0 <= x && x < xLength) && (0 <= y && y < yLength) && !visited.Contains((x, y));
    }

    public bool FindWord(char[][] board, string remainingWord, int x, int y, ref HashSet<(int X, int Y)> visited) {
        // Given the visited set, the remaining word, the board, and the position we are starting from, we should
        // be able to determine if the remaining word is present.

        // If this cell doesn't match the start of the remaining word, remove this cell from the visited set
        // and return false.
        if (board[x][y] != remainingWord[0]) {
            return false;
        }

        // BASE CASE: Remaining word is 1 char long, and matches current cell.
        if (remainingWord.Length == 1) {
            return true;
        }

        // CASE: Remaining word has more than 1 character, so dig deeper.
        // Mark this cell as visited.
        visited.Add((x, y));

        // Check all valid adjacent cells.
        var adjacentCells = GetValidAdjacentCells(x, y, board.Length, board[0].Length, ref visited);

        // BASE CASE: No remaining valid, adjacent cells.
        if (adjacentCells.Count == 0) {
            visited.Remove((x, y));
            return false;
        }

        // Recurse on each valid, adjacent cell.
        var subWord = remainingWord.Substring(1);
        foreach (var cell in adjacentCells) {
            if (FindWord(board, subWord, cell.X, cell.Y, ref visited)) {
                return true;
            }
        }

        // If we've reached here, none of the adjacent cells were successful.
        // Remove this cell from visited and return false.
        visited.Remove((x, y));
        return false;
    }
}
