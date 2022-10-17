namespace Algorithms.Trees.BinaryTree;

public sealed record TreeNode(string Value)
{
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }
}


public sealed record TreeNode<T>(T Value)
{
    public TreeNode<T>? Left { get; set; }
    public TreeNode<T>? Right { get; set; }
}

