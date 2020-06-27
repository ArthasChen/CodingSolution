using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q26_SubstructureInTree
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
        public bool IsSubStructure(TreeNode A, TreeNode B)
        {
            SolutionNK snk = new SolutionNK();

            return snk.HasSubtree(A, B);
        }
    }

    class SolutionNK
    {
        public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2)
        {
            if (pRoot1 == null || pRoot2 == null)
            {
                return false;
            }

            bool result = false;

            if (pRoot1.val == pRoot2.val)
            {
                result = DoesAHaveB(pRoot1, pRoot2);
            }

            if (!result)
            {
                result = HasSubtree(pRoot1.left, pRoot2);
            }

            if (!result)
            {
                result = HasSubtree(pRoot1.right, pRoot2);
            }

            return result;
        }

        public bool DoesAHaveB(TreeNode rootA, TreeNode rootB)
        {
            if (rootB == null)
            {
                return true;
            }

            if (rootA == null)
            {
                return false;
            }

            bool result = false;

            if (rootA.val == rootB.val)
            {
                result = DoesAHaveB(rootA.left, rootB.left) && DoesAHaveB(rootA.right, rootB.right);
            }

            return result;
        }
    }
}
