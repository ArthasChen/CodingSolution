using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

            Solution3 s = new Solution3();

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
    /// 解法二：用哈希表存原始node和克隆node，这样可以用O(n)的空间把时间复杂度从O(n^2)降低到的O(n)。
    /// 时间复杂度：O(n) 
    /// 空间复杂度：O(n)
    /// </summary>
    public class Solution2
    {
        Dictionary<Node, Node> dic = new Dictionary<Node, Node>();

        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Node cloneNodeHead = CopyBody(head);

            Node resultNodeHead = CopyRadom(head, cloneNodeHead);

            return resultNodeHead;
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

                // 原节点对应克隆节点，添加进哈希表
                dic[currentNode] = cloneNode;

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
            }

            return cloneNodeHead;
        }

        public Node CopyRadom(Node oriHead, Node copyNodeHead)
        {
            Node curOriNode = oriHead;
            Node curCloneNode = copyNodeHead;

            while (curOriNode != null)
            {
                if (curOriNode.random != null)
                {
                    curCloneNode.random = dic[curOriNode.random];
                }
                else
                {
                    curCloneNode.random = null;
                }

                curOriNode = curOriNode.next;
                curCloneNode = curCloneNode.next;
            }

            return copyNodeHead;
        }
    }

    /// <summary>
    /// 解法三：第一次遍历原链表时，构建的新节点添加在原节点后，这样就形成了 “原节点1-新节点1-原节点2-新节点2。。。” 这样一个新的链表。
    /// 在这个链表中对新节点添加Random节点的空间复杂度是O(n)，并且无需O(n)的额外空间。添加完Random节点后，分解链表，使原链表恢复，复制的链表拆分出来。整个算法遍历3次，时间复杂度是时间复杂度：O(n)。
    /// 时间复杂度：O(n) 
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution3
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            // clone copy链表的next，构建链表
            Node newNodeHead = CreateNewList(head);

            // 通过链表中原节点的random来给clone链表的random赋值
            newNodeHead = CloneRandomNode(newNodeHead);

            // 分解链表
            Node cloneNodeHead = DisconnectList(newNodeHead);

            return cloneNodeHead;
        }

        private Node CreateNewList(Node head)
        {
            Node curNode = head;
            Node curCloneNode = null;

            while (curNode != null)
            {
                curCloneNode = new Node(curNode.val);
                Node temNode = curNode.next;
                curNode.next = curCloneNode;
                curCloneNode.next = temNode;

                curNode = temNode;
            }

            return head;
        }

        private Node CloneRandomNode(Node newNodeHead)
        {
            Node curNode = newNodeHead;

            while (curNode != null)
            {
                if (curNode.random != null)
                {
                    curNode.next.random = curNode.random.next;
                }
                else
                {
                    curNode.next.random = null;
                }


                curNode = curNode.next.next;
            }

            return newNodeHead;
        }

        private Node DisconnectList(Node newNodeHead)
        {
            int counts = 1;

            Node curOriNode = newNodeHead;
            Node curCloneNode = newNodeHead.next;
            Node curCloneHead = newNodeHead.next;

            while (curOriNode != null)
            {
                Node temNode = curCloneNode.next;
                curOriNode.next = temNode;
                if (temNode != null)
                {
                    curCloneNode.next = temNode.next;
                }
                else
                {
                    curCloneNode.next = null;
                }

                curOriNode = curOriNode.next;
                curCloneNode = curCloneNode.next;
            }

            return curCloneHead;
        }
    }
}
