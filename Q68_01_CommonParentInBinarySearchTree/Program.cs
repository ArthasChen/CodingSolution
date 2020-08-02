using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q68_01_CommonParentInBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        TreeNode(int x) { val = x; }
    }


    public class Solution
    {


        public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            return PostOrderTraversalWithRecursive(root, p, q).lowestCommonAncestor;
        }


        // 后序遍历
        public Counts PostOrderTraversalWithRecursive(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                Counts re = new Counts();
                return re;
            }

            Counts leftCounts = PostOrderTraversalWithRecursive(root.left, p, q);
            Counts rightCount = PostOrderTraversalWithRecursive(root.right, p, q);

            if (leftCounts.lowestCommonAncestor != null)
            {
                return leftCounts;
            }

            if (rightCount.lowestCommonAncestor != null)
            {
                return rightCount;
            }

            if (leftCounts.counts == 1 && rightCount.counts == 1)
            {
                Counts c = new Counts();
                c.lowestCommonAncestor = root;
                return c;
            }

            Counts reC = new Counts();

            if (root == p || root == q)
            {
                reC.counts = 1;
            }

            if (leftCounts.counts == 1 || rightCount.counts == 1)
            {
                if (reC.counts == 1)
                {
                    reC.lowestCommonAncestor = root;
                    return reC;
                }
                else
                {
                    reC.counts = 1;
                    return reC;
                }
            }

            return reC;
        }
    }

    public class Counts
    {
        public int counts = 0;
        public TreeNode lowestCommonAncestor = null;
        public Counts()
        {

        }
    }
}
