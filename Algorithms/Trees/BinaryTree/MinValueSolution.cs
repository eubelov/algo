using Algorithms.Trees.Leetcode;

namespace Algorithms.Trees.BinaryTree;

public static class MinValueSolution
{
    public static int MinValue(TreeNode node)
    {
        if (node == null) return int.MaxValue;

        var l = MinValue(node.left);
        var r = MinValue(node.right);

        var min = Math.Min(l, r);
        return node.val < min ? node.val : min;
    }
}
