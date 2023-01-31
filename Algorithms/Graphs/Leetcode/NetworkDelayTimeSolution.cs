namespace Algorithms.Graphs.Leetcode;

/// <summary>
/// https://leetcode.com/problems/network-delay-time
/// </summary>
public class NetworkDelayTimeSolution
{
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        var dict = new Dictionary<int, List<(int, int)>>();
        foreach (var x in times)
        {
            if (!dict.ContainsKey(x[0])) dict[x[0]] = new();
            if (!dict.ContainsKey(x[1])) dict[x[1]] = new();
            dict[x[0]].Add((x[1], x[2]));
        }

        var visited = new HashSet<int>();
        var q = new PriorityQueue<int, int>();
        q.Enqueue(k, 0);
        var t = 0;

        while (q.Count > 0)
        {
            q.TryDequeue(out var element, out var weight);
            if (visited.Contains(element))
            {
                continue;
            }

            visited.Add(element);
            t = Math.Max(t, weight);

            foreach (var (n1, w1) in dict[element])
            {
                if (!visited.Contains(n1))
                {
                    q.Enqueue(n1, w1 + weight);
                }
            }
        }

        return visited.Count == n ? t : -1;
    }
}
