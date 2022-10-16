namespace Algorithms.LeetCode.ArraysAndHashing;

/// <summary>
/// https://leetcode.com/problems/contains-duplicate
/// </summary>
public static class ContainsDuplicateSolution
{
    public static bool ContainsDuplicate(int[] nums)
    {
        var hashSet = new HashSet<int>();

        foreach (var x in nums)
        {
            if (!hashSet.Add(x))
            {
                return true;
            }
        }

        return false;
    }
}
