namespace Algorithms.LeetCode.Graphs;

public class SurroundedRegions
{
    public void Solve2(char[][] board)
    {
        var rows = board.Length;
        var cols = board[0].Length;
        var visited = new HashSet<(int, int)>();
        var moves = new List<(int, int)>
        {
            (0, 1),
            (0, -1),
            (1, 0),
            (-1, 0),
        };

        for (var i = 0; i < rows; i++)
        {
            Dfs(i, 0);
        }

        for (var j = 0; j < cols; j++)
        {
            Dfs(0, j);
        }

        for (var i = 0; i < rows; i++)
        {
            Dfs(i, cols - 1);
        }

        for (var j = 0; j < cols; j++)
        {
            Dfs(rows - 1, j);
        }

        bool RowInbound(int x) => 0 <= x && x < rows;
        bool ColInbound(int x) => 0 <= x && x < cols;

        void Dfs(int i, int j)
        {
            if (!visited.Add((i, j)) || !RowInbound(i) || !ColInbound(j) || board[i][j] != 'O')
            {
                return;
            }

            board[i][j] = 'T';

            foreach (var m in moves)
            {
                Dfs(i + m.Item1, j + m.Item2);
            }
        }

        for (var i = 1; i < rows; i++)
        for (var j = 1; j < cols; j++)
        {
            if (board[i][j] == 'O')
            {
                board[i][j] = 'X';
            }
        }

        for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
        {
            if (board[i][j] == 'T')
            {
                board[i][j] = 'O';
            }
        }
    }

    public void Solve(char[][] board)
    {
        var rows = board.Length;
        var cols = board[0].Length;
        var itemsToReset = new HashSet<(int, int)>();
        var visited = new HashSet<(int, int)>();
        var moves = new List<(int, int)>
        {
            (0, 1),
            (0, -1),
            (1, 0),
            (-1, 0),
        };

        bool borderReached;

        for (var i = 1; i < rows - 1; i++)
        for (var j = 1; j < cols - 1; j++)
        {
            if (board[i][j] == 'O')
            {
                borderReached = false;
                var path = new HashSet<(int, int)>();

                if (visited.Contains((i, j)))
                {
                    continue;
                }

                ExploreBfs(i, j, path);

                if (!borderReached)
                {
                    foreach (var valueTuple in path)
                    {
                        itemsToReset.Add(valueTuple);
                    }
                }
            }
        }

        foreach (var pair in itemsToReset)
        {
            board[pair.Item1][pair.Item2] = 'X';
        }

        bool RowInbound(int x) => 0 <= x && x < rows;
        bool ColInbound(int x) => 0 <= x && x < cols;

        void ExploreBfs(int i, int j, HashSet<(int, int)> path)
        {
            var q = new Queue<(int, int)>();
            q.Enqueue((i, j));

            while (q.Count > 0)
            {
                var (ii, jj) = q.Dequeue();
                if (!visited.Add((ii, jj)))
                {
                    continue;
                }

                if (board[ii][jj] == 'O')
                {
                    if (ii == 0 || jj == 0 || ii == rows - 1 || jj == cols - 1)
                    {
                        borderReached = true;
                    }

                    path.Add((ii, jj));
                    foreach (var move in moves)
                    {
                        var di = ii + move.Item1;
                        var dj = jj + move.Item2;

                        if (RowInbound(di) && ColInbound(dj) && board[di][dj] == 'O')
                        {
                            q.Enqueue((di, dj));
                        }
                    }
                }
            }
        }
    }
}
