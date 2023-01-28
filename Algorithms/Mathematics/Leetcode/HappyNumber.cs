using Xunit;

namespace Algorithms.Mathematics.Leetcode;

public class HappyNumber
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            IsHappy(19);
            IsHappy(2);
        }

        public bool IsHappy(int n)
        {
            var prev = new HashSet<int>();
            var curr = n;

            int S(int x)
            {
                var sum = 0;
                while (x != 0)
                {
                    var d = x % 10;
                    x /= 10;
                    sum += d * d;
                }

                return sum;
            }

            while (curr != 1)
            {
                curr = S(curr);
                if (!prev.Add(curr)) return false;
            }

            return true;
        }
    }
}
