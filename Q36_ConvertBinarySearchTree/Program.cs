using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Q36_ConvertBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creat a tree
            TreeNode node1 = new TreeNode(6);
            TreeNode node2 = new TreeNode(3);
            TreeNode node3 = new TreeNode(8);
            TreeNode node4 = new TreeNode(1);
            TreeNode node5 = new TreeNode(4);
            TreeNode node6 = new TreeNode(7);
            TreeNode node7 = new TreeNode(9);

            //node1.left = node2;
            //node1.right = node3;
            //node2.left = node4;
            //node2.right = node5;
            //node3.left = node6;
            //node3.right = node7;

            Solution s=new Solution();
            var head = s.Convert(node1);

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
        private Queue<TreeNode> treeQueue = new Queue<TreeNode>();

        public TreeNode Convert(TreeNode pRootOfTree)
        {
            if (pRootOfTree == null)
            {
                return null;
            }

            // 按照中序遍历，把节点都放进队列
            InOrderTraversalWithRecursive(pRootOfTree);

            TreeNode preTreeNode = null;
            TreeNode curTreeNode = null;
            TreeNode headTreeNode = null;
            TreeNode tailTreeNode = null;

            // 出队，按顺序给节点赋值
            preTreeNode = treeQueue.Dequeue();
            preTreeNode.left = null;
            headTreeNode = preTreeNode;

            while (treeQueue.Count != 0)
            {
                curTreeNode= treeQueue.Dequeue();
                preTreeNode.right = curTreeNode;
                curTreeNode.left = preTreeNode;
                preTreeNode = curTreeNode;
            }

            if (curTreeNode!=null)
            {
                curTreeNode.right = null;
                tailTreeNode = curTreeNode;
            }
            else
            {
                tailTreeNode = headTreeNode;
            }

            return headTreeNode;
        }

        public void InOrderTraversalWithRecursive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrderTraversalWithRecursive(root.left);
            treeQueue.Enqueue(root);
            InOrderTraversalWithRecursive(root.right);
        }
    }
}
