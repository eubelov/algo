using Xunit;

namespace Algorithms.Stack.Leetcode;

/// <summary>
/// https://leetcode.com/problems/daily-temperatures/description/
/// </summary>
public class DailyTemperatures
{
    public static class Solution
    {
        [Fact]
        public static void Run()
        {
            DailyTemperatures(new[] { 73, 74, 75, 71, 69, 72, 76, 73 });
            DailyTemperatures(new[] { 30, 40, 50, 60 });
            DailyTemperatures(new[] { 30, 60, 90 });
            DailyTemperatures(new[] { 30 });
        }

        public static int[] DailyTemperatures(int[] temperatures)
        {
            var result = new int[temperatures.Length];
            var stack = new Stack<(int, int)>();

            for (var i = 0; i < temperatures.Length; i++)
            {
                while (stack.Any() && temperatures[i] > stack.Peek().Item1)
                {
                    var (_, ii) = stack.Pop();
                    result[ii] = i - ii;
                }

                stack.Push((temperatures[i], i));
            }

            return result;
        }
    }
}
