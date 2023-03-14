using Algorithms.Graphs.Problems;
using FluentAssertions;
using Xunit;

namespace Algorithms.DataStructures;

public class TestDSU
{
    [Fact]
    public void Test()
    {
        var edges = new List<SimpleEdge>
        {
            new(1, 2),
            new(2, 3),
            new(3, 4),
            new(4, 1)
        };

        new DSU(edges.Count, edges).HasCycle().Should().BeTrue();

        var edges2 = new List<SimpleEdge>
        {
            new(1, 2),
            new(2, 3),
            new(3, 4)
        };

        new DSU(edges.Count, edges2).HasCycle().Should().BeFalse();
    }
}

/// <summary>
/// Union Find with path compression and union by rank
/// </summary>
public class DSU
{
    private readonly List<SimpleEdge> _edges;
    private readonly int[] _parents;
    private readonly int[] _ranks;

    public DSU(int c, List<SimpleEdge> edges)
    {
        _edges = edges;
        _parents = new int[c + 1];
        _ranks = new int[c + 1];
        for (var index = 0; index < _parents.Length; index++) _parents[index] = -1;
    }

    private int Find(int index)
    {
        if (_parents[index] == -1) return index;
        return _parents[index] = Find(_parents[index]);
    }

    private bool Union(int x, int y)
    {
        var px = Find(x);
        var py = Find(y);
        if (px == py) return false;
        // always point from the tree with lower rank to the tree with higher rank
        // so that the rank does not increase upon union
        if (_ranks[px] >= _ranks[py])
        {
            if (_ranks[px] == _ranks[py]) _ranks[py]++;
            _parents[py] = px;
        }
        else
        {
            _parents[px] = py;
        }

        return true;
    }

    public bool HasCycle()
    {
        foreach (var (from, to) in _edges)
            if (!Union(from, to))
                return true;

        return false;
    }
}