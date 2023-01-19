using Xunit;

namespace Algorithms.Trees.Leetcode;

/// <summary>
/// https://leetcode.com/problems/binary-tree-level-order-traversal/
/// </summary>
public class BinaryTreeLevelOrderTraversal
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            LevelOrder(new(6, new(2, new(), new(4, new(3), new(5))), new(8, new(7), new(9))));
            LevelOrder(new(6, new(2, new(), new(4, new(3), new(5))), new(8, new(7), new(9))));
            LevelOrder(new(6));
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            if (root is { left: null, right: null })
                return new List<IList<int>>
                {
                    new List<int> { root.val },
                };

            var queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, 0));
            var result = new List<List<int>>();

            while (queue.Any())
            {
                var (item, level) = queue.Dequeue();
                if (item.left != null)
                    queue.Enqueue((item.left, level + 1));

                if (item.right != null)
                    queue.Enqueue((item.right, level + 1));

                if (result.Count < level + 1)
                {
                    result.Add(new());
                }

                result[level].Add(item.val);
            }

            return new List<IList<int>>(result);
        }
    }
}
