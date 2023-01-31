using Xunit;

namespace Algorithms.Graphs.Leetcode;

public class NetworkDelay
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            NetworkDelayTime(
                new[]
                {
                    new[] { 2, 1, 1 },
                    new[] { 2, 3, 1 },
                    new[] { 3, 4, 1 },
                },
                4,
                2);
        }

        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            var g = new Dictionary<int, List<(int To, int Dist)>>();
            foreach (var t in times)
            {
                if (!g.ContainsKey(t[0])) g[t[0]] = new();
                if (!g.ContainsKey(t[1])) g[t[1]] = new();
                g[t[0]].Add((t[1], t[2]));
            }

            var visited = new HashSet<int>();
            var pq = new PriorityQueue<int, int>();
            var ans = 0;
            pq.Enqueue(k, 0);

            while (pq.Count != 0)
            {
                pq.TryDequeue(out var curr, out var currDist);
                if (!visited.Add(curr)) continue;
                ans = Math.Max(ans, currDist);

                foreach (var adj in g[curr])
                {
                    if (visited.Contains(adj.To)) continue;
                    pq.Enqueue(adj.To, currDist + adj.Dist);
                }
            }

            return visited.Count == n ? ans : -1;
        }
    }
}
