namespace Algorithms.Graphs.Algorithms;

public static class Bfs
{
    public static bool HasPathUndirected(Dictionary<string, List<string>> graph, string from, string to, HashSet<string> visited)
    {
        if (from == to)
        {
            return true;
        }

        var queue = new Queue<string>();
        queue.Enqueue(from);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (visited.Contains(current))
            {
                continue;
            }

            visited.Add(current);
            if (current == to)
            {
                return true;
            }

            foreach (var neighbor in graph[current])
            {
                queue.Enqueue(neighbor);
            }
        }

        return false;
    }

    public static bool HasPath(Dictionary<string, string[]> graph, string from, string to)
    {
        var queue = new Queue<string>();
        queue.Enqueue(from);
        while (queue.Count != 0)
        {
            var current = queue.Dequeue();
            if (to == current)
            {
                return true;
            }

            foreach (var x in graph[current])
            {
                queue.Enqueue(x);
            }
        }

        return false;
    }

    public static void Traverse(Dictionary<string, string[]> graph)
    {
        var queue = new Queue<string>();
        queue.Enqueue(graph.First().Key);

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();
            var neighbours = graph[current];
            foreach (var x in neighbours)
            {
                queue.Enqueue(x);
            }

            Console.WriteLine(current);
        }
    }
}
