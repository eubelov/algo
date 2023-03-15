namespace Algorithms.BinarySearch.Leetcode;

public class TwoSumII
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var l = 0;
        var r = numbers.Length;

        while (l <= r)
        {
            var sum = numbers[l] + numbers[r];
            if (sum == target)
            {
                return new[] { l + 1, r + 1 };
            }

            if (sum > target)
            {
                r--;
            }
            else
            {
                l++;
            }
        }

        return Array.Empty<int>();
    }
}
