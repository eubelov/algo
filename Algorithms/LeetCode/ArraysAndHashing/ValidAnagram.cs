namespace Algorithms.LeetCode.ArraysAndHashing;

/// <summary>
/// https://leetcode.com/problems/valid-anagram
/// </summary>
public class ValidAnagramSolution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        var chars = new int[26];

        for (var i = 0; i < s.Length; i++)
        {
            chars[s[i] - 'a']++;
            chars[t[i] - 'a']--;
        }

        foreach (var x in chars)
        {
            if (x != 0)
            {
                return false;
            }
        }


        return true;
    }
}
