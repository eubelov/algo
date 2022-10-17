namespace Algorithms.Trees.BinaryTree;

public static class MinValueSolution
{
    public static int MinValue(TreeNode<int>? node)
    {
        if (node == null) return int.MaxValue;

        var l = MinValue(node.Left);
        var r = MinValue(node.Right);

        var min = Math.Min(l, r);
        return node.Value < min ? node.Value : min;
    }
}
