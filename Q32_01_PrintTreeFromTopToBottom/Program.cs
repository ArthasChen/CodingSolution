using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q32_01_PrintTreeFromTopToBottom
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

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            //node3.left = node6;
            //node3.right = node7;

            Solution s = new Solution();
            var head = s.PrintFromTopToBottom(node1);

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
        public List<int> PrintFromTopToBottom(TreeNode root)
        {
            // write code here
            List<int> resultList = new List<int>();

            if (root == null)
            {
                return resultList;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                TreeNode cur = queue.Dequeue();
                resultList.Add(cur.val);

                if (cur.left != null)
                {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null)
                {
                    queue.Enqueue(cur.right);
                }
            }

            return resultList;
        }
    }
}
