using Xunit;

namespace Algorithms.Graphs.Algorithms;

/// <summary>
///     The graph must not have edges with negative weights.
///     Runtime - O(E*log(V))
/// </summary>
public class Dijkstra
{
    [Fact]
    public void Test()
    {
        var nodes = new[]
        {
            new[] { 0, 1, 3 },
            new[] { 0, 2, 6 },
            new[] { 1, 2, 4 },
            new[] { 1, 3, 4 },
            new[] { 2, 3, 8 },
            new[] { 1, 4, 11 },
            new[] { 2, 6, 11 },
            new[] { 3, 4, 4 },
            new[] { 3, 6, 2 },
            new[] { 3, 5, 5 },
            new[] { 4, 7, 9 },
            new[] { 5, 7, 1 },
            new[] { 6, 7, 2 }
        };

        var result = FindShortestPath(nodes, 0);
    }

    public int[] FindShortestPath(int[][] graph, int start)
    {
        var adjList = new Dictionary<int, List<(int To, int Dist)>>();
        foreach (var x in graph)
        {
            if (!adjList.ContainsKey(x[0])) adjList[x[0]] = new();
            if (!adjList.ContainsKey(x[1])) adjList[x[1]] = new();
            adjList[x[0]].Add((x[1], x[2]));
        }

        var visited = new bool[adjList.Count];
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(start, 0);
        var dist = new int[adjList.Count];
        for (var index = 0; index < dist.Length; index++) dist[index] = int.MaxValue;
        dist[start] = 0;

        while (pq.Count != 0)
        {
            pq.TryDequeue(out var current, out var currentDist);
            visited[current] = true;
            if (dist[current] < currentDist) continue;
            foreach (var adj in adjList[current])
            {
                if (visited[adj.To]) continue;
                var newDist = currentDist + adj.Dist;
                if (newDist < dist[adj.To])
                {
                    dist[adj.To] = newDist;
                    pq.Enqueue(adj.To, newDist);
                }
            }
        }

        return dist;
    }

    public int[] FindShortestPath1(int[][] graph, int start)
    {
        var adjList = new Dictionary<int, List<(int To, int Dist)>>();
        foreach (var x in graph)
        {
            if (!adjList.ContainsKey(x[0])) adjList[x[0]] = new();
            if (!adjList.ContainsKey(x[1])) adjList[x[1]] = new();
            adjList[x[0]].Add((x[1], x[2]));
        }

        var visited = new HashSet<int>();
        var pq = new PriorityQueue<int, int>();
        var dist = new int[adjList.Count];
        for (var i = 0; i < dist.Length; i++) dist[i] = int.MaxValue;
        dist[start] = 0;
        pq.Enqueue(start, 0);

        while (pq.Count != 0)
        {
            pq.TryDequeue(out var v, out var w);
            if (dist[v] < w) continue;
            foreach (var (n, nW) in adjList[v])
            {
                if (visited.Contains(n)) continue;
                if (w + nW < dist[n])
                {
                    dist[n] = w + nW;
                    pq.Enqueue(n, dist[n]);
                }
            }
        }

        return dist;
    }
}