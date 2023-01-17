using Xunit;

namespace Algorithms.Queues.Leetcode;

/// <summary>
/// https://leetcode.com/problems/kth-largest-element-in-a-stream/description/
/// </summary>
public sealed class KthLargestElementInStream
{
    [Fact]
    public void Test()
    {
        var x = new KthLargest(3, new[] { 4, 5, 8, 2 });
        x.Add(3);
        x.Add(5);
        x.Add(10);
    }

    public class KthLargest
    {
        private readonly int _k;
        private readonly PriorityQueue<int, int> _queue = new();

        public KthLargest(int k, int[] nums)
        {
            _k = k;
            foreach (var x in nums) Add(x);
        }

        public int Add(int val)
        {
            _queue.Enqueue(val, val);
            if (_queue.Count > _k) _queue.Dequeue();
            return _queue.Peek();
        }
    }
}
