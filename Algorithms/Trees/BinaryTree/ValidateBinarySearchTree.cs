namespace Algorithms.Trees.BinaryTree;

/// <summary>
/// https://leetcode.com/problems/validate-binary-search-tree/description/
/// </summary>
public class ValidateBinarySearchTree
{
    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            bool Dfs(TreeNode x, long min, long max)
            {
                if (x == null) return true;
                return (min < x.val && x.val < max && Dfs(x.left, min, x.val) && Dfs(x.right, x.val, max));
            }

            return Dfs(root, long.MinValue, long.MaxValue);
        }
    }
}
