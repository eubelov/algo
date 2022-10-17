namespace Algorithms.Trees.BinaryTree;

public class Bfs
{
    public List<string> DoBfsIteratively(TreeNode? node)
    {
        if (node == null)
        {
            return new(0);
        }

        var result = new List<string>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current.Value);

            if (current.Left != null) queue.Enqueue(current.Left);

            if (current.Right != null) queue.Enqueue(current.Right);
        }

        Console.WriteLine(string.Join(" ", result));
        return result;
    }
}
