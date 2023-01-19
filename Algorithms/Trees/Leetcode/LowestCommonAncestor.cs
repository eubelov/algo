using Xunit;

namespace Algorithms.Trees.Leetcode;

/// <summary>
/// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
/// </summary>
public class LowestCommonAncestor
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            LowestCommonAncestor(new(6, new(2, new(), new(4, new(3), new(5))), new(8, new(7), new(9))), new(2), new(8));
            LowestCommonAncestor(new(6, new(2, new(), new(4, new(3), new(5))), new(8, new(7), new(9))), new(2), new(4));
            LowestCommonAncestor(new(6), new(6), new(6));
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var curr = root;
            while (curr != null)
            {
                if (p.val > curr.val && q.val > curr.val)
                {
                    curr = curr.right;
                } else if (p.val < curr.val && q.val < curr.val)
                {
                    curr = curr.left;
                }
                else
                {
                    return curr;
                }
            }

            return null;
        }

        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            var path1 = new List<TreeNode>();
            var path2 = new List<TreeNode>();

            bool Dfs(TreeNode x, List<TreeNode> path, int target)
            {
                if (x == null) return false;

                path.Add(x);
                if (x.val == target) return true;

                var foundLeft = Dfs(x.left, path, target);
                if (foundLeft) return true;


                var foundRight = Dfs(x.right, path, target);
                if (foundRight) return true;

                path.Remove(x);
                return false;
            }

            Dfs(root, path1, p.val);
            Dfs(root, path2, q.val);

            for (var i = path1.Count - 1; i >= 0; i--)
            {
                var x = path1[i];
                if (path2.Contains(x)) return x;
            }

            return null;
        }
    }
}
