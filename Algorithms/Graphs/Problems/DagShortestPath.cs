using Xunit;

namespace Algorithms.Graphs.Problems;

/// <summary>
/// Linear time - O(V + E). Top sort
/// </summary>
public class DagShortestPath
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
            new[] { 3, 4, -4 },
            new[] { 3, 6, 2 },
            new[] { 3, 5, 5 },
            new[] { 4, 7, 9 },
            new[] { 5, 7, 1 },
            new[] { 6, 7, 2 },
        };

        var result = ShortestPath(nodes, 8, 0);
    }

    public int[] ShortestPath(int[][] nodes, int numberOfNodes, int start)
    {
        var graph = new Dictionary<int, List<(int, int)>>();
        foreach (var node in nodes)
        {
            if (!graph.ContainsKey(node[0])) graph[node[0]] = new();
            if (!graph.ContainsKey(node[1])) graph[node[1]] = new();
            graph[node[0]].Add((node[1], node[2]));
        }

        int[] TopSortGraph()
        {
            var visited = new HashSet<int>();
            var result = new int[numberOfNodes];
            var index = numberOfNodes - 1;

            void Dfs(int key)
            {
                if (visited.Add(key))
                {
                    foreach (var x in graph[key]) Dfs(x.Item1);
                    result[index--] = key;
                }
            }

            foreach (var node in graph) Dfs(node.Key);

            return result;
        }

        var topSort = TopSortGraph();
        var dist = new int[graph.Count];
        for (var i = 0; i < dist.Length; i++) dist[i] = int.MaxValue;

        dist[start] = 0;

        for (var i = 0; i < numberOfNodes; i++)
        {
            var idx = topSort[i];
            if (dist[idx] != int.MaxValue)
                foreach (var neighbour in graph[idx])
                {
                    var newDist = dist[idx] + neighbour.Item2;
                    dist[neighbour.Item1] = Math.Min(dist[neighbour.Item1], newDist);
                }
        }

        return dist;
    }
}
