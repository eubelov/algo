namespace Algorithms.Trees.Leetcode;

/// <summary>
/// https://leetcode.com/problems/product-of-array-except-self/
/// </summary>
public class ProductOfArrayExceptSelf
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var prefix = new int[nums.Length];
        var postfix = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            prefix[i] = nums[i] * (i == 0 ? 1 : prefix[i - 1]);
            var right = nums.Length - i - 1;
            postfix[right] = nums[right] * (right == nums.Length -1? 1 : postfix[right+1]);
        }

        for (var index = 0; index < nums.Length; index++)
        {
            var pr = index - 1;
            var po = index + 1;

            var l = 1;
            if (pr >= 0)
            {
                l = prefix[pr];
            }

            var r = 1;
            if (po < nums.Length)
            {
                r = postfix[po];
            }

            nums[index] = l * r;
        }

        return nums;
    }
}
