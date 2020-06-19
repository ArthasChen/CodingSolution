using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q23_EntryNodeInListLoop
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
            ListNode node6 = new ListNode(6);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node3;

            Solution s=new Solution();
            Console.WriteLine(s.EntryNodeOfLoop(node1).val.ToString());

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
        public ListNode EntryNodeOfLoop(ListNode pHead)
        {
            // write code here
            // 1.两个指针，一快一慢，如果相遇则证明有环，如果快的到了最后一个节点还未相遇则无环
            ListNode meetingNode = MeetingNode(pHead);
            if (meetingNode == null)
            {
                return null;
            }

            // 2.找到环的节点数n
            int numbersOfLoop = 1;
            ListNode pNode = meetingNode;
            if (pNode.next != null)
            {
                pNode = pNode.next;
                numbersOfLoop++;
            }
            while (pNode != meetingNode)
            {
                pNode = pNode.next;
                numbersOfLoop++;
            }

            // 3.两个指针，一个前进n个节点，一个从头，然后同时出发，当两个指针相遇，相遇的节点则为环的入口
            ListNode entryNode = null;

            ListNode beforeNode = pHead;
            ListNode afterNode = pHead;
            for (int i = 0; i < numbersOfLoop-1; i++)
            {
                beforeNode = beforeNode.next;
            }

            while (beforeNode != afterNode)
            {
                beforeNode = beforeNode.next;
                afterNode = afterNode.next;
            }

            entryNode = beforeNode;

            return entryNode;
        }

        public ListNode MeetingNode(ListNode pHead)
        {
            if (pHead == null)
            {
                return null;
            }

            ListNode pFast = pHead;
            ListNode pSlow = pHead;

            // 先走一步，不然循环的判断条件一开始就符合了
            if (pFast.next != null)
            {
                pFast = pFast.next;
                if (pFast.next != null)
                {
                    pFast = pFast.next;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            //pFast = pFast.next;
            //pFast = pFast.next;

            pSlow = pSlow.next;

            while (pFast != pSlow)
            {
                if (pFast.next != null)
                {
                    pFast = pFast.next;
                    if (pFast.next != null)
                    {
                        pFast = pFast.next;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }


                pSlow = pSlow.next;
            }

            // 结束While循环意味着Fast追上了Slow，因此返回Fast或者Slow都是同一个节点
            return pFast;
        }
    }
}
