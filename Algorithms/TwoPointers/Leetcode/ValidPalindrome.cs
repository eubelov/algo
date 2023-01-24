using System.Text;

namespace Algorithms.TwoPointers.Leetcode;

/// <summary>
/// https://leetcode.com/problems/valid-palindrome/
/// </summary>
public class ValidPalindrome
{
    /// <summary>
    /// Uses extra memory.
    /// </summary>
    public bool IsPalindrome2(string s)
    {
        if (s.Length <= 1) return true;

        var sb = new StringBuilder(s.Length);

        foreach (var c in s.ToLower())
            if (c is >= 'a' and <= 'z' or >= '0' and <= '9')
                sb.Append(c);

        var sanitizedString = sb.ToString();
        var start = 0;
        var end = sanitizedString.Length - 1;

        while (start <= end)
        {
            if (sanitizedString[start] != sanitizedString[end]) return false;

            start++;
            end--;
        }

        return true;
    }

    /// <summary>
    /// No extra memory, super fast.
    /// </summary>
    /// <returns></returns>
    public bool IsPalindrome(string s)
    {
        if (s.Length <= 1) return true;

        var start = 0;
        var end = s.Length - 1;

        static bool IsUpper(char c) => c is >= 'A' and <= 'Z';
        static bool IsAlphaNumeric(char c) => c is >= 'a' and <= 'z' || IsUpper(c) || c is >= '0' and <= '9';
        static char ToLower(char c) => IsUpper(c) ? (char)(c + ' ') : c;

        while (start <= end)
        {
            if (!IsAlphaNumeric(s[start]))
            {
                start++;
                continue;
            }

            if (!IsAlphaNumeric(s[end]))
            {
                end--;
                continue;
            }

            if (ToLower(s[start]) != ToLower(s[end]))
            {
                return false;
            }

            start++;
            end--;
        }

        return true;
    }
}
