using Xunit;

namespace Algorithms.ArraysAndHashing.Leetcode;

public class FindMinimumInRotatedSortedArray
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            FindMin(new[] { 3, 4, 5, 1, 2 });
        }

        public int FindMin(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            var l = 0;
            var r = nums.Length - 1;
            var min = nums[0];

            while (l <= r)
            {
                if (nums[l] < nums[r])
                {
                    min = Math.Min(min, nums[l]);
                    break;
                }

                var m = (l + r) / 2;
                min = Math.Min(min, nums[m]);
                if (nums[m] >= nums[l]) l = m + 1;
                else r = m - 1;
            }

            return min;
        }
    }
}
