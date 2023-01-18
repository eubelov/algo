namespace Algorithms.Trees.Leetcode;

public class DiameterOfBinaryTreeSolution
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        var left = Dfs(root.left, 0);
        var right = Dfs(root.right, 0);

        int Dfs(TreeNode? node, int depth)
        {
            if (node == null)
            {
                return depth;
            }

            return Math.Max(Dfs(node.left, depth + 1), Dfs(node.right, depth + 1));
        }

        return left + right;
    }

    public bool IsBalancedBinaryTree(TreeNode root)
    {
        var b = true;

        int Dfs(TreeNode? node, int depth)
        {
            if (!b)
            {
                return -1;
            }

            if (node == null)
            {
                return depth;
            }

            var lh = Dfs(node.left, depth + 1);
            var rh = Dfs(node.right, depth + 1);

            if (Math.Abs(lh - rh) > 1) b = false;

            return Math.Max(lh, rh);
        }

        Dfs(root, 0);

        return b;
    }
}
