namespace Algorithms.Trees.BinaryTree;

public static class MaxPathSumSolution
{
    public static int MaxPathSum(TreeNode<int>? node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Value + Math.Max(MaxPathSum(node.Left), MaxPathSum(node.Right));
    }
}
