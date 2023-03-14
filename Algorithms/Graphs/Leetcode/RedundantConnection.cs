using Xunit;

namespace Algorithms.Graphs.Leetcode;

/// <summary>
///     https://leetcode.com/problems/redundant-connection/
/// </summary>
public class RedundantConnection
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            var res = FindRedundantConnection(new[]
            {
                new[] { 1, 2 },
                new[] { 1, 3 },
                new[] { 2, 3 }
            });

            var res2 = FindRedundantConnection(new[]
            {
                new[] { 1, 2 },
                new[] { 2, 3 },
                new[] { 3, 4 },
                new[] { 1, 4 },
                new[] { 1, 5 }
            });
        }

        // O(V*E)
        public int[] FindRedundantConnection(int[][] edges)
        {
            var dsu = new int[edges.Length + 1];
            var ranks = new int[edges.Length + 1];
            for (var index = 0; index < dsu.Length; index++) dsu[index] = -1;

            int Find(int x)
            {
                if (dsu[x] == -1) return x;
                return dsu[x] = Find(dsu[x]);
            }

            bool Union(int x, int y)
            {
                var xAr = Find(x);
                var yAr = Find(y);

                if (xAr == yAr) return false;

                if (ranks[xAr] >= ranks[yAr])
                {
                    if (ranks[xAr] == ranks[yAr]) ranks[yAr]++;
                    dsu[yAr] = xAr;
                }
                else
                {
                    dsu[xAr] = yAr;
                }

                return true;
            }


            foreach (var edge in edges)
                if (!Union(edge[0], edge[1]))
                    return edge;

            return Array.Empty<int>();
        }
    }
}