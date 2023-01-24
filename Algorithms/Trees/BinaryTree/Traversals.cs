using Xunit;

namespace Algorithms.Trees.BinaryTree;

public class Traversals
{
    [Fact]
    public void Test()
    {
        PreOrder(new(5, new(3, new(2, new(1)), new(4)), new(6)));
        InOrder(new(5, new(3, new(2, new(1)), new(4)), new(6)));
        PostOrder(new(5, new(3, new(2, new(1)), new(4)), new(6)));
    }

    public void PreOrder(TreeNode root)
    {
        void Dfs(TreeNode node)
        {
            if (node == null) return;

            Console.WriteLine(node.val);

            Dfs(node.left);
            Dfs(node.right);
        }

        Dfs(root);
    }

    public void InOrder(TreeNode root)
    {
        void Dfs(TreeNode node)
        {
            if (node == null) return;

            Dfs(node.left);
            Console.WriteLine(node.val);
            Dfs(node.right);
        }

        Dfs(root);
    }

    public void PostOrder(TreeNode root)
    {
        void Dfs(TreeNode node)
        {
            if (node == null) return;

            Dfs(node.left);
            Dfs(node.right);
            Console.WriteLine(node.val);
        }

        Dfs(root);
    }
}
