namespace Algorithms.Backtracking.Leetcode;

public class CombinationSumSolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        var l = new List<int>();
        var sum = 0;

        void Dfs(int i)
        {
            if (i >= candidates.Length || sum > target) return;
            if (sum == target)
            {
                result.Add(new List<int>(l));
                return;
            }

            sum += candidates[i];
            l.Add(candidates[i]);
            Dfs(i);

            var value = l[^1];
            l.RemoveAt(l.Count - 1);
            sum -= value;
            Dfs(i + 1);
        }

        Dfs(0);

        return result;
    }
}
