using Xunit;

namespace Algorithms.LinkedLists.Leetcode;

/// <summary>
/// https://leetcode.com/problems/linked-list-cycle/description/
/// </summary>
public class Cycle
{
    public class Solution
    {
        [Fact]
        public void Test()
        {
            var last = new ListNode(4);
            var second = new ListNode(2, new(3, last));
            HasCycle(new ListNode(1, second));
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            var visited = new HashSet<ListNode>();

            bool Dfs(ListNode n)
            {
                if (n == null) return false;
                if (visited.Add(n)) return Dfs(n.next);
                return true;
            }

            var res = Dfs(head);
            return res;
        }
    }
}
