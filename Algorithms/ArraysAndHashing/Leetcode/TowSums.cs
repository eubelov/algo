namespace Algorithms.LeetCode.ArraysAndHashing;

/// <summary>
/// https://leetcode.com/problems/two-sum
/// </summary>
public class TowSumsSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        if (nums.Length == 2)
        {
            return new[] { 0, 1 };
        }

        var hash = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            if (hash.TryGetValue(diff, out var ix))
            {
                return new[] { i, ix };
            }

            hash[nums[i]] = i;
        }

        return Array.Empty<int>();
    }
}
