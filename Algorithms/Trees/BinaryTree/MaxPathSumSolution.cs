using Algorithms.Trees.Leetcode;

namespace Algorithms.Trees.BinaryTree;

public static class MaxPathSumSolution
{
    public static int MaxPathSum(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.val + Math.Max(MaxPathSum(node.left), MaxPathSum(node.right));
    }
}
