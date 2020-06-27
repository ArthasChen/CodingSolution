using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQ22_KthNodeFromEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(3);
            ListNode n4 = new ListNode(4);
            ListNode n5 = new ListNode(5);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = null;

            SolutionNK s = new SolutionNK();
            var ssFindKthToTailout = s.FindKthToTail(n1, 1);
            Console.WriteLine(ssFindKthToTailout.val.ToString());
            Console.ReadKey();
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }

    public class Solution
    {
        public ListNode GetKthFromEnd(ListNode head, int k)
        {
            if (head == null)
            {
                return head;
            }

            if (k - 1 < 0)
            {
                return null;
            }
            // write code here
            int count = 0;
            ListNode p1 = head;
            ListNode p2 = head;

            while (count < k - 1)
            {
                if (p1.next != null)
                {
                    p1 = p1.next;
                    count++;
                }
                else
                {
                    return null;
                }

            }

            while (p1.next != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p2;
        }
    }

    class SolutionNK
    {
        public ListNode FindKthToTail(ListNode head, int k)
        {
            if (head == null)
            {
                return head;
            }

            if (k - 1 < 0)
            {
                return null;
            }
            // write code here
            int count = 0;
            ListNode p1 = head;
            ListNode p2 = head;

            while (count < k - 1)
            {
                if (p1.next != null)
                {
                    p1 = p1.next;
                    count++;
                }
                else
                {
                    return null;
                }

            }

            while (p1.next != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p2;
        }
    }
}
