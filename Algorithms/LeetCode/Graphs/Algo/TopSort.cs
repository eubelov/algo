namespace Algorithms.LeetCode.Graphs.Algo;

public class TopSort
{
    public string[] TopSortGraph(Dictionary<string, List<string>> graph)
    {
        var visited = new HashSet<string>();
        var topSort = new string[graph.Count];
        var i = topSort.Length - 1;
        foreach (var n in graph)
        {
            DFS(n.Key);
        }

        void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return ;
            }

            visited.Add(node);

            foreach (var neighbour in graph[node])
            {
                DFS(neighbour);
            }

            topSort[i--] = node;
        }

        return topSort;
    }
}
