namespace Algorithms.LeetCode.Stack;

/// <summary>
/// https://leetcode.com/problems/evaluate-reverse-polish-notation/
/// </summary>
public class EvaluateReversePolishNotation
{
    public int EvalRPN(string[] tokens)
    {
        var operations = new HashSet<string> { "+", "-", "*", "/" };
        var stack = new Stack<string>();

        foreach (var c in tokens)
            if (operations.Contains(c))
            {
                var op2 = int.Parse(stack.Pop());
                var op1 = int.Parse(stack.Pop());

                var res = c switch
                {
                    "+" => op1 + op2,
                    "-" => op1 - op2,
                    "*" => op1 * op2,
                    "/" => op1 / op2,
                };

                stack.Push(res.ToString());
            }
            else
            {
                stack.Push(c);
            }

        return int.Parse(stack.Pop());
    }
}
