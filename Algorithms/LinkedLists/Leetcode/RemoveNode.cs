using Xunit;

namespace Algorithms.LinkedLists.Leetcode;

/// <summary>
/// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
/// </summary>
public class RemoveNode
{
    public static class Solution
    {
        [Fact]
        public static void Run()
        {
            RemoveNthFromEnd2(new(1, new(2, new(3, new(4)))), 1);
            RemoveNthFromEnd2(new(1, new(2, new(3, new(4)))), 2);
            RemoveNthFromEnd2(new(1, new(2, new(3, new(4)))), 3);
            RemoveNthFromEnd2(new(1, new(2, new(3, new(4)))), 4);
        }


        public static ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            var dummy = new ListNode(0, head);
            var left = dummy;
            var right = head;

            while (n > 0 && right != null)
            {
                n--;
                right = right.next;
            }

            while (left != null && right != null)
            {
                left = left.next;
                right = right.next;
            }

            left.next = left.next?.next;

            return dummy.next;
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null || n == 0)
            {
                return head;
            }

            if (head.next == null && n == 1)
            {
                return null;
            }


            var depth = 0;
            var x = -1;

            void Dfs(ListNode c)
            {
                depth++;
                if (c.next != null)
                {
                    Dfs(c.next);
                }
                else
                {
                    x = depth - n;
                }

                if (depth == x)
                {
                    c.next = c.next?.next;
                }

                depth--;
            }

            Dfs(head);

            if (x == 0)
            {
                head = head.next;
            }

            return head;
        }
    }
}
