using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q55_02_BalancedBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
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

        public class ReturnType
        {
            public int treeDepth;
            public bool isBalance;

            public ReturnType(bool isBalance, int treeDepth)
            {
                this.isBalance = isBalance;
                this.treeDepth = treeDepth;
            }
        }

        class Solution
        {
            public bool IsBalanced_Solution(TreeNode pRoot)
            {
                // write code here
                return IsBalanced(pRoot).isBalance;
            }

            public static ReturnType IsBalanced(TreeNode pRoot)
            {
                // write code here
                if (pRoot == null)
                {
                    return new ReturnType(true, 0);
                }



                ReturnType leftReturnType = IsBalanced(pRoot.left);
                ReturnType rightReturnType = IsBalanced(pRoot.right);

                if (leftReturnType.isBalance && rightReturnType.isBalance)
                {
                    if (Math.Abs(leftReturnType.treeDepth - rightReturnType.treeDepth) <= 1)
                    {
                        int returnDepth = Math.Max(leftReturnType.treeDepth, rightReturnType.treeDepth) + 1;
                        return new ReturnType(true, returnDepth);
                    }
                }
                int returnDepth1 = Math.Max(leftReturnType.treeDepth, rightReturnType.treeDepth) + 1;

                return new ReturnType(false,returnDepth1);
            }
        }
    }
}
