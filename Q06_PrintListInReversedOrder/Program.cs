using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06_PrintListInReversedOrder
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
            List<int> list = s.printListFromTailToHead(node1);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i] + "  ");
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
        // 返回从尾到头的列表值序列
        public List<int> printListFromTailToHead(ListNode listNode)
        {
            return Method2(listNode);
        }

        // 用stack来实现
        public List<int> Method1(ListNode listNode)
        {
            // write code here
            List<int> listResult = new List<int>();
            ListNode node = listNode;

            Stack<ListNode> stack = new Stack<ListNode>();
            while (node != null)
            {
                stack.Push(node);
                node = node.next;
            }

            while (stack.Count > 0)
            {
                ListNode temNode = stack.Pop();
                listResult.Add(temNode.val);
            }

            return listResult;
        }

        // 用数组，反向读写
        public List<int> Method2(ListNode listNode)
        {
            // write code here
            List<int> listResult = new List<int>();
            List<int> listResult2 = new List<int>();

            ListNode node = listNode;



            while (node != null)
            {
                listResult.Add(node.val);
                node = node.next;
            }

            for (int i = listResult.Count - 1; i > -1; i--)
            {
                listResult2.Add(listResult[i]);
            }

            return listResult2;
        }
    }
}
