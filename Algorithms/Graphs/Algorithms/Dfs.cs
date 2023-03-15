namespace Algorithms.Graphs.Algorithms;

/// <summary>
/// Traverses as deep as it can before backtracking.
/// </summary>
public static class Dfs
{
    public static void Traverse(Dictionary<string, string[]> graph)
    {
        var stack = new Stack<string>();
        stack.Push(graph.First().Key);

        while (stack.Count != 0)
        {
            var current = stack.Pop();
            var neighbours = graph[current];
            foreach (var x in neighbours)
            {
                stack.Push(x);
            }

            Console.WriteLine(current);
        }
    }

    public static void RecursiveTraverse(Dictionary<string, string[]> graph, string start)
    {
        Console.WriteLine(start);
        foreach (var x in graph[start])
        {
            RecursiveTraverse(graph, x);
        }
    }

    public static bool HasPathRecursive(Dictionary<string, string[]> graph, string from, string to)
    {
        if (from == to)
        {
            return true;
        }

        foreach (var x in graph[from])
        {
            if (HasPathRecursive(graph, x, to))
            {
                return true;
            }
        }

        return false;
    }

    public static bool HasPath(Dictionary<string, string[]> graph, string from, string to)
    {
        if (from == to)
        {
            return true;
        }

        var stack = new Stack<string>();
        stack.Push(from);
        string current = from;
        while (stack.Count > 0 && current != to)
        {
            current = stack.Pop();
            foreach (var x in graph[current])
            {
                stack.Push(x);
            }
        }

        return current == to;
    }

    public static bool HasPathUndirected(Dictionary<string, List<string>> graph, string from, string to, HashSet<string> visited)
    {
        if (visited.Contains(from))
        {
            return false;
        }

        visited.Add(from);

        if (from == to)
        {
            return true;
        }

        foreach (var n in graph[from])
        {
            if (HasPathUndirected(graph, n, to, visited))
            {
                return true;
            }
        }

        return false;
    }

    public static void Solve(List<string> lines, List<string> searchList)
    {
        var matrix = lines.Select(x => x.ToCharArray()).ToList();
        var adjList = new Dictionary<(char, int, int), List<(char, int, int)>>();

        bool TryGetValue(int x, int y, out (char, int, int)? letter)
        {
            if (x < 0 || y < 0 || x >= matrix.Count || y >= matrix.Count)
            {
                letter = null;
                return false;
            }

            letter = (matrix[x][y], x, y);
            return true;
        }

        for (var line = 0; line < matrix.Count; line++)
        {
            for (var column = 0; column < matrix[line].Length; column++)
            {
                var top = (column, line - 1);
                var diagTopRight = (column + 1, line - 1);
                var right = (column + 1, line);
                var diagBottomRight = (column + 1, line + 1);
                var bottom = (column, line + 1);
                var diagBottomLeft = (column - 1, line + 1);
                var left = (column - 1, line);
                var diagTopLeft = (column - 1, line - 1);

                var x = new[] { top, diagTopRight, right, diagBottomRight, bottom, diagBottomLeft, left, diagTopLeft };
                var list = adjList[(lines[line][column], line, column)] = new();

                foreach (var pair in x)
                {
                    if (TryGetValue(pair.Item2, pair.Item1, out var letter))
                    {
                        list.Add(letter!.Value);
                    }
                }
            }
        }

        List<string> words = new();

        void Dfs((char, int, int) node, HashSet<(char, int, int)> visited, string c)
        {
            if (visited.Contains(node))
            {
                return;
            }
            visited.Add(node);
            c += node.Item1;
            words.Add(c);

            var neighbours = adjList[node];
            foreach (var neighbour in neighbours)
            {
                Dfs(neighbour, visited, c);
            }
        }

        foreach (var node in adjList)
        {
            Dfs(node.Key, new(), "");
        }

        foreach (var w in words.Intersect(searchList).ToList())
        {
            Console.WriteLine(w);
        }
    }
}
