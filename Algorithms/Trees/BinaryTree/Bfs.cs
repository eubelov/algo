using Algorithms.Trees.Leetcode;

namespace Algorithms.Trees.BinaryTree;

public class Bfs
{
    public List<int> DoBfsIteratively(TreeNode? node)
    {
        if (node == null)
        {
            return new(0);
        }

        var result = new List<int>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current.val);

            if (current.left != null) queue.Enqueue(current.left);

            if (current.right != null) queue.Enqueue(current.right);
        }

        Console.WriteLine(string.Join(" ", result));
        return result;
    }
}
