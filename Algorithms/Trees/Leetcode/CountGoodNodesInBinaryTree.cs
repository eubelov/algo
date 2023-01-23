using Xunit;

namespace Algorithms.Trees.Leetcode;

/// <summary>
/// https://leetcode.com/problems/count-good-nodes-in-binary-tree/description/
/// </summary>
public class CountGoodNodesInBinaryTree
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            //GoodNodes(new(3, new(1, new(3)), new(4, new(1), new(5))));
            GoodNodes(new(3, new(3, new(4), new(2))));
        }

        public int GoodNodes(TreeNode root)
        {
            var result = 0;
            var max = root.val;

            void Dfs(TreeNode node)
            {
                if (node == null)
                {
                    return;
                }

                var prevMax = max;
                max = Math.Max(node.val, max);
                if (max <= node.val)
                {
                    result++;
                }

                if (node.left != null)
                    Dfs(node.left);
                if (node.right != null)
                    Dfs(node.right);

                max = prevMax;
            }

            Dfs(root);

            return result;
        }
    }
}
