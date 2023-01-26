namespace Algorithms.Queues.Leetcode;

/// <summary>
/// https://leetcode.com/problems/k-closest-points-to-origin/
/// </summary>
public class KClosestPointsToOrigin
{
    public class Solution
    {
        public int[][] KClosest(int[][] points, int k)
        {
            var q = new PriorityQueue<int[], double>();
            foreach (var t in points)
            {
                q.Enqueue(t, Math.Sqrt(t[0] * t[0] + t[1] * t[1]));
            }

            var res = new int[k][];
            for (var i = 0; i < k; i++) res[i] = q.Dequeue();

            return res;
        }
    }
}
