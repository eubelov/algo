using Xunit;

namespace Algorithms.Trees.Leetcode;

/// <summary>
/// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/
/// </summary>
public class SerializeBinaryTree
{
    [Fact]
    public void Test()
    {
        var s = new Codec().serialize(new(1, new(2), new(3, new(4, new(6), new(7)), new(5))));
        var tree = new Codec().deserialize(s);
    }

    public class Codec
    {
        public string serialize(TreeNode root)
        {
            if (root == null) return string.Empty;
            var res = new List<string>();

            void Dfs(TreeNode node)
            {
                if (node == null)
                {
                    res.Add("N");
                    return;
                }

                res.Add(node.val.ToString());
                Dfs(node.left);
                Dfs(node.right);
            }

            Dfs(root);

            return string.Join(",", res);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            var i = 0;
            var arr = data.Split(",");

            TreeNode Build()
            {
                if (arr[i] == "N")
                    return null;

                var root = new TreeNode(int.Parse(arr[i]));
                i++;
                root.left = Build();
                i++;
                root.right = Build();
                return root;
            }

            return Build();
        }
    }
}
