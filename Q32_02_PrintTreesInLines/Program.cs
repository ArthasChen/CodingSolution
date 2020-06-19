using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q32_02_PrintTreesInLines
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

            Solution hh=new Solution();
            var result= hh.Print(node1);



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
        public List<List<int>> Print(TreeNode pRoot)
        {
            // write code here
            List<List<int>> retunList = new List<List<int>>();

            // creat two queue , a list<int> 
            List<int> addList = new List<int>();
            Queue<TreeNode> stackA = new Queue<TreeNode>();
            Queue<TreeNode> stackB = new Queue<TreeNode>();
            TreeNode cur;

            // inti
            if (pRoot == null)
            {
                return retunList;
            }

            stackA.Enqueue(pRoot);

            // enter logic
            while (stackA.Count != 0 || stackB.Count != 0)
            {
                while (stackA.Count != 0)
                {
                    cur = stackA.Dequeue();
                    addList.Add(cur.val);
                    if (cur.left!=null)
                    {
                        stackB.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        stackB.Enqueue(cur.right);
                    }
                }

                if (addList.Count!=0)
                {
                    retunList.Add(addList);
                    addList = new List<int>();
                }
                

                while (stackB.Count != 0)
                {
                    cur = stackB.Dequeue();
                    addList.Add(cur.val);
                    if (cur.left != null)
                    {
                        stackA.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        stackA.Enqueue(cur.right);
                    }
                }
                if (addList.Count != 0)
                {
                    retunList.Add(addList);
                    addList = new List<int>();
                }
            }

            return retunList;
        }
    }
}
