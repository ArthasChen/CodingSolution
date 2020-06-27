using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q24_ReverseList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = null;


            Solution s = new Solution();
            var list = s.ReverseList(node1);

            while (list!=null)
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

    public class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            // write code here
            ListNode preNode = null;
            ListNode node = head;
            ListNode nextNode = null;

            while (node != null)
            {
                nextNode = node.next;

                //if (nextNode!=null)
                //{
                node.next = preNode;
                preNode = node;
                node = nextNode;
                //}
                //else
                //{
                //    node.next = preNode;
                //    node = nextNode;
                //}
            }

            return preNode;
        }
    }

    class SolutionNK
    {
        public ListNode ReverseList(ListNode pHead)
        {
            // write code here
            ListNode preNode = null;
            ListNode node = pHead;
            ListNode nextNode = null;

            while (node != null)
            {
                nextNode = node.next;

                //if (nextNode!=null)
                //{
                    node.next = preNode;
                    preNode = node;
                    node = nextNode;
                //}
                //else
                //{
                //    node.next = preNode;
                //    node = nextNode;
                //}
            }

            return preNode;
        }
    }
}
