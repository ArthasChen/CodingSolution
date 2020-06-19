using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q34_PathInTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> list =new List<int>();
            //list.Add(0);
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);
            //list.Add(5);

            //var head = list.First();
            //var tail = list.Last();

            //list.Remove(list.First());
            //var newFirst = list.First();
            //list.Remove(list.Last());
            //var newTail = list.Last();

            //var s = list;

            // Creat a tree
            TreeNode node1 = new TreeNode(2);
            TreeNode node2 = new TreeNode(4);
            TreeNode node3 = new TreeNode(1);
            TreeNode node4 = new TreeNode(2);
            TreeNode node5 = new TreeNode(1);
            TreeNode node6 = new TreeNode(5);
            TreeNode node7 = new TreeNode(6);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;

            Solution s = new Solution();
            var result = s.FindPath(node1, 8);

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
        public List<List<int>> FindPath(TreeNode root, int expectNumber)
        {
            List<List<int>> returnList = new List<List<int>>();
            List<int> twoSideQueue = new List<int>();

            FindPath(root, expectNumber, 0, returnList, twoSideQueue);

            return returnList;
        }

        public void FindPath(TreeNode root, int targetNumber, int currentNumber, List<List<int>> list, List<int> twoSideQueue)
        {
            if (root == null)
            {
                return ;
            }

            currentNumber += root.val;
            // add elemtn to tail
            twoSideQueue.Add(root.val);


            if (root.left == null && root.right == null && currentNumber == targetNumber)
            {
                // 满足条件，构建路径List 
                List<int> temList = new List<int>();
                foreach (var child in twoSideQueue)
                {
                    temList.Add(child);
                }

                // 将本次符合条件的Path 的List写入返回类型的变量中
                list.Add(temList);
            }

            if (root.left != null)
            {
                FindPath(root.left, targetNumber, currentNumber, list, twoSideQueue);
            }

            if (root.right != null)
            {
                FindPath(root.right, targetNumber, currentNumber, list, twoSideQueue);
            }

            // 删除队列尾部的值
            twoSideQueue.RemoveAt(twoSideQueue.Count - 1);
        }
    }
}
