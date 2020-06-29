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
            // Creat a tree
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node7 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node3.right = node7;


            string inputString = "1!2!4!#!#!#!3!#!7!#!#!";

            SolutionNK s = new SolutionNK();
            var head = s.Serialize(node1);

            Codec c = new Codec();
            c.serialize(node1);

            string aaa = "[1,2,3,4,null,null,7]";

            c.deserialize(aaa);

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

    /// <summary>
    /// 牛客的解题方法，牛客不限序列化的格式，我是按照前序遍历完成的。
    /// </summary>
    class SolutionNK
    {
        StringBuilder sb = new StringBuilder();
        public string Serialize(TreeNode root)
        {
            // write code here
            if (root == null)
            {
                return "#!";
            }

            PreOrderTraversalWithRecursive(root);


            return sb.ToString();
        }

        public void PreOrderTraversalWithRecursive(TreeNode root)
        {
            if (root == null)
            {
                sb.Append("#!");
                return;
            }

            sb.Append(root.val);
            sb.Append("!");
            //Console.WriteLine(root.val.ToString() + "  ");
            PreOrderTraversalWithRecursive(root.left);
            PreOrderTraversalWithRecursive(root.right);
        }

        public TreeNode Deserialize(string str)
        {
            // write code here

            string[] inputCharArray = str.Split(new char[1] { '!' }, StringSplitOptions.RemoveEmptyEntries);

            ReturnType resultTreeNode = null;

            //str.
            return DeserializeRecursive(inputCharArray).treeNode;
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
                int newStrArrayLength = strArray.Length - 1;

                if (newStrArrayLength > 0)
                {
                    string[] newStrArray = new string[strArray.Length - 1];
                    for (int i = 1; i < strArray.Length; i++)
                    {
                        newStrArray[i - 1] = strArray[i];
                    }
                    //strArray.CopyTo(newStrArray, 0);

                    ReturnType leftRT = DeserializeRecursive(newStrArray);
                    ReturnType rightRT = DeserializeRecursive(leftRT.strArray);

                    TreeNode curTreeNode = new TreeNode(int.Parse(rootStr));
                    curTreeNode.left = leftRT.treeNode;
                    curTreeNode.right = rightRT.treeNode;
                    rt = new ReturnType(curTreeNode, rightRT.strArray);
                }
                else
                {
                    TreeNode curTreeNode = new TreeNode(int.Parse(rootStr));
                    rt = new ReturnType(curTreeNode, null);
                }
            }
            else
            {
                int newStrArrayLength = strArray.Length - 1;

                if (newStrArrayLength > 0)
                {
                    string[] newStrArray = new string[strArray.Length - 1];
                    for (int i = 1; i < strArray.Length; i++)
                    {
                        newStrArray[i - 1] = strArray[i];
                    }
                    //strArray.CopyTo(newStrArray, 1);
                    rt = new ReturnType(null, newStrArray);
                }
                else
                {
                    rt = new ReturnType(null, null);
                }
            }


            return rt;
        }
    }

    /// <summary>
    /// Leetcode的解题方法，leetcode规定了序列化必须用层序遍历
    /// </summary>
    public class Codec
    {
        StringBuilder sb = new StringBuilder();
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            // write code here
            if (root == null)
            {
                return null;
            }

            // 层序遍历，没有就是null
            var liststr = PrintFromTopToBottom(root);

            StringBuilder sbb = new StringBuilder("[");
            foreach (var child in liststr)
            {
                sbb.Append(child);
                sbb.Append(',');
            }

            sbb.Replace(',', ']', sbb.Length - 1, 1);
            return sbb.ToString();
        }

        public List<string> PrintFromTopToBottom(TreeNode root)
        {
            // write code here
            List<string> resultList = new List<string>();

            if (root == null)
            {
                return resultList;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                TreeNode cur = queue.Dequeue();
                if (cur != null)
                {
                    resultList.Add(cur.val.ToString());
                }
                else
                {
                    resultList.Add("null");
                }

                if (cur != null)
                {
                    if (cur.left != null)
                    {
                        queue.Enqueue(cur.left);
                    }
                    else
                    {
                        queue.Enqueue(null);
                    }

                    if (cur.right != null)
                    {
                        queue.Enqueue(cur.right);
                    }
                    else
                    {
                        queue.Enqueue(null);
                    }
                }
            }

            //while (resultList.Last() == "null")
            //{
            //    resultList.RemoveAt(resultList.Count - 1);
            //}

            return resultList;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == null)
            {
                return null;
            }

            if (data.Equals("[]"))
            {
                return null;
            }

            var tem = data.TrimStart('[');
            var tem2 = tem.TrimEnd(']');
            string[] inputCharArray = tem2.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(int.Parse(inputCharArray[0]));
            queue.Enqueue(root);
            int i = 1;
            while (queue.Count != 0)
            {
                TreeNode cur = queue.Dequeue();
                if (!inputCharArray[i].Equals("null"))
                {
                    cur.left = new TreeNode(int.Parse(inputCharArray[i]));
                    queue.Enqueue(cur.left);
                }
                i++;
                if (!inputCharArray[i].Equals("null"))
                {
                    cur.right = new TreeNode(int.Parse(inputCharArray[i]));
                    queue.Enqueue(cur.right);
                }
                i++;
            }

            return root;
        }

    }
}
