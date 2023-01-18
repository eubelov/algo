using Xunit;

namespace Algorithms.Trees.Leetcode;

/// <summary>
/// https://leetcode.com/problems/subtree-of-another-tree/
/// </summary>
public class SubtreeOfAnotherTree
{
    [Fact]
    public void Test()
    {
        IsSubtree(new(8, new(3, new(4, new(1), new(2)), new(5))), new(4, new(1), new(2)));
    }

    public bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        if (subRoot == null)
        {
            return true;
        }

        bool SameTree(TreeNode? x, TreeNode? y)
        {
            if (x == null && y == null) return true;
            if (x?.val != y?.val) return false;

            return SameTree(x?.left, y?.left) && SameTree(x?.right, y?.right);
        }

        bool Is(TreeNode? x, TreeNode? y)
        {
            if (y == null)
            {
                return true;
            }

            if (x == null)
            {
                return false;
            }

            if (SameTree(x, y))
            {
                return true;
            }

            return IsSubtree(x.left, y)  || IsSubtree(x.right, y);
        }

       return Is(root, subRoot);
    }
}
