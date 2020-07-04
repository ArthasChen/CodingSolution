using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q18_01_DeleteNodeInList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(3);
            ListNode n4 = new ListNode(4);
            n1.next = n2;
            n2.next = n3;
            n3.next = n4;

            ListNode nNull = null;

            ListNode n1Delte = new ListNode(10);

            Solution2 s = new Solution2();
            ListNode re = s.DeleteNode(n1Delte, 10);

            Console.ReadKey();
        }
    }


    /* Definition for singly-linked list.*/
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    /// <summary>
    /// Leetcode 题目
    /// 时间复杂度：O(n)，因为待删除值给的是数值，所以必须从头开始遍历。这一题Leetcode和剑指offer原题不同，后面会给出剑指offer原题的解法，原题更有意义。
    /// 空间复杂度：O(1),需要几个临时变量存储。
    /// </summary>
    public class Solution
    {
        public ListNode DeleteNode(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }

            ListNode currentNode = head;
            ListNode preNode = null;
            ListNode resuleHeadNode = head;

            while (currentNode != null)
            {
                if (currentNode.val == val)
                {
                    if (preNode == null)
                    {
                        resuleHeadNode = currentNode.next;
                    }
                    else
                    {
                        preNode.next = currentNode.next;
                    }
                    break;
                }
                else
                {
                    preNode = currentNode;
                    currentNode = currentNode.next;
                }
            }

            return resuleHeadNode;
        }
    }

    /// <summary>
    /// Leetcode 解法二
    /// 时间复杂度和空间复杂度同上，区别在于比较的时机不同，此方法在进入节点后，判断next的值是否是待删除的值，如果是，直接cur.next=cur.next.next,省去存储pre节点的变量。
    /// </summary>
    public class Solution2
    {
        public ListNode DeleteNode(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }

            ListNode resuleHeadNode = head;
            ListNode currentNode = head;

            if (currentNode.val == val)
            {
                resuleHeadNode = currentNode.next;
            }

            while (currentNode.next != null)
            {
                if (currentNode.next.val == val)
                {
                    currentNode.next = currentNode.next.next;
                    break;
                }
                else
                {
                    currentNode = currentNode.next;
                }
            }

            return resuleHeadNode;
        }
    }

    /// <summary>
    /// 剑指offer的原题
    /// 题目是给定单向链表的头指针和一个节点指针，定义一个函数，需要在O(1)的时间内删除该节点。
    /// 这题的重点在于时间要求，需要在O(1)的时间实现删除节点。因此不能采用从头遍历的思路。应该把待删除节点的下一个节点的值复制到待删除节点，然后把next指向下一个节点的next。
    /// 有三种情况：1.待删除节点位于链表中间。2.待删除节点位于链表尾部。3.链表只有1个节点，待删除节点就是这个节点。
    /// 还有一些条件需要考虑，就是待删除的节点必须包含在头节点指向的链表当中，这个需要在参数传入之前确认。
    /// </summary>
    public class SolutionJZOffer
    {
        public ListNode DeleteNode(ListNode head, ListNode toBeDeletedNode)
        {
            if (head == null)
            {
                return null;
            }

            // 1.待删除节点位于链表中间。
            if (toBeDeletedNode.next != null)
            {
                toBeDeletedNode.val = toBeDeletedNode.next.val;
                toBeDeletedNode.next = toBeDeletedNode.next.next;
            }
            // 3.链表只有1个节点，待删除节点就是这个节点
            else if (toBeDeletedNode.next == null && head.next == null)
            {
                head = null;
            }
            // 2.待删除节点位于链表尾部。
            else
            {
                ListNode curNode = head;
                while (curNode.next != toBeDeletedNode)
                {
                    curNode = curNode.next;
                }

                curNode.next = null;
            }

            return head;
        }
    }
}
