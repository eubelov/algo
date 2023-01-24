using Xunit;

namespace Algorithms.ArraysAndHashing.Leetcode;

/// <summary>
/// https://leetcode.com/problems/top-k-frequent-elements
/// </summary>
public class MostFrequentElements
{
    [Fact]
    public void Test()
    {
        TopKFrequent(new[] { 1, 1, 1, 2, 2, 3 }, 2);
    }

    public int[] TopKFrequent(int[] nums, int k)
    {
        var freq = new Dictionary<int, int>();
        foreach (var x in nums)
            if (!freq.ContainsKey(x)) freq[x] = 1;
            else freq[x]++;

        var buckets = new List<int>?[nums.Length];
        foreach (var x in freq)
        {
            var list = buckets[x.Value - 1] ??= new List<int>();
            list.Add(x.Key);
        }

        var result = new List<int>();
        for (var i = buckets.Length - 1; i >= 0; i--)
            if (buckets[i] != null && buckets[i]!.Any())
                foreach (var n in buckets[i]!)
                {
                    result.Add(n);
                    if (result.Count == k) return result.ToArray();
                }

        return Array.Empty<int>();
    }

    public int[] TopKFrequent_Linq(int[] nums, int k)
    {
        var freq = new Dictionary<int, int>();
        foreach (var x in nums)
            if (!freq.ContainsKey(x))
                freq[x] = 1;
            else
                freq[x]++;

        var topK = freq.OrderByDescending(x => x.Value).Select(x => x.Key).Take(k);

        return topK.ToArray();
    }

}
