using Xunit;

namespace Algorithms.Graphs.Problems;

public class PrimMst
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
            new[] { 6, 7, 2 },
        };

        var result = Mst(nodes);
    }

    public (int Cost, int[] Edges) Mst(int[][] graph)
    {
        var adjList = new Dictionary<int, List<(int To, int Dist)>>();
        foreach (var x in graph)
        {
            if (!adjList.ContainsKey(x[0])) adjList[x[0]] = new();
            if (!adjList.ContainsKey(x[1])) adjList[x[1]] = new();
            adjList[x[0]].Add((x[1], x[2]));
            adjList[x[1]].Add((x[0], x[2]));
        }

        var pq = new PriorityQueue<int, int>();
        var visited = new bool[adjList.Count];
        var mstEdges = new int[adjList.Count];
        var m = adjList.Count - 1;
        var edgeCount = 0;
        var mstCost = 0;

        void AddEdges(int src)
        {
            visited[src] = true;
            foreach (var n in adjList[src])
                if (!visited[n.To])
                    pq.Enqueue(n.To, n.Dist);
        }

        AddEdges(0);

        while (pq.Count != 0 && edgeCount != m)
        {
            pq.TryDequeue(out var to, out var dist);
            if (visited[to]) continue;
            mstEdges[edgeCount++] = to;
            mstCost += dist;

            AddEdges(to);
        }

        if (edgeCount != m) return (-1, Array.Empty<int>());
        return (mstCost, mstEdges);
    }
}
