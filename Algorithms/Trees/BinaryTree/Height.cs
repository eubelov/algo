using Xunit;

namespace Algorithms.Trees.BinaryTree;

public class Height
{
    [Fact]
    public void Test()
    {
        var height = FindHeight(new(1, new(2, new(3, new(4)))));
    }

    public int FindHeight(TreeNode node)
    {
        int Dfs(TreeNode n)
        {
            if (n == null) return -1;
            return Math.Max(Dfs(n.left), Dfs(n.right)) + 1;
        }

        return Dfs(node);
    }
}
