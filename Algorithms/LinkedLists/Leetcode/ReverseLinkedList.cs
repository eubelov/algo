using Xunit;

namespace Algorithms.LinkedLists.Leetcode;

/// <summary>
/// https://leetcode.com/problems/reverse-linked-list/description/
/// </summary>
public class ReverseLinkedList
{
    public static class Solution
    {
        public static ListNode ReverseListSequential(ListNode head)
        {
            if (head == null) return head;

            var stack = new Stack<int>();
            var current = head;
            while (current != null)
            {
                stack.Push(current.val);
                current = current.next;
            }

            ListNode start = null;
            ListNode next = null;
            if (stack.Count > 0) start = new ListNode(stack.Pop());

            var prev = start;

            while (stack.Count != 0)
            {
                prev.next = new ListNode(stack.Pop());
                prev = prev.next;
            }

            return start;
        }

        public static ListNode ReverseListRecursive(ListNode head)
        {
            if (head == null) return head;

            var start = new ListNode();
            ListNode prev;

            void Dfs(ListNode node)
            {
                if (node.next != null)
                {
                    Dfs(node.next);
                }
                else
                {
                    start = new ListNode(node.val);
                    prev = start;
                    return;
                }

                prev.next = new(node.val);
                prev = prev.next;
            }

            Dfs(head);

            return start;
        }
    }

    [Fact]
    public void Run()
    {
        Solution.ReverseListRecursive(new(1, new(2, new(3, new(4, new(5))))));
    }
}
