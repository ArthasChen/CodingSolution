using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q32_03_PrintTreesInZigzag
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
            TreeNode node7 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;

            Solution hh = new Solution();
            var result = hh.Print(node1);



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
            // 先按分层打印来存储，然后 在遍历过程中，定义一个变量来表示这一行是正写入还是反着写入

            List<List<int>> resultList = new List<List<int>>();
            if (pRoot == null)
            {
                return resultList;
            }
            
            int currentLevelLeftCount = 1;
            int NextLevelCount = 0;
            int printLeftOrRight = 1;//1 left to right; -1 right to left
            Queue<TreeNode> quede = new Queue<TreeNode>();
            List<int> levelList = new List<int>();
            Stack<int> stack = new Stack<int>();

            quede.Enqueue(pRoot);

            while (quede.Count != 0)
            {
                TreeNode cur = quede.Dequeue();

                if (printLeftOrRight == 1)
                {
                    levelList.Add(cur.val);
                    currentLevelLeftCount--;
                }
                else if (printLeftOrRight == -1)
                {
                    stack.Push(cur.val);
                    currentLevelLeftCount--;
                }

                
                if (cur.left != null)
                {
                    quede.Enqueue(cur.left);
                    NextLevelCount++;
                }

                if (cur.right != null)
                {
                    quede.Enqueue(cur.right);
                    NextLevelCount++;
                }

                if (currentLevelLeftCount == 0)
                {
                    if (printLeftOrRight == -1)
                    {
                        while (stack.Count != 0)
                        {
                            levelList.Add(stack.Pop());
                        }
                    }
                    resultList.Add(levelList);
                    levelList = new List<int>();
                    currentLevelLeftCount = NextLevelCount;
                    NextLevelCount = 0;
                    printLeftOrRight *= -1;
                }
            }

            return resultList;
        }

        /// <summary>
        /// 层序分行打印
        /// </summary>
        /// <param name="pRoot"></param>
        /// <returns></returns>
        //public List<List<int>> Print(TreeNode pRoot)
        //{
        //    // write code here
        //    // 先按分层打印来存储，然后 在遍历过程中，定义一个变量来表示这一行是正写入还是反着写入

        //    List<List<int>> resultList = null;
        //    if (pRoot == null)
        //    {
        //        return resultList;
        //    }

        //    resultList =new List<List<int>>();
        //    int currentLevelLeftCount = 1;
        //    int NextLevelCount = 0;
        //    int printLeftOrRight = 1;//1 left to right; -1 right to left
        //    Queue<TreeNode> quede = new Queue<TreeNode>();
        //    List<int> levelList = new List<int>();

        //    quede.Enqueue(pRoot);

        //    while (quede.Count != 0)
        //    {
        //        TreeNode cur = quede.Dequeue();
        //        levelList.Add(cur.val);
        //        currentLevelLeftCount--;

        //        if (cur.left != null)
        //        {
        //            quede.Enqueue(cur.left);
        //            NextLevelCount++;
        //        }

        //        if (cur.right != null)
        //        {
        //            quede.Enqueue(cur.right);
        //            NextLevelCount++;
        //        }

        //        if (currentLevelLeftCount == 0)
        //        {
        //            //levelList.Add(cur.val);
        //            resultList.Add(levelList);
        //            levelList = new List<int>();
        //            currentLevelLeftCount = NextLevelCount;
        //            NextLevelCount = 0;
        //        }
        //    }

        //    return resultList;
        //}
    }
}
