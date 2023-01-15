using Algorithms.Trees.BinaryTree;
using Xunit;

namespace Algorithms.LinkedLists.Leetcode;

/// <summary>
/// https://leetcode.com/problems/merge-two-sorted-lists/description/
/// </summary>
public class MergeLinkedLists
{
    public static class Solution
    {
        [Fact]
        public static void Run()
        {
            MergeTwoLists(new(1, new(3, new(6))), new(1, new(3, new(6))));
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
            {
                return null;
            }

            var p1 = list1;
            var p2 = list2;

            var start = new ListNode();
            var next = start;
            while (p1 != null || p2 != null)
            {
                if (p1 is null && p2 is not null)
                {
                    next.val = p2.val;
                    p2 = p2.next;
                }
                else if (p1 is not null && p2 is null)
                {
                    next.val = p1.val;
                    p1 = p1.next;
                }
                else
                {
                    if (p1?.val < p2?.val)
                    {
                        next.val = p1.val;
                        p1 = p1.next;
                    }
                    else
                    {
                        next.val = p2.val;
                        p2 = p2.next;
                    }
                }

                if (p1?.val != null || p2?.val != null)
                {
                    next.next = new ListNode();
                    next = next.next;
                }
            }

            return start;
        }
    }
}
