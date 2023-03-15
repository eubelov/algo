namespace Algorithms.Graphs.Problems;

public class ConnectedComponents
{
    public static int Explore(Dictionary<string, List<string>> graph)
    {
        var set = new HashSet<string>();
        var count = 0;
        foreach (var node in graph)
            if (Explore(graph, node.Key, set))
                count++;

        return count;
    }

    private static bool Explore(Dictionary<string, List<string>> graph, string current, HashSet<string> visited)
    {
        if (visited.Contains(current)) return false;

        visited.Add(current);

        foreach (var neighbor in graph[current]) Explore(graph, neighbor, visited);

        return true;
    }
}
public class LargestConnectedComponent
{
    public static int Explore(Dictionary<string, List<string>> graph)
    {
        var max = 0;
        var visited = new HashSet<string>();
        foreach (var node in graph)
        {
            var result = Explore(graph, node.Key, visited);
            if (result > max) max = result;
        }

        return max;
    }

    private static int Explore(Dictionary<string, List<string>> graph, string current, HashSet<string> visited)
    {
        if (visited.Contains(current)) return 0;

        visited.Add(current);
        var count = 1;
        foreach (var neighbours in graph[current]) count += Explore(graph, neighbours, visited);

        return count;
    }
}
public class ShortestPath
{
    public static int Explore(Dictionary<string, List<string>> graph, string from, string to)
    {
        var queue = new Queue<(string, int)>();
        queue.Enqueue((from, 0));
        var visited = new HashSet<string>();

        while (queue.Count != 0)
        {
            var (current, distance) = queue.Dequeue();
            if (visited.Contains(current)) continue;

            visited.Add(current);
            if (current == to) return distance;

            foreach (var neighbour in graph[current]) queue.Enqueue((neighbour, distance + 1));
        }

        return -1;
    }
}
public class CountIslands
{
    public static int Explore(int[,] matrix)
    {
        var visited = new HashSet<string>();
        var islands = 0;
        for (var i = 0; i < matrix.GetLength(0); i++)
        for (var j = 0; j < matrix.GetLength(1); j++)
            if (Explore(matrix, i, j, visited))
                islands++;

        return islands;
    }

    private static bool Explore(int[,] matrix, int i, int j, HashSet<string> visited)
    {
        var rowInbounds = 0 <= i && i < matrix.GetLength(0);
        var colInbounds = 0 <= j && j < matrix.GetLength(1);
        if (!rowInbounds || !colInbounds) return false;

        if (matrix[i, j] == 0) return false;

        if (visited.Contains($"{i},{j}")) return false;

        visited.Add($"{i},{j}");

        Explore(matrix, i - 1, j, visited);
        Explore(matrix, i + 1, j, visited);
        Explore(matrix, i, j + 1, visited);
        Explore(matrix, i, j - 1, visited);

        return true;
    }
}
public class MinimalIsland
{
    public static int Explore(int[,] matrix)
    {
        var min = int.MaxValue;
        var visited = new HashSet<string>();

        for (var i = 0; i < matrix.GetLength(0); i++)
        for (var j = 0; j < matrix.GetLength(1); j++)
        {
            var count = Explore(matrix, i, j, visited);
            if (count > 0 && count < min) min = count;
        }

        static int Explore(int[,] matrix, int i, int j, HashSet<string> visited)
        {
            var rowInbound = 0 <= i && i < matrix.GetLength(0);
            var colInbound = 0 <= j && j < matrix.GetLength(1);
            if (!rowInbound || !colInbound) return 0;
            if (matrix[i, j] == 0) return 0;
            if (visited.Contains($"{i},{j}")) return 0;

            visited.Add($"{i},{j}");


            var count = 1;
            count += Explore(matrix, i + 1, j, visited);
            count += Explore(matrix, i - 1, j, visited);
            count += Explore(matrix, i, j + 1, visited);
            count += Explore(matrix, i, j - 1, visited);

            return count;
        }

        return min == int.MaxValue ? -1 : min;
    }
}

// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}
