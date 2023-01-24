namespace Algorithms.Trees.Leetcode;

public static class TreeSumSolution
{
    public static int TreeSumRecursive(TreeNode node)
    {
        if (node == null) return 0;

        return node.val + TreeSumRecursive(node.left) + TreeSumRecursive(node.right);
    }
}
