using Xunit;

namespace Algorithms.TwoPointers.Leetcode;

public class ThreeSums
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            Trap(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
        }

        public int Trap(int[] height)
        {
            if (height.Length < 3) return 0;

            var l = 0;
            var r = 1;
            var result = 0;

            while (r < height.Length)
                if (height[r] >= height[r - 1])
                {
                    l = r;
                    r++;
                }

            return result;
        }
    }
}
