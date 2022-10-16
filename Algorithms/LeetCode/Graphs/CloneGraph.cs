using Algorithms.Graphs;

namespace Algorithms.LeetCode.Graphs;

/// <summary>
/// https://leetcode.com/problems/clone-graph
/// </summary>
public class GraphClone
{
    private readonly Dictionary<Node, Node> nodes = new();

    public Node CloneGraph(Node node)
    {
        //[[2,4],[1,3],[2,4],[1,3]]
        var node1 = new Node(1);
        var node2 = new Node(2);
        var node3 = new Node(3);
        var node4 = new Node(4);

        node1.neighbors.Add(node2);
        node1.neighbors.Add(node4);

        node2.neighbors.Add(node1);
        node2.neighbors.Add(node3);

        node3.neighbors.Add(node2);
        node3.neighbors.Add(node4);

        node4.neighbors.Add(node1);
        node4.neighbors.Add(node3);

        return Explore(node);
    }

    private Node Explore(Node node)
    {
        if (nodes.ContainsKey(node)) return nodes[node];

        nodes[node] = new Node(node.val);

        foreach (var n in node.neighbors) nodes[node].neighbors.Add(Explore(n));


        return nodes[node];
    }
}
