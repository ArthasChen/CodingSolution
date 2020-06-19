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
            if (root == null)
            {
                return null;
            }

            List<List<int>> returnList = new List<List<int>>();
            List<int> twoSideQueue = new List<int>();

            FindPath(root, expectNumber, 0, returnList, twoSideQueue);

            return returnList;
        }

        public void FindPath(TreeNode root, int targetNumber, int currentNumber, List<List<int>> list, List<int> twoSideQueue)
        {
            if (root == null)
            {
                return;
            }

            currentNumber += root.val;
            twoSideQueue.add(root.val);


            if (root.left == null && root.right == null && currentNumber == targetNumber)
            {
                // 满足条件，构建路径List 
                List<int> temList = new List<int>();
                //while (twoSideQueue.Count != 0)
                //{
                //    temList.Add(twoSideQueue.Dequeue());
                //}


                // 将本次符合条件的Path 的List写入返回类型的变量中
                list.Add(temList);
            }

            if (root.left!=null)
            {
                FindPath(root.left, targetNumber, currentNumber, list, queue);
            }

            if (root.right != null)
            {
                FindPath(root.right, targetNumber, currentNumber, list, queue);
            }


        }
    }
}
