namespace Algorithms.Trees.BinaryTree;

public class TreeContainsSolution
{

    public bool TreeContains(TreeNode? node, string target)
    {
        if (node == null) return false;
        if (node.Value == target) return true;

        return TreeContains(node.Left, target) || TreeContains(node.Right, target);
    }

    public bool TreeContainsBfs(TreeNode? node, string target)
    {
        if (node == null) return false;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c.Value == target) return true;

            if (c.Left != null) queue.Enqueue(c.Left);
            if (c.Right != null) queue.Enqueue(c.Right);
        }

        return false;
    }
}
