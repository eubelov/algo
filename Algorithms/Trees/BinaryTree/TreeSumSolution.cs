namespace Algorithms.Trees.BinaryTree;

public static class TreeSumSolution
{
    public static int TreeSumRecursive(TreeNode<int>? node)
    {
        if (node == null) return 0;

        return node.Value + TreeSumRecursive(node.Left) + TreeSumRecursive(node.Right);
    }
}
