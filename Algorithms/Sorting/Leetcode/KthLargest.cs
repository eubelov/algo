using Xunit;

namespace Algorithms.Sorting.Leetcode;

/// <summary>
/// https://leetcode.com/problems/kth-largest-element-in-an-array/description/
/// </summary>
public class KthSmallest
{
    [Fact]
    public void Test()
    {
        var r1 = FindKthLargest(new[] { 3, 2, 1, 5, 6, 4 }, 2 - 1);
        var r2 = FindKthLargest(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4 - 1);
    }

    public int FindKthLargest(int[] arr, int k)
    {
        int Partition(int start, int end)
        {
            var pivot = arr[end];
            var pIndex = start;

            for (var i = start; i < end; i++)
                if (arr[i] >= pivot)
                {
                    (arr[i], arr[pIndex]) = (arr[pIndex], arr[i]);
                    pIndex++;
                }

            (arr[pIndex], arr[end]) = (arr[end], arr[pIndex]);

            return pIndex;
        }

        int Find(int start, int end)
        {
            var pivot = Partition(start, end);
            if (pivot == k) return arr[pivot];

            if (pivot < k) return Find(pivot + 1, end);
            return Find(start, pivot - 1);
        }

        return Find(0, arr.Length - 1);
    }
}
