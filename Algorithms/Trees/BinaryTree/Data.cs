namespace Algorithms.Trees.BinaryTree;

public static class Data
{
    public static readonly TreeNode Root = new("a");
    public static readonly TreeNode<int> IntTreeRoot = new(5);

    static Data()
    {
        var b = new TreeNode("b");
        var c = new TreeNode("c");
        var d = new TreeNode("d");
        var e = new TreeNode("e");
        var f = new TreeNode("f");

        Root.Left = b;
        Root.Right = c;
        b.Left = d;
        b.Right = e;
        c.Right = f;

        var b1 = new TreeNode<int>(11);
        var c1 = new TreeNode<int>(3);
        var d1 = new TreeNode<int>(4);
        var e1 = new TreeNode<int>(2);
        var f1 = new TreeNode<int>(1);

        IntTreeRoot.Left = b1;
        IntTreeRoot.Right = c1;
        b1.Left = d1;
        b1.Right = e1;
        c1.Right = f1;
    }
}
