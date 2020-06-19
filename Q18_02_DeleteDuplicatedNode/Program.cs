using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

namespace Q18_02_DeleteDuplicatedNode
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(1);
            ListNode node3 = new ListNode(1);
            ListNode node4 = new ListNode(1);
            ListNode node5 = new ListNode(1);
            ListNode node6 = new ListNode(2);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = null;

            Solution s = new Solution();
            var sss = s.deleteDuplication(node1);
            while (sss != null)
            {
                Console.WriteLine(sss.val);
                sss = sss.next;
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
        public ListNode deleteDuplication(ListNode pHead)
        {
            // write code here
            ListNode preNode = null;
            ListNode currentNode = pHead;
            bool isRepeat = false;

            while (currentNode != null)
            {
                isRepeat = false;
                ListNode nextNode = currentNode.next;

                if (nextNode != null && currentNode.val == nextNode.val)
                {
                    isRepeat = true;
                }

                if (isRepeat)
                {
                    int value = currentNode.val;
                    while (currentNode.next != null && currentNode.next.val == value)
                    {
                        nextNode = nextNode.next;
                        currentNode.next = nextNode;
                    }

                    if (preNode == null)
                    {
                        pHead = nextNode;
                    }
                    else
                    {
                        currentNode = nextNode;
                        preNode.next = currentNode;
                    }

                    currentNode = nextNode;
                }
                else
                {
                    preNode = currentNode;
                    currentNode = nextNode;
                }

            }

            //while (currentNode != null)
            //{
            //    if (currentNode.next != null)
            //    {
            //        if (currentNode.val != currentNode.next.val)
            //        {
            //            if (isRepeat!=true)
            //            {
            //                preNode = currentNode;
            //                currentNode = currentNode.next;
            //            }
            //            else
            //            {
            //                isRepeat = false;
            //                currentNode.val = currentNode.next.val;
            //                currentNode.next = currentNode.next.next;
            //            }
            //        }
            //        else
            //        {
            //            isRepeat = true;
            //            currentNode.next = currentNode.next.next;
            //        }
            //    }
            //    else
            //    {
            //        if (preNode!=null)
            //        {
            //            if (isRepeat==true)
            //            {
            //                preNode.next = null;// default
            //            }
            //            else
            //            {

            //            }
            //        }
            //        else
            //        {
            //            if (isRepeat==true)
            //            {
            //                return null;
            //            }
            //        }
            //    }
            //}

            return pHead;
        }
    }
}
