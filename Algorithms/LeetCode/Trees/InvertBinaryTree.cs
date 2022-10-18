namespace Algorithms.LeetCode.Trees;

/// <summary>
/// https://leetcode.com/problems/invert-binary-tree
/// </summary>
public class InvertBinaryTree
{
    public TreeNode? InvertTree(TreeNode? root)
    {
        if (root?.left == null && root?.right == null)
        {
            return root;
        }

        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var c = q.Dequeue();
            (c.left, c.right) = (c.right, c.left);
            if (c.left != null) q.Enqueue(c.left);
            if (c.right != null) q.Enqueue(c.right);
        }

        return root;
    }
}
