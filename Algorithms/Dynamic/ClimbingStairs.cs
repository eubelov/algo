using Xunit;

namespace Algorithms.Dynamic;

/// <summary>
/// https://leetcode.com/problems/climbing-stairs/description/
/// </summary>
public class ClimbingStairs
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            ClimbStairsDp(5);
            ClimbStairsDp(2);
            ClimbStairsDp(3);
        }

        public int ClimbStairs(int n)
        {
            var a = 0;
            var b = 1;
            var res = 0;

            for (var i = 0; i < n; i++)
            {
                var sum = a + b;
                a = b;
                b = sum;
                res = sum;
            }

            return res;
        }

        public int ClimbStairsDp(int n)
        {
            var result = 0;
            var mem = new Dictionary<int, int>();

            int Dfs(int sum)
            {
                if (mem.ContainsKey(sum))
                {
                    result += mem[sum];
                    return mem[sum];
                }

                if (sum > n) return 0;

                if (sum == n)
                {
                    result++;
                    return 1;
                }

                var paths = Dfs(sum + 1) + Dfs(sum + 2);
                if (paths >= 0) mem[sum] = paths;

                return paths;
            }

            Dfs(0);

            return result;
        }
    }
}
