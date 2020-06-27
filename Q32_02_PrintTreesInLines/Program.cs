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
            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node3.left = node6;
            node3.right = node7;


            SolutionNK hh =new SolutionNK();
            var result= hh.Print(node1);

            Solution hh1 = new Solution();
            var resulst = hh1.LevelOrder(node1);

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

    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            // write code here
            List<IList<int>> retunList = new List<IList<int>>();


            // creat two queue , a list<int> 
            List<int> addList = new List<int>();
            Queue<TreeNode> stackA = new Queue<TreeNode>();
            Queue<TreeNode> stackB = new Queue<TreeNode>();
            TreeNode cur;

            // inti
            if (root == null)
            {
                return retunList;
            }

            stackA.Enqueue(root);

            // enter logic
            while (stackA.Count != 0 || stackB.Count != 0)
            {
                while (stackA.Count != 0)
                {
                    cur = stackA.Dequeue();
                    addList.Add(cur.val);
                    if (cur.left != null)
                    {
                        stackB.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        stackB.Enqueue(cur.right);
                    }
                }

                if (addList.Count != 0)
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

            return (IList<IList<int>>)retunList;
        }
    }

    class SolutionNK
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
