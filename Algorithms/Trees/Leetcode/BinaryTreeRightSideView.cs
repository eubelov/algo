using Xunit;

namespace Algorithms.Trees.Leetcode;

/// <summary>
/// https://leetcode.com/problems/binary-tree-right-side-view/
/// </summary>
public class BinaryTreeRightSideView
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            RightSideView(new(6, new(2, new(), new(4, new(3), new(5))), new(8, new(7), new(9))));
            RightSideView(new(6, new(2, new(), new(4, new(3), new(5))), new(8, new(7), new(9))));
            RightSideView(new(1, new(2, null, new(5)), new(3, null, new(4))));
        }

        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return new List<int>(0);

            var result = new List<int>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Any())
            {
                var ql = q.Count;
                for (var i = 0; i < ql; i++)
                {
                    var node = q.Dequeue();
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);

                    if (i == ql - 1) result.Add(node.val);
                }
            }

            return result;
        }
    }
}
