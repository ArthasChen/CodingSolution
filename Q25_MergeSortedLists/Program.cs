using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q25_MergeSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(1);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(1);
            ListNode node6 = new ListNode(6);

            node1.next = node3;
            node3.next = node5;
            node5.next = null;

            node2.next = node4;
            node4.next = node6;
            node6.next = null;

            Solution s = new Solution();
            var list = s.Merge(node1, node2);

            while (list != null)
            {
                Console.WriteLine(list.val);
                list = list.next;
            }



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
    class Solution
    {
        public ListNode Merge(ListNode pHead1, ListNode pHead2)
        {
            if (pHead1 == null)
            {
                return pHead2;
            }
            if (pHead2 == null)
            {
                return pHead1;
            }

            ListNode MergedHeadNode = null;

            if (pHead1.val < pHead2.val)
            {
                MergedHeadNode = pHead1;
                MergedHeadNode.next = Merge(pHead1.next, pHead2);
            }
            else
            {
                MergedHeadNode = pHead2;
                MergedHeadNode.next = Merge(pHead2.next, pHead1);
            }

            return MergedHeadNode;
        }
    }
}
