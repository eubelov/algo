namespace Algorithms.TwoPointers.Leetcode;

public class Stock
{
    /// <summary>
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock
    /// </summary>
    public int MaxProfit(int[] prices)
    {
        var max = 0;

        var l = 0;
        var r = 0;

        while (r < prices.Length)
        {
            var diff = prices[r] - prices[l];
            if (diff < 0)
            {
                l = r;
            }
            else if (diff > max)
            {
                max = diff;
            }

            r++;
        }


        return max;
    }
}
