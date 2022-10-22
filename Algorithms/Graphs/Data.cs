namespace Algorithms.Graphs;

public static class Data
{
    public static readonly List<string[]> EdgeList = new()
    {
        new[] { "i", "j" },
        new[] { "k", "i" },
        new[] { "m", "k" },
        new[] { "k", "l" },
        new[] { "o", "n" },
        new[] { "k", "j" },
    };

    public static readonly Dictionary<string, List<string>> Undirected = new()
    {
        ["w"] = new() { "x", "v" },
        ["x"] = new() { "w", "y" },
        ["y"] = new() { "x", "z" },
        ["y"] = new() { "x", "z" },
        ["z"] = new() { "y", "v" },
        ["v"] = new() { "w", "z" },
    };

    public static readonly Dictionary<string, List<string>> AdjacencyList = new()
    {
        ["a"] = new() { "b", "c" },
        ["b"] = new() { "d" },
        ["c"] = new() { "e" },
        ["d"] = new() { "f" },
        ["e"] = new() { "d" },
        ["f"] = new(),
    };

    public static readonly int[,] GridGraph = new[,]
    {
        { 0, 1, 0, 0, 0 },
        { 0, 1, 0, 0, 0 },
        { 0, 0, 0, 1, 0 },
        { 0, 0, 1, 1, 0 },
        { 1, 0, 0, 1, 1 },
        { 1, 1, 0, 0, 0 },
    };

    public static Dictionary<string, List<string>> EdgeListToAdjacencyList(List<string[]> list)
    {
        var result = new Dictionary<string, List<string>>();
        foreach (var x in list)
        {
            if (!result.ContainsKey(x[0])) result[x[0]] = new List<string>();

            if (!result.ContainsKey(x[1])) result[x[1]] = new List<string>();

            result[x[0]].Add(x[1]);
            result[x[1]].Add(x[0]);
        }

        return result;
    }
}
