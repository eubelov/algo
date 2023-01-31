namespace Algorithms.Graphs.Leetcode;

public class Oranges
{
    public int OrangesRotting(int[][] grid)
    {
        var r = grid.Length;
        var c = grid[0].Length;

        var freshCount = 0;
        var q = new Queue<(int, int)>();

        for (var i = 0; i < r; i++)
        for (var j = 0; j < c; j++)
        {
            if (grid[i][j] == 1)
            {
                freshCount++;
                continue;
            }

            if (grid[i][j] == 2) q.Enqueue((i, j));
        }

        var time = 0;
        var directions = new List<(int, int)>
        {
            (0, 1),
            (0, -1),
            (1, 0),
            (-1, 0),
        };

        while (q.Count > 0 && freshCount > 0)
        {
            var l = q.Count;
            for (var i = 0; i < l; i++)
            {
                var (ci, cj) = q.Dequeue();
                foreach (var (dr, dc) in directions)
                {
                    var x = ci + dr;
                    var y = cj + dc;
                    if (0 <= x && x < r && 0 <= y && y < c && grid[x][y] == 1)
                    {
                        q.Enqueue((x,y));
                        grid[x][y] = 2;
                        freshCount--;
                    }
                }
            }

            time++;
        }

        return freshCount == 0 ? time : -1;
    }
}
