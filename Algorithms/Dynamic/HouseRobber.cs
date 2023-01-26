using Xunit;

namespace Algorithms.Dynamic;

public class HouseRobber
{
    [Fact]
    public void Test()
    {
        // Rob(new[] { 1, 2, 3, 1 });
        // Rob(new[] { 2, 1, 1, 2 });
        Rob(new[] { 2, 7, 9, 3, 1 });
    }

    public int Rob(int[] nums)
    {
        var rob1 = 0;
        var rob2 = 0;

        foreach (var x in nums)
        {
            var tmp = Math.Max(x + rob1, rob2);
            rob1 = rob2;
            rob2 = tmp;
        }

        return rob2;
    }
}
