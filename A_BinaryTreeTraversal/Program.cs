using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_BinaryTreeTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creat a tree
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;

            Solution s1=new Solution();


            Console.ReadKey();
        }
    }

    /// <summary>
    /// 二叉树定义
    /// </summary>
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

    /// <summary>
    /// Binary Tree Traversal
    /// </summary>
    class Solution
    {
        public void PreOrderTraversalWithRecursive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.val.ToString()+"  ");
            PreOrderTraversalWithRecursive(root.left);
            PreOrderTraversalWithRecursive(root.right);
        }

        public void InOrderTraversalWithRecursive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrderTraversalWithRecursive(root.left);
            Console.WriteLine(root.val.ToString() + "  ");
            InOrderTraversalWithRecursive(root.right);
        }

        public void PostOrderTraversalWithRecursive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            PostOrderTraversalWithRecursive(root.left);
            PostOrderTraversalWithRecursive(root.right);
            Console.WriteLine(root.val.ToString() + "  ");
        }


    }
}
