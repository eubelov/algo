namespace Algorithms.Search;

public class BinarySearch
{
    private int Search(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;

        while (low != high)
        {
            var mid = (high - low) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[mid] > target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return nums[low] == target ? low : -1;
    }
}
