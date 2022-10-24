namespace Algorithms.LeetCode.Tries;

/// <summary>
/// https://leetcode.com/problems/design-add-and-search-words-data-structure/
/// </summary>
public class TrieNode
{
    public readonly Dictionary<char, TrieNode> Children = new();
    public bool EndOfWord { get; set; }
};
public class WordDictionary
{
    private readonly TrieNode root = new();

    public void AddWord(string word)
    {
        var current = root;
        foreach (var c in word)
        {
            if (!current.Children.TryGetValue(c, out var next))
            {
                next = current.Children[c] = new();
            }

            current = next;
        }

        current.EndOfWord = true;
    }

    public bool Search(string word)
    {
        return SearchFrom(this.root, word, 0);
    }

    private bool SearchFrom(TrieNode node, string prefix, int from)
    {
        var currentLevel = node;
        for (var i = from; i < prefix.Length; i++)
        {
            var c = prefix[i];

            if (c == '.')
            {
                foreach (var child in currentLevel.Children)
                {
                    if (SearchFrom(child.Value, prefix, i + 1))
                    {
                        return true;
                    }
                }

                return false;
            }

            if (!currentLevel.Children.ContainsKey(c))
            {
                return false;
            }

            currentLevel = currentLevel.Children[c];
        }

        return currentLevel.EndOfWord;
    }
}
