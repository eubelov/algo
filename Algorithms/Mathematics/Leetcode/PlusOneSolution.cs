using Xunit;

namespace Algorithms.Mathematics.Leetcode;

/// <summary>
/// https://leetcode.com/problems/plus-one/description/
/// </summary>
public class PlusOneSolution
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            PlusOne(new[] { 1, 2, 3 });
            PlusOne(new[] { 9 });
        }

        public int[] PlusOne(int[] digits)
        {
            if (digits[^1] != 9)
            {
                digits[^1]++;
                return digits;
            }

            var list = new List<int>(digits);

            var carry = 1;
            list[^1] = 0;
            var i = list.Count - 2;
            while (carry != 0 && i >= 0)
                if (list[i] + carry == 10)
                {
                    list[i] = 0;
                    i--;
                }
                else
                {
                    list[i] += carry;
                    carry = 0;
                }

            if (carry == 1) list.Insert(0, 1);

            return list.ToArray();
        }
    }
}
