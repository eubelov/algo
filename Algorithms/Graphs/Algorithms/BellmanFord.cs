using Algorithms.Graphs.Problems;
using Xunit;

namespace Algorithms.Graphs.Algorithms;

public class BellmanFord
{
    [Fact]
    public void Test()
    {
        int E = 10, V = 9, start = 0;
        List<Edge> graph = new()
        {
            new(0, 1, 1),
            new(1, 2, 1),
            new(2, 4, 1),
            new(4, 3, -3),
            new(3, 2, 1),
            new(1, 5, 4),
            new(1, 6, 4),
            new(5, 6, 5),
            new(6, 7, 4),
            new(5, 7, 3),
        };
        var ans = ShortestPath(graph, V, start);
    }

    public static int[] ShortestPath(IList<Edge> edges, int numberOfVertices, int start)
    {
        var dist = new int[numberOfVertices];
        for (var i = 0; i < dist.Length; i++) dist[i] = int.MaxValue;
        dist[start] = 0;

        for (var i = 0; i < numberOfVertices - 1; i++)
            foreach (var edge in edges)
            {
                var newWeight = dist[edge.From] + edge.Weigth;
                if (newWeight < dist[edge.To]) dist[edge.To] = newWeight;
            }

        for (var i = 0; i < numberOfVertices - 1; i++)
            foreach (var edge in edges)
            {
                var newWeight = dist[edge.From] + edge.Weigth;
                if (newWeight < dist[edge.To]) dist[edge.To] = int.MinValue;
            }

        return dist;
    }
}
