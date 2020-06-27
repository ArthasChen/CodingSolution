using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Q55_01_TreeDepth
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

    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            // write code here
            if (root == null)
            {
                return 0;
            }

            int leftDepth = 0;
            int rightDepth = 0;

            // 这个判断减少进入空子树的次数，减少时间
            if (root.left == null)
            {
                leftDepth = 0;
            }
            else
            {
                leftDepth = MaxDepth(root.left);
            }

            // 这个判断减少进入空子树的次数，减少时间
            if (root.right == null)
            {
                rightDepth = 0;
            }
            else
            {
                rightDepth = MaxDepth(root.right);
            }

            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;
        }
    }

    class SolutionNK
    {
        // 一棵二叉树的深度是左子树和右子树中深度最大的+1，利用这个定义，用递归解决。
        public int TreeDepth(TreeNode pRoot)
        {
            // write code here
            if (pRoot == null)
            {
                return 0;
            }

            int leftDepth = 0;
            int rightDepth = 0;

            // 这个判断减少进入空子树的次数，减少时间
            if (pRoot.left == null)
            {
                leftDepth = 0;
            }
            else
            {
                leftDepth = TreeDepth(pRoot.left);
            }

            // 这个判断减少进入空子树的次数，减少时间
            if (pRoot.right == null)
            {
                rightDepth = 0;
            }
            else
            {
                rightDepth = TreeDepth(pRoot.right);
            }

            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;
        }
    }
}
