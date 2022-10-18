namespace Algorithms.LeetCode.Trees;

/// <summary>
/// https://leetcode.com/problems/same-tree
/// </summary>
public class IsSameTreeSolution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        var visitedA = new List<int?>();
        var visitedB = new List<int?>();

        void Dfs(TreeNode? n, List<int?> visited)
        {
            visited.Add(n?.val);

            if (n?.left == null && n?.right == null)
            {
                return;
            }

            Dfs(n.left, visited);
            Dfs(n.right, visited);
        }

        Dfs(p, visitedA);
        Dfs(q, visitedB);

        return visitedA.SequenceEqual(visitedB);
    }

    /// <summary>
    /// No extra memory
    /// </summary>
    public bool IsSameTree2(TreeNode p, TreeNode q)
    {
        bool Dfs(TreeNode? x, TreeNode? y)
        {
            if (x?.val != y?.val)
            {
                return false;
            }

            if (x == null && y == null)
            {
                return true;
            }

            return  Dfs(x?.left, y?.left) && Dfs(x?.right, y?.right);
        }

        return Dfs(p, q);
    }
}
