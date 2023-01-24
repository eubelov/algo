using Xunit;

namespace Algorithms.TwoPointers.Leetcode;

/// <summary>
/// https://leetcode.com/problems/container-with-most-water/
/// </summary>
public class ContainerWithMostWater
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            MaxArea(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
        }

        public int MaxArea(int[] height)
        {
            var l = 0;
            var r = height.Length - 1;
            var res = 0;

            while (l < r)
            {
                var vol = (r - l) * Math.Min(height[l], height[r]);
                res = Math.Max(vol, res);
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }

            return res;
        }
    }
}
