namespace Algorithms.LeetCode.Intervals;

/// <summary>
/// https://leetcode.com/problems/insert-interval/
/// </summary>
public class InsertInterval
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var list = new List<int[]>(intervals)
        {
            newInterval,
        };

        var ordered = list.OrderBy(x => x[0]).ToList();
        var result = new List<int[]>()
        {
            ordered[0],
        };
        for (var index = 1; index < ordered.Count; index++)
        {
            var interval = ordered[index];
            if (result[^1][1] >= interval[0])
            {
                result[^1][1] = Math.Max(interval[1], result[^1][1]);
            }
            else
            {
                result.Add(interval);
            }
        }

        return result.ToArray();
    }
}
