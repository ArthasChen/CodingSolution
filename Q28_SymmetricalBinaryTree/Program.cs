using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Q28_SymmetricalBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creat a tree
            TreeNode node1 = new TreeNode(8);
            TreeNode node2 = new TreeNode(6);
            TreeNode node3 = new TreeNode(6);
            TreeNode node4 = new TreeNode(5);
            TreeNode node5 = new TreeNode(7);
            TreeNode node6 = new TreeNode(7);
            TreeNode node7 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;

            //TreeNode node1 = new TreeNode(5);
            //TreeNode node2 = new TreeNode(5);
            //TreeNode node3 = new TreeNode(5);
            //TreeNode node4 = new TreeNode(5);
            //TreeNode node5 ;
            //TreeNode node6 ;
            //TreeNode node7 = new TreeNode(5);
            //TreeNode node8 = new TreeNode(5);
            //TreeNode node9;
            //TreeNode node10 = new TreeNode(5);

            //node1.left = node2;
            //node1.right = node3;
            //node2.left = node4;
            //node3.right = node7;
            //node4.left = node8;
            //node7.left = node10;

            Solution hh = new Solution();
            var s = hh.isSymmetrical(node1);

            Console.ReadKey();
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }

    class Solution
    {
        Queue<string> treeValue = new Queue<string>();
        public bool isSymmetrical(TreeNode pRoot)
        {
            if (pRoot == null)
            {
                return true;
            }

            // 前序遍历，把访问的节点放入队列
            PreOrderTraversalWithRecursive(pRoot);

            // 按照中右左的顺序遍历，每当访问节点的时候，从队列头部取出元素进行对比，如果相等，继续重复直到遍历结束或者队列为0，返回True;如果错误，则停止，返回false；
            Stack<object> stack = new Stack<object>();
            stack.Push(pRoot);

            while (stack.Count != 0)
            {
                //TreeNode treeNode = stack.Pop();
                var objectInStack = stack.Pop();

                //TreeNode treeNode = objectInStack as TreeNode;

                if (objectInStack is TreeNode)
                {
                    TreeNode treeNode = objectInStack as TreeNode;

                    if (treeNode.val.ToString() != treeValue.Dequeue())
                    {
                        return false;
                    }

                    if (treeNode.left != null)
                    {
                        stack.Push(treeNode.left);
                    }
                    else
                    {
                        stack.Push(new object());
                    }

                    if (treeNode.right != null)
                    {
                        stack.Push(treeNode.right);
                    }
                    else
                    {
                        stack.Push(new object());

                    }

                    continue;
                }

                if (objectInStack is object)
                {
                    if ("null" != treeValue.Dequeue())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PreOrderTraversalWithRecursive(TreeNode root)
        {
            if (root == null)
            {
                treeValue.Enqueue("null"); ;
                return;
            }

            treeValue.Enqueue(root.val.ToString());
            PreOrderTraversalWithRecursive(root.left);
            PreOrderTraversalWithRecursive(root.right);
        }

    }
}
