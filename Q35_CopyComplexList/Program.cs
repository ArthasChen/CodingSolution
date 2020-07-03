using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q35_CopyComplexList
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            n1.next = n2;
            n1.random = n3;
            n2.next = n3;
            n2.random = n4;
            n3.next = n4;
            n3.random = n1;

            Node n11 = new Node(1);

            Solution s = new Solution();

            var aaa = s.CopyRandomList(n1);

            Console.ReadKey();
        }
    }

    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    /// <summary>
    /// 解法一：最朴素的解法。
    /// 先按照顺序，按照next属性复制好新的链表。然后遍历原链表每一个节点，在访问的时候，记录random在原链表中的序号（或者索引），在新链表中通过序号（或者索引）找到，然后赋给新链表的Random属性，
    /// 时间复杂度：O(n^2)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        private int length = 0;

        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            return CopyRadom(head, CopyBody(head));
        }

        public Node CopyBody(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Node currentNode = head;
            Node preCloneNode = null;
            Node cloneNodeHead = null;

            while (currentNode != null)
            {
                Node cloneNode = new Node(currentNode.val);
                if (preCloneNode != null)
                {
                    preCloneNode.next = cloneNode;
                }
                else
                {
                    cloneNodeHead = cloneNode;
                }

                preCloneNode = cloneNode;
                currentNode = currentNode.next;

                length++;
            }

            return cloneNodeHead;
        }

        public Node CopyRadom(Node oriHead, Node copyNodeHead)
        {
            Node curNode = oriHead;
            Node random = curNode.random;
            Node curCopyNode = copyNodeHead;
            Node preCopyNode = null;
            int stepCounts = 0;

            while (curNode != null)
            {
                int temCounts = 0;

                Node temRandom = curNode.random;
                if (temRandom == null)
                {
                    curCopyNode.random = null;
                }
                else
                {
                    while (temRandom != null)
                    {
                        temRandom = temRandom.next;
                        temCounts++;
                    }

                    stepCounts = length - temCounts;

                    Node t = copyNodeHead;

                    while (stepCounts != 0)
                    {
                        if (t != null)
                        {
                            t = t.next;
                            stepCounts--;
                        }

                    }


                    curCopyNode.random = t;
                }

                

                curCopyNode = curCopyNode.next;
                curNode = curNode.next;
            }

            return copyNodeHead;
        }
    }

    /// <summary>
    /// 解法二：
    /// </summary>
    public class Solution2
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            return null;
        }

        
    }
}
