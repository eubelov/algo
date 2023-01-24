using Algorithms.Trees.Leetcode;

namespace Algorithms.Trees.BinaryTree;

public class Dfs
{
    public List<int> DoDfsIteratively(TreeNode root)
    {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            result.Add(current.val);

            if (current.left != null) stack.Push(current.left);
            if (current.right != null) stack.Push(current.right);
        }

        Console.WriteLine(string.Join(" ", result));
        return result;
    }

    public List<int> DoDfsRecursively(TreeNode? root)
    {
        if (root == null) return new List<int>(0);

        var leftValues = DoDfsRecursively(root.left);
        var rightValues = DoDfsRecursively(root.right);

        var result = new List<int> { root.val };
        result.AddRange(leftValues);
        result.AddRange(rightValues);

        return result;
    }
}
