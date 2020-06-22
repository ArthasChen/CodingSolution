using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q37_SerializeBinaryTrees
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

    public class ReturnType
    {
        public TreeNode treeNode;
        public string[] strArray;

        public ReturnType(TreeNode tn, string[] strArray)
        {
            this.treeNode = tn;
            this.strArray = strArray;
        }
    }

    class Solution
    {
        public string Serialize(TreeNode root)
        {
            // write code here
        }

        public TreeNode Deserialize(string str)
        {
            // write code here

            string[] inputCharArray = str.Split('!');

            ReturnType resultTreeNode = null;

            //str.
        }

        public ReturnType DeserializeRecursive(string[] strArray)
        {
            if (strArray == null)
            {
                return new ReturnType(null, null);
            }


            ReturnType rt = null;
            string rootStr = strArray[0];
            if (rootStr != "#")
            {
                string[] newStrArray = new string[strArray.Length - 1];
                strArray.CopyTo(newStrArray, 1);

                ReturnType leftRT = DeserializeRecursive(newStrArray);
                ReturnType rightRT = DeserializeRecursive(leftRT.strArray);

                TreeNode curTreeNode = new TreeNode(int.Parse(rootStr));
                curTreeNode.left = leftRT.treeNode;
                curTreeNode.right = rightRT.treeNode;
                rt = new ReturnType(curTreeNode, newStrArray);
            }
            else
            {
                rt = new ReturnType(null, null);
            }


            return rt;
        }
    }
}
