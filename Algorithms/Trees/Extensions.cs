using Algorithms.Trees.Leetcode;

namespace Algorithms.Trees;

public static class Extensions
{
    public static TreeNode ConvertToTree(this int[] array)
    {
        if (array.Length == 0) return null;
        return CreateTree(array, 0, array.Length - 1);
    }

    private static TreeNode CreateTree(int[] array, int start, int end)
    {
        if (start > end) return null;

        var mid = (start + end) / 2;
        var root = new TreeNode(array[mid])
        {
            left = CreateTree(array, start, mid - 1),
            right = CreateTree(array, mid + 1, end),
        };
        return root;
    }
}
