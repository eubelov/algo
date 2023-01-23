using Xunit;

namespace Algorithms.Trees.Leetcode;

public class KthSmallestElementBST
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            KthSmallest(new(5, new(3, new(2, new(1)), new(4)), new(6)), 3);
            KthSmallest(new(5, new(4), new(6, new(3), new(7))), 2);
        }

        public int KthSmallest(TreeNode root, int k)
        {
            var result = -1;

            void Dfs(TreeNode node)
            {
                if (node == null || k == 0)
                {
                    return;
                }

                Dfs(node.left);
                if (--k == 0)
                {
                    result = node.val;
                }

                Dfs(node.right);
            }

            Dfs(root);

            return result;
        }

        public int KthSmallest1(TreeNode root, int k)
        {
            var q = new PriorityQueue<int, int>();
            void Dfs(TreeNode node)
            {
                if (node == null)
                {
                    return;
                }

                q.Enqueue(node.val, -node.val);
                if (q.Count > k)
                {
                    q.Dequeue();
                }

                Dfs(node.left);
                Dfs(node.right);
            }

            Dfs(root);

            return q.Dequeue();
        }
    }
}
