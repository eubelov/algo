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

        var hash = new Dictionary<int, List<int>>();
        for (var index = 0; index < nums.Length; index++)
        {
            var x = nums[index];
            if (!hash.ContainsKey(x))
            {
                hash[x] = new();
            }

            hash[x].Add(index);
        }

        for (var index = 0; index < nums.Length; index++)
        {
            var num = nums[index];
            var search = target - num;
            if (hash.TryGetValue(search, out var ix))
            {
                var i2 = ix.SingleOrDefault(x => x != index, -1);
                if (i2 != -1)
                {
                    return new[] { index,  i2};
                }
            }
        }

        return Array.Empty<int>();
    }
}
