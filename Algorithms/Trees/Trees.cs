using Xunit;

namespace Algorithms.Trees;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public static class TreeExtensions
{
    [Fact]
    public static void Test()
    {
        var root = ((TreeNode?)null).Insert(15);
        foreach (var x in new[] { 15, 10, 20, 25, 8, 12 }) root.Insert(x);

        var r1 = root.Search(8);
        var r2 = root.Search(25);
        var r3 = root.Search(555);
    }

    public static TreeNode Insert(this TreeNode root, int data)
    {
        if (root == null) return new(data);

        if (data <= root.val)
            root.left = Insert(root.left, data);
        else
            root.right = Insert(root.right, data);

        return root;
    }

    public static bool Search(this TreeNode root, int data)
    {
        if (root == null) return false;

        if (root.val == data) return true;

        if (root.val >= data)
            return Search(root.left, data);
        return Search(root.right, data);
    }
}
