using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_ConstructBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pre = { 1, 2, 4, 5, 3, 6, 7 };
            int[] tin = { 4, 2, 5, 1, 6, 3, 7 };

            Solution s = new Solution();
            TreeNode tree = s.BuildTree(pre, tin);
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
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            // write code here
            TreeNode resultTreeNode = null;

            if (preorder.Length == 0 || inorder.Length == 0)
            {
                return resultTreeNode;
            }

            int rootValue = preorder[0];

            // 根据前序遍历数组中第一个值，从中序遍历数组中区分出左树和右树的中序遍历
            int leftSubTreeArrayCount = 0;
            foreach (var child in inorder)
            {
                if (child == rootValue)
                {
                    break;
                }

                leftSubTreeArrayCount++;
            }

            int rightTreeArrayCount = inorder.Length - 1 - leftSubTreeArrayCount;

            int[] leftInOrderArray = new int[leftSubTreeArrayCount];
            int[] rightInOrderArray = new int[rightTreeArrayCount];

            for (int i = 0; i < inorder.Length; i++)
            {
                if (i < leftSubTreeArrayCount)
                {
                    leftInOrderArray[i] = inorder[i];
                }
                else if (i > leftSubTreeArrayCount)
                {
                    rightInOrderArray[i - 1 - leftSubTreeArrayCount] = inorder[i];
                }
                else
                {
                    continue;
                }
            }

            // 根据前序遍历数组中第一个值，得到左树和右树的的前序遍历数组
            int[] leftPreOrderArray = new int[leftSubTreeArrayCount];
            int[] rightPreOrderArray = new int[rightTreeArrayCount];

            for (int i = 0; i < preorder.Length; i++)
            {
                if (i > 0 && i < 1 + leftSubTreeArrayCount)
                {
                    leftPreOrderArray[i - 1] = preorder[i];
                }
                else if (i >= 1 + leftSubTreeArrayCount)
                {
                    rightPreOrderArray[i - 1 - leftSubTreeArrayCount] = preorder[i];
                }
            }

            TreeNode leftSubTree = BuildTree(leftPreOrderArray, leftInOrderArray);
            TreeNode rightSubTree = BuildTree(rightPreOrderArray, rightInOrderArray);

            resultTreeNode = new TreeNode(rootValue);
            resultTreeNode.left = leftSubTree;
            resultTreeNode.right = rightSubTree;

            return resultTreeNode;
        }
    }
}
