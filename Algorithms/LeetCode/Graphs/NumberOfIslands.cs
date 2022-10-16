namespace Algorithms.LeetCode.Graphs;

// https://leetcode.com/problems/number-of-islands
public static class NumberOfIslands
{
    public static void Run()
    {
        var result = NumIslands(
            new[]
            {
                new[] { '1', '1', '1', '1', '0' },
                new[] { '1', '1', '0', '1', '0' },
                new[] { '1', '1', '0', '0', '0' },
                new[] { '0', '0', '0', '0', '0' },
            });

        Console.WriteLine($"Number of islands: {result}");
    }

    private static int Explore(char[][] grid, int i, int j, HashSet<(int, int)> visited)
    {
        var colInbound = 0 <= i && i < grid.Length;
        var rowInbound = 0 <= j && j < grid[0].Length;

        var key = (i, j);
        if (!colInbound || !rowInbound) return 0;

        if (visited.Contains(key)) return 0;

        if (grid[i][j] == '0') return 0;

        visited.Add(key);

        Explore(grid, i + 1, j, visited);
        Explore(grid, i - 1, j, visited);
        Explore(grid, i, j + 1, visited);
        Explore(grid, i, j - 1, visited);

        return 1;
    }

    private static int NumIslands(char[][] grid)
    {
        var total = 0;
        var visited = new HashSet<(int, int)>();

        for (var i = 0; i < grid.Length; i++)
        for (var j = 0; j < grid[0].Length; j++)
            total += Explore(grid, i, j, visited);

        return total;
    }
}
