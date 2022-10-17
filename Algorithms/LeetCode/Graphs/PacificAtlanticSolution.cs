namespace Algorithms.LeetCode.Graphs;

/// <summary>
/// https://leetcode.com/problems/pacific-atlantic-water-flow/
/// </summary>
public class PacificAtlanticSolution
{
    /// <summary>
    /// Limited DFS
    /// </summary>
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        var pacificSet = new HashSet<(int, int)>();
        var atlanticSet = new HashSet<(int, int)>();

        var rows = heights.Length;
        var cols = heights[0].Length;

        // top row ->
        for (var col = 0; col < cols; col++) Explore(0, col, pacificSet, heights[0][col]);

        // bottom row ->
        for (var row = 0; row < rows; row++) Explore(row, cols - 1, atlanticSet, heights[row][^1]);

        // left col
        for (var row = 0; row < rows; row++) Explore(row, 0, pacificSet, heights[row][0]);

        // right col
        for (var col = 0; col < cols; col++) Explore(rows - 1, col, atlanticSet, heights[^1][col]);

        void Explore(int i, int j, HashSet<(int, int)> visited, int prevHeight)
        {
            var rowInbound = 0 <= i && i < heights.Length;
            var colInbound = 0 <= j && j < heights[0].Length;

            if (!rowInbound || !colInbound) return;
            var currentHeight = heights[i][j];
            if (currentHeight < prevHeight) return;
            if (visited.Contains((i, j))) return;

            visited.Add((i, j));

            Explore(i - 1, j, visited, currentHeight);
            Explore(i + 1, j, visited, currentHeight);
            Explore(i, j - 1, visited, currentHeight);
            Explore(i, j + 1, visited, currentHeight);
        }

        pacificSet.IntersectWith(atlanticSet);

        return new List<IList<int>>(pacificSet.Select(x => new List<int> { x.Item1, x.Item2 }));
    }

    // DFS Brute force
    public IList<IList<int>> PacificAtlantic2(int[][] heights)
    {
        bool atlanticFound, pacificFound;
        var list = new List<List<int>>();

        for (var i = 0; i < heights.Length; i++)
        for (var j = 0; j < heights[0].Length; j++)
        {
            atlanticFound = pacificFound = false;
            Explore(i, j, new HashSet<(int, int)>(), heights[i][j]);
            if (atlanticFound && pacificFound) list.Add(new List<int> { i, j });
        }

        void Explore(int i, int j, HashSet<(int, int)> visited, int prevHeight)
        {
            if (atlanticFound && pacificFound) return;

            var rowInbound = 0 <= i && i < heights.Length;
            var colInbound = 0 <= j && j < heights[0].Length;

            if (!rowInbound || !colInbound) return;
            var currentHeight = heights[i][j];
            if (currentHeight > prevHeight) return;
            if (visited.Contains((i, j))) return;

            visited.Add((i, j));

            if (i == heights.Length - 1 || j == heights[0].Length - 1) atlanticFound = true;
            if (i == 0 || j == 0) pacificFound = true;

            Explore(i - 1, j, visited, currentHeight);
            Explore(i + 1, j, visited, currentHeight);
            Explore(i, j - 1, visited, currentHeight);
            Explore(i, j + 1, visited, currentHeight);
        }

        return new List<IList<int>>(list);
    }
}
