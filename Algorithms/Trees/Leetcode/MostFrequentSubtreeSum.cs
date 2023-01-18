using Xunit;

namespace Algorithms.Trees.Leetcode;

/// <summary>
/// https://leetcode.com/problems/most-frequent-subtree-sum/
/// </summary>
public class MostFrequentSubtreeSum
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            FindFrequentTreeSum(new(5, new(14, new(1))));
        }

        public int[] FindFrequentTreeSum(TreeNode root)
        {
            if (root.left == null && root.right == null)
            {
                return new[] { root.val };
            }

            var sums = new Dictionary<int, int>();

            void Add(int val)
            {
                if (!sums.ContainsKey(val))
                {
                    sums[val] = 0;
                }

                sums[val]++;
            }

            int Dfs(TreeNode x)
            {
                if (x == null)
                {
                    return 0;
                }

                var sum = x.val + Dfs(x.left) + Dfs(x.right);
                Add(sum);

                return sum;
            }

            Dfs(root);

            var mostFrequent = sums.Max(x => x.Value);

            return sums.Where(x => x.Value == mostFrequent).Select(x => x.Key).ToArray();
        }
    }
}
