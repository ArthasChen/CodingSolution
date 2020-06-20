using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q54_KthNodeInBST
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creat a tree
            TreeNode node1 = new TreeNode(4);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(6);
            TreeNode node4 = new TreeNode(1);
            TreeNode node5 = new TreeNode(3);
            TreeNode node6 = new TreeNode(5);
            TreeNode node7 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;

            Solution s = new Solution();
            TreeNode t= s.KthNode(node1, 4);

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
        Dictionary<int, TreeNode> map = new Dictionary<int, TreeNode>();


        public TreeNode KthNode(TreeNode pRoot, int k)
        {
            if (pRoot == null)
            {
                return null;
            }

            InOrderTraversalWithRecursive(pRoot);

            if (k > map.Count)
            {
                return null;
            }

            int i = 0;

            foreach (var child in map)
            {
                if (i++==(k-1))
                {
                    return child.Value;
                }
            }

            return null;
        }

        public void InOrderTraversalWithRecursive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrderTraversalWithRecursive(root.left);
            map.Add(root.val, root);
            InOrderTraversalWithRecursive(root.right);
        }
    }
}
