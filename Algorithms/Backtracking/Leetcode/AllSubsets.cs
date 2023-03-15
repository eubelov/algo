namespace Algorithms.Backtracking.Leetcode;

/// <summary>
/// https://leetcode.com/problems/subsets/
/// </summary>
public class AllSubsets
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>
        {
            new List<int>(0),
        };

        var subset = new List<int>();

        void Explore(int i)
        {
            if (i >= nums.Length) return;

            subset.Add(nums[i]);
            res.Add(new List<int>(subset));
            Explore(i + 1);

            subset.RemoveAt(subset.Count - 1);
            Explore(i + 1);
        }

        Explore(0);

        return res;
    }
}
