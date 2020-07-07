using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q52_FirstCommonNodesInLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode na = new ListNode(1);
            ListNode na1 = new ListNode(2);
            ListNode na2 = new ListNode(3);

            ListNode c1 = new ListNode(55);
            ListNode c2 = new ListNode(66);
            ListNode c3 = new ListNode(77);

            ListNode nb = new ListNode(-1);
            ListNode nb1 = new ListNode(-2);
            ListNode nb2 = new ListNode(-3);

            na.next = na1;
            na1.next = na2;
            na2.next = c1;
            c1.next = c2;
            c2.next = c3;

            nb.next = nb1;
            nb1.next = nb2;
            nb2.next = c1;

            Solution s = new Solution();
            var a = s.GetIntersectionNode(na, nb);

            Console.ReadKey();
        }
    }


    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    /* 暴力解法：遍历链表A，每访问到其中一个节点，遍历节点B，比较两个节点是否相同。
     * 时间复杂度：O(m+n)
     * 空间复杂度：O(1)
     */

    /// <summary>
    /// 解法一
    /// 时间复杂度：O(m+n)
    /// 空间复杂度：O(m+n)
    /// </summary>
    public class Solution
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode resultListNode = null;
            if (headA == null || headB == null)
            {
                return resultListNode;
            }

            Stack<ListNode> stackA = new Stack<ListNode>();
            ListNode curListNode = headA;
            while (curListNode != null)
            {
                stackA.Push(curListNode);
                curListNode = curListNode.next;
            }

            Stack<ListNode> stackB = new Stack<ListNode>();
            curListNode = headB;
            while (curListNode != null)
            {
                stackB.Push(curListNode);
                curListNode = curListNode.next;
            }

            while (stackA.Count != 0 && stackB.Count != 0)
            {
                if (stackA.Peek() == stackB.Peek())
                {
                    resultListNode = stackA.Pop();
                    stackB.Pop();
                }
                else
                {
                    break;
                }
            }

            return resultListNode;
        }
    }

    /// <summary>
    /// 解法二
    /// 时间复杂度：O(m+n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution2
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode resultListNode = null;
            if (headA == null || headB == null)
            {
                return resultListNode;
            }

            int lengOfListA = 0;
            int lengOfListB = 0;

            // 遍历A链表，记录长度
            ListNode curListNode = headA;
            while (curListNode != null)
            {
                lengOfListA++;
                curListNode = curListNode.next;
            }

            // 遍历B链表，记录长度
            curListNode = headB;
            while (curListNode != null)
            {
                lengOfListB++;
                curListNode = curListNode.next;
            }

            // 计算两个链表的长度差，长链表先往前遍历，直到剩余长度跟另一个链表一样。然后两个链表同时开始遍历，进行比较。
            ListNode headLongListNode = null;
            if (lengOfListA - lengOfListB >= 0)
            {
                int steps = lengOfListA - lengOfListB;
                headLongListNode = headA;
                while (steps > 0)
                {
                    headLongListNode = headLongListNode.next;
                    steps--;
                }

                ListNode curListNodeB = headB;
                while (headLongListNode != null)
                {
                    if (headLongListNode == curListNodeB)
                    {
                        resultListNode = headLongListNode;
                        break;
                    }
                    else
                    {
                        headLongListNode = headLongListNode.next;
                        curListNodeB = curListNodeB.next;
                    }
                }
            }
            else
            {
                int steps = lengOfListB-lengOfListA  ;
                headLongListNode = headB;
                while (steps > 0)
                {
                    headLongListNode = headLongListNode.next;
                    steps--;
                }

                ListNode curListNodeB = headA;
                while (headLongListNode != null)
                {
                    if (headLongListNode == curListNodeB)
                    {
                        resultListNode = headLongListNode;
                        break;
                    }
                    else
                    {
                        headLongListNode = headLongListNode.next;
                        curListNodeB = curListNodeB.next;
                    }
                }
            }

            return resultListNode;
        }
    }
}
