namespace Algorithms.LeetCode.Stack;

/// <summary>
/// https://leetcode.com/problems/valid-parentheses/
/// </summary>
public class ValidParentheses
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        var map = new Dictionary<char, char>
        {
            ['('] = ')',
            ['{'] = '}',
            ['['] = ']',
        };

        foreach (var x in s)
        {
            if (x is '(' or '{' or '[')
            {
                stack.Push(x);
                continue;
            }

            if (!stack.Any() || map[stack.Pop()] != x)
            {
                return false;
            }
        }

        return !stack.Any();
    }
}
