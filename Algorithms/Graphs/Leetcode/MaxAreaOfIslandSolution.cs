namespace Algorithms.Graphs.Leetcode;

/// <summary>
/// https://leetcode.com/problems/max-area-of-island
/// </summary>
public static class MaxAreaOfIslandSolution
{
    public static int MaxAreaOfIsland(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var visited = new HashSet<(int, int)>();

        var max = 0;
        for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
            if (grid[i][j] == 1)
            {
                int s;
                if ((s = Explore(i, j)) > max) max = s;
            }

        int Explore(int i, int j)
        {
            var rowInbound = 0 <= i && i < rows;
            var colInbound = 0 <= j && j < cols;

            if (!rowInbound || !colInbound || !visited.Add((i, j))) return 0;
            if (grid[i][j] == 0) return 0;

            return 1 + Explore(i + 1, j) + Explore(i - 1, j) + Explore(i, j + 1) + Explore(i, j - 1);
        }

        return max;
    }
}
