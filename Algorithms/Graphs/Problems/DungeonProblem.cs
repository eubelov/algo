using Xunit;

namespace Algorithms.Graphs.Problems;

public class DungeonProblem
{
    [Fact]
    public void Test()
    {
        var m = new char[][]
        {
            new[] { 's', '.', '.', '#', '.', '.', '.' },
            new[] { '.', '#', '.', '.', '.', '#', '.' },
            new[] { '.', '#', '.', '.', '.', '.', '.' },
            new[] { '.', '.', '#', '#', '.', '.', '.' },
            new[] { '#', '.', '#', 'E', '.', '#', '.' },
        };

        var ans = FindPath(m);
    }

    public int FindPath(char[][] g)
    {
        var w = g[0].Length;
        var h = g.Length;

        var q = new Queue<(int, int)>();
        var visited = new HashSet<(int, int)>();
        var steps = 1;

        q.Enqueue((0, 0));

        //direction vectors
        var dr = new[] { 0, 0, 1, -1 };
        var dc = new[] { 1, -1, 0, 0 };

        bool InRange(int x, int y) => 0 <= x && x < w && 0 <= y && y < h;

        while (q.Count != 0)
        {
            var level = q.Count;
            for (var i = 0; i < level; i++)
            {
                var (x, y) = q.Dequeue();
                visited.Add((x, y));
                for (var j = 0; j < dr.Length; j++)
                {
                    var xx = x + dr[j];
                    var yy = y + dc[j];
                    if (InRange(xx, yy) && g[yy][xx] != '#' && visited.Add((xx, yy)))
                    {
                        q.Enqueue((xx, yy));
                        if (g[yy][xx] == 'E') return steps;
                    }
                }
            }

            steps++;
        }

        return -1;
    }
}
