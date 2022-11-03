namespace Algorithms.LeetCode.Intervals;

/// <summary>
/// https://leetcode.com/problems/merge-intervals/
/// </summary>
public class MergeIntervals
{
    public int[][] Merge(int[][] intervals)
    {
        var result = new List<int[]>();
        var ordered = intervals.OrderBy(x => x[0]).ToList();

        result.Add(ordered[0]);

        foreach (var x in ordered.Skip(1))
        {
            if (result[^1][1] >= x[0])
            {
                result[^1][1] = Math.Max(x[1], result[^1][1]);
            }
            else
            {
                result.Add(x);
            }
        }

        return result.ToArray();
    }
}
