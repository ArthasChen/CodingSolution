using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q27_MirrorOfBinaryTree
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
            s1.BeforeTraversal(node1);

            s1.Mirror(node1);
            s1.BeforeTraversal(node1);

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
        public TreeNode Mirror(TreeNode root)
        {
            // write code here
            TreeNode MirrorTree = root;
            Mi(MirrorTree);
            return MirrorTree;
        }

        public void Mi(TreeNode tree)
        {
            if (tree==null)
            {
                return;
            }

            TreeNode tem = tree.left;
            tree.left = tree.right;
            tree.right = tem;

            Mi(tree.left);
            Mi(tree.right);
        }

        public void BeforeTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.val.ToString() + "  ");
            BeforeTraversal(root.left);
            BeforeTraversal(root.right);

        }
    }
}
