using Xunit;

namespace Algorithms.Queues.Leetcode;

public class LastStone
{
    public static class Solution
    {
        [Fact]
        public static void Test()
        {
            LastStoneWeight(new[] { 2,2 });
        }

        public static int LastStoneWeight(int[] stones)
        {
            if (stones.Length == 1)
            {
                return stones[0];
            }

            var q = new PriorityQueue<int, int>();
            foreach (var x in stones) q.Enqueue(x, -x);

            while (q.Count > 1)
            {
                var s1 = q.Dequeue();
                var s2 = q.Dequeue();
                if (s1 == s2) continue;

                var nw = s1 - s2;
                q.Enqueue(nw, -nw);
            }

            return q.Count == 0 ? 0 : q.Dequeue();
        }
    }
}
