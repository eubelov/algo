using Xunit;

namespace Algorithms.Graphs.Leetcode;

public class MinCostToConnectAllPoints
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            // MinCostConnectPoints(
            //     new[]
            //     {
            //         new[] { 0, 0 },
            //         new[] { 2, 2 },
            //         new[] { 3, 10 },
            //         new[] { 5, 2 },
            //         new[] { 7, 0 },
            //     });
            //
            // //[3,12],[-2,5],[-4,1]
            // MinCostConnectPoints(
            //     new[]
            //     {
            //         new[] { 3, 12 },
            //         new[] { -2, 5 },
            //         new[] { -4, 1 },
            //     });
            //[3,12],[-2,5],[-4,1]
            MinCostConnectPoints(
                new[]
                {
                    new[] { 3, 12 },
                    new[] { 4, 19 },
                });
        }

        public int MinCostConnectPoints(int[][] points)
        {
            if (points.Length == 1)
            {
                return 0;
            }

            var matrix = new int[points.Length][];
            for (var i = 0; i < points.Length; i++)
            for (var j = i + 1; j < points.Length; j++)
            {
                var dist = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                if (matrix[i] == null) matrix[i] = new int[points.Length];
                if (matrix[j] == null) matrix[j] = new int[points.Length];
                matrix[i][j] = dist;
                matrix[j][i] = dist;
            }

            var pq = new PriorityQueue<int, int>();
            var visited = new bool[points.Length];
            var mstCost = 0;
            var edgeCount = 0;
            var mstEdges = points.Length - 1;

            void Visit(int e)
            {
                if (visited[e]) return;
                visited[e] = true;
                for (var i = 0; i < matrix[e].Length; i++)
                {
                    var v = matrix[e][i];
                    if (v != 0 && !visited[i])
                        pq.Enqueue(i, v);
                }
            }

            Visit(0);

            while (pq.Count != 0 && edgeCount != mstEdges)
            {
                pq.TryDequeue(out var next, out var dist);
                if (visited[next]) continue;
                mstCost += dist;
                Visit(next);
            }

            return mstCost;
        }
    }
}
