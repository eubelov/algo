namespace Algorithms.Graphs.Leetcode;

/// <summary>
/// https://leetcode.com/problems/rotting-oranges
/// </summary>
public class RottingOranges
{
    public int OrangesRotting(int[][] grid)
    {
        var queue = new List<(int, int)>();
        var time = 0;
        var fresh = 0;

        var rows = grid.Length;
        var cols = grid[0].Length;

        for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
        {
            if (grid[i][j] == 1) fresh++;
            if (grid[i][j] == 2) queue.Add((i, j));
        }

        var directions = new List<(int, int)>
        {
            (0, 1),
            (0, -1),
            (1, 0),
            (-1, 0),
        };

        while (queue.Count > 0 && fresh > 0)
        {
            var l = queue.Count;
            for (var i = 0; i < l; i++)
            {
                var (r, c) = queue[0];
                queue.RemoveAt(0);
                foreach (var (dr, dc) in directions)
                {
                    var adjR = dr + r;
                    var adjC = dc + c;

                    if (adjR < 0 || adjR >= rows || adjC < 0 || adjC >= cols || grid[adjR][adjC] != 1)
                    {
                        continue;
                    }

                    grid[adjR][adjC] = 2;
                    queue.Add((adjR, adjC));
                    fresh--;
                }
            }

            time++;
        }

        return fresh == 0 ? time : -1;
    }
}
