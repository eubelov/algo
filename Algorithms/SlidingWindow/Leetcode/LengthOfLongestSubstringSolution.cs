namespace Algorithms.SlidingWindow.Leetcode;

/// <summary>
/// https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// </summary>
public class LengthOfLongestSubstringSolution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s == string.Empty) return 0;

        var set = new HashSet<char>();
        var l = 0;
        var max = 0;

        for (var r = 0; r < s.Length; r++)
        {
            while (set.Contains(s[r]))
            {
                set.Remove(s[l]);
                l++;
            }

            set.Add(s[r]);
            max = Math.Max(max, r - l + 1);
        }

        return max;
    }

    public int LengthOfLongestSubstring2(string s)
    {
        if (s == string.Empty) return 0;

        var i = 0;
        var max = 0;
        var currentMax = 0;
        var positions = new Dictionary<char, int>();

        while (i < s.Length)
            if (positions.TryAdd(s[i], i))
            {
                currentMax++;
                i++;
            }
            else
            {
                i = positions[s[i]] + 1;
                positions.Clear();
                if (currentMax > max) max = currentMax;
                currentMax = 0;
            }

        if (currentMax > max) max = currentMax;

        return max;
    }
}
