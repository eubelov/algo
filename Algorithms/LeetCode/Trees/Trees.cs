namespace Algorithms.LeetCode.Trees;

public class Trees
{
    public static readonly TreeNode Tree = new(1);

    static Trees()
    {
        Tree.left = new(2, new(3, new(4), new(4)), new(3));
        Tree.right = new(2);
    }
}
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
