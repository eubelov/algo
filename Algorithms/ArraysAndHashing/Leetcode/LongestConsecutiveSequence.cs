namespace Algorithms.ArraysAndHashing.Leetcode;

/// <summary>
/// https://leetcode.com/problems/longest-consecutive-sequence
/// </summary>
public class LongestConsecutiveSequence
{
    public int LongestConsecutive(int[] nums)
    {
        var hash = new HashSet<int>(nums);
        var longest = 0;

        foreach (var x in hash)
        {
            var l = 1;
            var y1 = x;
            var y2 = x;
            while (hash.Contains(++y1))
            {
                hash.Remove(y1);
                l++;
            }

            while (hash.Contains(--y2))
            {
                hash.Remove(y2);
                l++;
            }

            longest = Math.Max(longest, l);
        }

        return longest;
    }
}
