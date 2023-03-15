namespace Algorithms.Intervals.Leetcode;

/// <summary>
/// https://leetcode.com/problems/non-overlapping-intervals/
/// </summary>
public class OverlappingIntervals
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        var ordered = intervals.OrderBy(x => x[0]).ToArray();
        var res = 0;

        var prevEnd = ordered[0][1];
        for (var i = 1; i < ordered.Length; i++)
        {
            if (prevEnd > ordered[i][0])
            {
                prevEnd = Math.Min(prevEnd, ordered[i][1]);
                res++;
            }
        }

        return res;
    }
}
