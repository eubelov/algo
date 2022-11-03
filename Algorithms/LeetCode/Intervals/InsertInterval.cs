namespace Algorithms.LeetCode.Intervals;

/// <summary>
/// https://leetcode.com/problems/insert-interval/
/// </summary>
public class InsertInterval
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var list = new List<int[]>();

        for (var i = 0; i < intervals.Length; i++)
            if (newInterval[1] < intervals[i][0])
            {
                list.Add(newInterval);
                list.AddRange(intervals.Skip(i));
                return list.ToArray();
            }
            else if (newInterval[0] > intervals[i][1])
            {
                list.Add(intervals[i]);
            }
            else
            {
                newInterval = new[] { Math.Min(newInterval[0], intervals[i][0]), Math.Max(newInterval[1], intervals[i][1]) };
            }

        list.Add(newInterval);

        return list.ToArray();
    }

    public int[][] Insert1(int[][] intervals, int[] newInterval)
    {
        var list = new List<int[]>(intervals)
        {
            newInterval,
        };

        var ordered = list.OrderBy(x => x[0]).ToList();
        var result = new List<int[]>
        {
            ordered[0],
        };
        for (var index = 1; index < ordered.Count; index++)
        {
            var interval = ordered[index];
            if (result[^1][1] >= interval[0])
                result[^1][1] = Math.Max(interval[1], result[^1][1]);
            else
                result.Add(interval);
        }

        return result.ToArray();
    }
}
