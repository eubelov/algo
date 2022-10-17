namespace Algorithms.Trees.BinaryTree;

public class Dfs
{
    public List<string> DoDfsIteratively(TreeNode root)
    {
        var result = new List<string>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            result.Add(current.Value);

            if (current.Left != null) stack.Push(current.Left);

            if (current.Right != null) stack.Push(current.Right);
        }

        Console.WriteLine(string.Join(" ", result));
        return result;
    }

    public List<string> DoDfsRecursively(TreeNode? root)
    {
        if (root == null) return new List<string>(0);

        var leftValues = DoDfsRecursively(root.Left);
        var rightValues = DoDfsRecursively(root.Right);

        var result = new List<string> { root.Value };
        result.AddRange(leftValues);
        result.AddRange(rightValues);

        return result;
    }
}
