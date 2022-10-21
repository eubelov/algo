namespace Algorithms.LeetCode.BinarySearch;

public class TwoDBinarySearch
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var l = 0;
        var r = rows * cols - 1;

        while (l <= r)
        {
            var mid = (l + r) / 2;
            var r0 = (int)Math.Floor((double)mid / cols);
            var c1 = mid % cols;

            if (matrix[r0][c1] > target)
            {
                r = mid - 1;
            } else if (matrix[r0][c1] < target)
            {
                l = mid + 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
