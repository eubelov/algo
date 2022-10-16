namespace Algorithms.LeetCode.ArraysAndHashing;

/// <summary>
/// https://leetcode.com/problems/valid-anagram
/// </summary>
public class ValidAnagramSolution
{
    public bool IsAnagram(string s, string t)
    {
        var hashSet = new Dictionary<char, int>();
        foreach (var x in s)
        {
            if (!hashSet.ContainsKey(x))
            {
                hashSet.Add(x, 1);
                continue;
            }

            hashSet[x]++;
        }

        foreach (var y in t)
        {
            if (!hashSet.TryGetValue(y, out var count))
            {
                return false;
            }

            if (count == 0)
            {
                return false;
            }

            hashSet[y]--;
        }

        return hashSet.All(x => x.Value == 0);
    }
}
