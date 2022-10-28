namespace Algorithms.LeetCode.BinarySearch;

/// <summary>
/// https://leetcode.com/problems/koko-eating-bananas/
/// </summary>
public class KokoEatingBananas
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        var min = 1L;
        var max = (long)piles.Max();
        var res = max;
        while (min <= max)
        {
            var mid = (max + min) / 2L;
            var hours = 0L;
            foreach (var x in piles)
            {
                hours += (long)Math.Ceiling(x / (double)mid);
            }

            if (hours <= h)
            {
                res = Math.Min(res, mid);
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }

        return (int)res;
    }
}
