namespace Algorithms.BinarySearch.Algorithms;

/// <summary>
/// https://leetcode.com/problems/binary-search/submissions/
/// </summary>
public class BinarySearch
{
    public int Search(int[] nums, int target)
    {
        var l = 0;
        var r = nums.Length - 1;

        while (l <= r)
        {
            var mid = (l + r) / 2;
            if (nums[mid] > target)
            {
                r = mid - 1;
            }
            else if (nums[mid] < target)
            {
                l = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }
}
