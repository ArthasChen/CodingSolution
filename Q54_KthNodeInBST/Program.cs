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
            TreeNode node1 = new TreeNode(3);
            TreeNode node2 = new TreeNode(1);
            TreeNode node3 = new TreeNode(4);
            TreeNode node5 = new TreeNode(2);
            TreeNode node6 = new TreeNode(5);
            TreeNode node7 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node2.right = node5;

            //SolutionNK s = new SolutionNK();
            //TreeNode t = s.KthNode(node1, 4);


            Solution a = new Solution();
            var bb = a.KthLargest(node1, 1);
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

    /// <summary>
    /// Leetcode是求最大的第K个节点
    /// </summary>

    public class Solution
    {
        Dictionary<int, TreeNode> map = new Dictionary<int, TreeNode>();

        public int KthLargest(TreeNode root, int k)
        {
            if (root == null)
            {
                return -1;
            }

            InOrderTraversalWithRecursive(root);

            if (k > map.Count)
            {
                return -1;
            }


            int times = 0;
            for (int j = map.Count - 1; j >= 0; j--)
            {
                if (times++ == (k - 1))
                {
                    return map.ElementAt(j).Value.val;
                }
            }



            return -1;
        }

        public void InOrderTraversalWithRecursive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrderTraversalWithRecursive(root.left);
            if (!map.ContainsKey(root.val))
            {
                map.Add(root.val, root);

            }
            InOrderTraversalWithRecursive(root.right);
        }
    }

    /// <summary>
    /// 牛客的题目是求最小的第K个
    /// </summary>
    class SolutionNK
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
                if (i++ == (k - 1))
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
