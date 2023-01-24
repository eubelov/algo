using System.Text;

namespace Algorithms.ArraysAndHashing.Leetcode;

/// <summary>
/// https://leetcode.com/problems/group-anagrams/
/// </summary>
public class GroupAnagramsSolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dict = new Dictionary<string, List<string>>();
        foreach (var s in strs)
        {
            var key = ArrToStr(s);
            if (!dict.TryGetValue(key, out var list))
            {
                dict[key] = new() { s };
            }
            else
            {
                list.Add(s);
            }
        }

        return new List<IList<string>>(dict.Values);
    }

    private string ArrToStr(string s)
    {
        var arr = new int[26];
        foreach (var c in s.ToCharArray())
        {
            arr[c - 'a']++;
        }

        var sb = new StringBuilder(1000);
        foreach (var c in arr) sb.Append($"{c}_");

        return sb.ToString();
    }
}
