using Xunit;

namespace Algorithms.Graphs.Problems;

public class TopSort
{
    [Fact]
    public void Test()
    {
        var result = TopSortGraph(
            new()
            {
                ["0"] = new(),
                ["1"] = new(),
                ["2"] = new() { "3" },
                ["3"] = new() { "1" },
                ["4"] = new() { "1" },
                ["5"] = new() { "2", "0" },
            });
    }

    public string[] TopSortGraph(Dictionary<string, List<string>> graph)
    {
        var visited = new HashSet<string>();
        var topSort = new string[graph.Count];
        var i = topSort.Length - 1;
        foreach (var n in graph) DFS(n.Key);

        void DFS(string node)
        {
            if (visited.Contains(node)) return;
            visited.Add(node);
            foreach (var neighbour in graph[node]) DFS(neighbour);
            topSort[i--] = node;
        }

        return topSort;
    }
}
