using Xunit;

namespace Algorithms.Sorting.Algorithms;

public class QuickSortImpl
{
    [Fact]
    public void Sort()
    {
        var arr = new[] { 7, 2, 1, 6, 8, 5, 3, 4 };
        QuickSort(arr, 0, arr.Length - 1);
    }

    public static void QuickSort(int[] array, int start, int end)
    {
        if (start < end)
        {
            var pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }
    }

    private static int Partition(int[] array, int start, int end)
    {
        var pivot = array[end];
        var pIndex = start;

        for (var i = start; i < end; i++)
            if (array[i] <= pivot)
            {
                (array[i], array[pIndex]) = (array[pIndex], array[i]);
                pIndex++;
            }

        (array[pIndex], array[end]) = (array[end], array[pIndex]);

        return pIndex;
    }
}
