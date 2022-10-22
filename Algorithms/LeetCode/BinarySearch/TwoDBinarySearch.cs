namespace Algorithms.LeetCode.BinarySearch;

/// <summary>
/// https://leetcode.com/problems/search-a-2d-matrix
/// </summary>
public class TwoDBinarySearch
{
    public bool SearchMatrix2(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var top = 0;
        var bottom = rows - 1;

        while (top <= bottom)
        {
            var mid = (top + bottom) / 2;
            if (target > matrix[mid][cols - 1])
            {
                top = mid + 1;
            }
            else if (target < matrix[mid][0])
            {
                bottom = mid - 1;
            }
            else
            {
                break;
            }
        }

        if (top > bottom)
        {
            return false;
        }

        var l = 0;
        var r = cols - 1;
        var row = (top + bottom) / 2;

        while (l <= r)
        {
            var mid = (l + r) / 2;
            if (matrix[row][mid] > target)
            {
                r = mid - 1;
            }
            else if (matrix[row][mid] < target)
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
            }
            else if (matrix[r0][c1] < target)
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
