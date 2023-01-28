using Xunit;

namespace Algorithms.Trees.BinaryTree;

/// <summary>
/// https://leetcode.com/problems/binary-tree-maximum-path-sum/
/// </summary>
public class BinaryTreeMaximumPathSum
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            MaxPathSum(new(2, new(-1), new(-2)));
            MaxPathSum(new(-10, new(9), new(20, new(15), new(7))));
            MaxPathSum(new(5, new(4, new(11, new(7), new(2))), new(8, new(13), new(4, null, new(1)))));
            MaxPathSum(new(-3));
            MaxPathSum(new(1, new(2)));
            MaxPathSum(new(1, new(2), new(3)));
        }

        public int MaxPathSum(TreeNode root)
        {
            var max = root.val;

            int Dfs(TreeNode node)
            {
                if (node == null) return 0;

                var l = Dfs(node.left);
                var r = Dfs(node.right);

                var inflectionMax = node.val + l + r;
                var leftSubtreeMax = node.val + l;
                var rightSubtreeMax = node.val + r;

                var subtreeMax = Math.Max(leftSubtreeMax, Math.Max(rightSubtreeMax, node.val));
                max = Math.Max(subtreeMax, Math.Max(max, inflectionMax));

                return subtreeMax;
            }

            Dfs(root);

            return max;
        }
    }
}
