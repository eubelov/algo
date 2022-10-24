namespace Algorithms.DataStructures;

/// <summary>
/// https://leetcode.com/problems/implement-trie-prefix-tree/
/// </summary>
public class TrieNode
{
    public readonly Dictionary<char, TrieNode> Children = new();

    public bool EndOfWord { get; set; }
}
public class Trie
{
    private readonly TrieNode _root = new();

    public Trie()
    {
    }

    public void Insert(string word)
    {
        var current = _root;
        foreach (var c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                current.Children[c] = new();
            }

            current = current.Children[c];
        }

        current.EndOfWord = true;
    }

    public bool Search(string word)
    {
        var current = _root;
        foreach (var c in word)
        {
            if (current.Children.TryGetValue(c, out var next))
            {
                current = next;
            }
            else
            {
                return false;
            }
        }

        return current.EndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        var current = _root;
        foreach (var c in prefix)
        {
            if (current.Children.TryGetValue(c, out var next))
            {
                current = next;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
