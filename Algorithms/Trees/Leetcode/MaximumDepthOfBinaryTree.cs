namespace Algorithms.Trees.Leetcode;

/// <summary>
/// https://leetcode.com/problems/maximum-depth-of-binary-tree
/// </summary>
public class MaximumDepthOfBinaryTree
{
    public int MaxDepth(TreeNode? root)
    {
        return Dfs(root, 0);

        int Dfs(TreeNode? node, int depth)
        {
            if (node == null)
            {
                return depth;
            }

            var lD = Dfs(node.left, depth + 1);
            var rD = Dfs(node.right, depth + 1);

            return Math.Max(lD, rD);
        }
    }
}
