using Algorithms.Trees.BinaryTree;

namespace Algorithms.LeetCode.Graphs.Algo;

public class ShortestPathAlgo
{
    public int[] Run()
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

        var result = FindShortestPaths(nodes, 8, 3);

        return result;
    }

    public int[] FindShortestPaths(int[][] nodes, int numNodes, int start)
    {
        var dict = new Dictionary<int, List<(int, int)>>();
        foreach (var node in nodes)
        {
            if (!dict.ContainsKey(node[0])) dict[node[0]] = new();
            if (!dict.ContainsKey(node[1])) dict[node[1]] = new();
            dict[node[0]].Add((node[1], node[2]));
        }

        var topSort = TopSort(dict, numNodes);
        var dist = new int[numNodes];
        for (var i = dist.Length - 1; i >= 0; i--)
        {
            dist[i] = int.MaxValue;
        }

        dist[start] = 0;

        for (var i = 0; i < numNodes; i++)
        {
            var nodeIndex = topSort[i];
            if (dist[nodeIndex] != int.MaxValue)
            {
                foreach (var neighbour in dict[nodeIndex])
                {
                    var newDist = dist[nodeIndex] + neighbour.Item2;
                    dist[neighbour.Item1] = Math.Min(dist[neighbour.Item1], newDist);
                }
            }
        }

        return dist;
    }

    private static int[] TopSort(Dictionary<int, List<(int, int)>> graph, int numNodes)
    {
        var visited = new HashSet<int>();
        var result = new int[numNodes];
        var i = numNodes - 1;
        foreach (var node in graph)
        {
            Dfs(node.Key);
        }

        void Dfs(int node)
        {
            if (!visited.Add(node))
            {
                return;
            }

            foreach (var neighbour in graph[node])
            {
                Dfs(neighbour.Item1);
            }

            result[i--] = node;
        }

        return result;
    }
}
