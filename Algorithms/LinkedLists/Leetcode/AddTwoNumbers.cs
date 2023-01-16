using Xunit;

namespace Algorithms.LinkedLists.Leetcode;

public class AddTwoNumbers
{
    /// <summary>
    /// https://leetcode.com/problems/add-two-numbers/
    /// </summary>
    public static class Solution
    {
        [Fact]
        public static void Run()
        {
            AddTwoNumbers(new(9, new(9, new(9, new(9, new(9,new(9)))))), new(9, new(9, new(9, new(9)))));
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode();
            var current = dummy;
            var carry = 0;

            void Dfs(ListNode x, ListNode y)
            {
                if (x == null && y == null)
                {
                    if (carry != 0)
                    {
                        current.next = new(carry);
                    }

                    return;
                }

                var sum = (x?.val ?? 0) + (y?.val ?? 0) + carry;
                carry = sum / 10;
                var digit = sum % 10;
                current.next = new(digit);
                current = current.next;

                Dfs(x?.next, y?.next);
            }

            Dfs(l1, l2);

            return dummy.next;
        }
    }
}
