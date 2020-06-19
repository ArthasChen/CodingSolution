using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08_NextNodeInBinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class TreeLinkNode
    {
        public int val;
        public TreeLinkNode left;
        public TreeLinkNode right;
        public TreeLinkNode next;
        public TreeLinkNode(int x)
        {
            val = x;
        }
    }

    class Solution
    {
        public TreeLinkNode GetNext(TreeLinkNode pNode)
        {
            // pNode有右树，所以下一个节点必然在右树里
            if (pNode.right != null)
            {
                TreeLinkNode rightNode = pNode.right;

                // 如果右树有很多左树，则输出的的是左树的左树。。。。
                while (rightNode.left != null)
                {
                    rightNode = rightNode.left;
                }

                return rightNode;
            }

            // pNode无右树，且不为根节点
            if (pNode.next != null)
            {
                TreeLinkNode cur = pNode;
                TreeLinkNode parent = pNode.next;

                while (parent != null && cur == parent.right)
                {
                    cur = parent;
                    parent = parent.next;

                }

                return parent;
            }

            // pNode为根且无右树
            return null;
        }
    }
}
