using Xunit;

namespace Algorithms.LinkedLists.Leetcode;

/// <summary>
/// https://leetcode.com/problems/reorder-list/description/
/// </summary>
public class ReorderList
{
    public static class Solution
    {
        [Fact]
        public static void Run()
        {
            ReorderList(new(1, new(2, new(3, new(4)))));
        }

        public static void ReorderList(ListNode head)
        {
            if (head == null)
            {
                return;
            }

            var slow = head;
            var fast = head.next;

            while (fast != null)
            {
                slow = slow.next;
                fast = fast?.next?.next;
            }

            var second = slow.next; // second half of the list
            slow.next = null; // split list into two
            ListNode prev = null;

            while (second != null)
            {
                var tmp = second.next;
                second.next = prev;
                prev = second;
                second = tmp;
            }

            var first = head;
            second = prev;

            // second is always shorter or equal first
            while (second != null)
            {
                var tmp1 = first.next;
                var tmp2 = second.next;

                first.next = second;
                second.next = tmp1;
                first = tmp1;
                second = tmp2;
            }
        }
    }
}
