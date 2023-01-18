namespace Algorithms.Stack.Leetcode;

/// <summary>
/// https://leetcode.com/problems/generate-parentheses/
/// </summary>
public class GenerateParenthesisSolution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var results = new List<string>();

        void Backtrack(int open, int closed, string c)
        {
            if (open == closed && open == n)
            {
                results.Add(c);
                return;
            }

            if (open < n)
            {
                Backtrack(open + 1, closed, c + '(');
            }

            if (closed < open)
            {
                Backtrack(open, closed + 1, c + ')');
            }
        }

        Backtrack(0, 0, string.Empty);

        return results;
    }
}
