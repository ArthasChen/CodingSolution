using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Q36_ConvertBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creat a tree
            TreeNode node1 = new TreeNode(6);
            TreeNode node2 = new TreeNode(3);
            TreeNode node3 = new TreeNode(8);
            TreeNode node4 = new TreeNode(1);
            TreeNode node5 = new TreeNode(4);
            TreeNode node6 = new TreeNode(7);
            TreeNode node7 = new TreeNode(9);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;

            Solution2 s = new Solution2();
            var head = s.Convert(node1);

            
            Node n1=new Node(4,null,null);
            Node n2=new Node(2,null,null);
            Node n3=new Node(5,null,null);
            Node n4=new Node(1,null,null);
            Node n5=new Node(3,null,null);

            n1.left = n2;
            n1.right = n3;
            n2.left = n4;
            n2.right = n5;
            Solution3 sss =new Solution3();

            var head1 = sss.TreeToDoublyList(n1);

            Console.ReadKey();
        }
    }

    #region  牛客code

    // 牛客 Definition for a Node.
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

    /// <summary>
    /// 解法一：借用一个容器，把节点按中序遍历放进去，然后遍历容器，构建双向链表。
    /// 时间复杂度：O(n)
    /// 额外空间复杂度:O(n)，因为需要借助额外的队列
    /// </summary>
    class Solution1
    {
        private Queue<TreeNode> treeQueue = new Queue<TreeNode>();

        public TreeNode Convert(TreeNode pRootOfTree)
        {
            if (pRootOfTree == null)
            {
                return null;
            }

            // 按照中序遍历，把节点都放进队列
            InOrderTraversalWithRecursive(pRootOfTree);

            TreeNode preTreeNode = null;
            TreeNode curTreeNode = null;
            TreeNode headTreeNode = null;
            TreeNode tailTreeNode = null;

            // 出队，按顺序给节点赋值
            preTreeNode = treeQueue.Dequeue();
            preTreeNode.left = null;
            headTreeNode = preTreeNode;

            while (treeQueue.Count != 0)
            {
                curTreeNode = treeQueue.Dequeue();
                preTreeNode.right = curTreeNode;
                curTreeNode.left = preTreeNode;
                preTreeNode = curTreeNode;
            }

            if (curTreeNode != null)
            {
                curTreeNode.right = null;
                tailTreeNode = curTreeNode;
            }
            else
            {
                tailTreeNode = headTreeNode;
            }

            return headTreeNode;
        }

        public void InOrderTraversalWithRecursive(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrderTraversalWithRecursive(root.left);
            treeQueue.Enqueue(root);
            InOrderTraversalWithRecursive(root.right);
        }
    }

    /// <summary>
    /// 解法二：
    /// 时间复杂度：O(n)
    /// 额外空间复杂度:O(1)
    /// </summary>
    class Solution2
    {
        public TreeNode Convert(TreeNode pRootOfTree)
        {
            if (pRootOfTree == null)
            {
                return null;
            }

            return BinaryConverToList(pRootOfTree).headNode;
        }

        public ReturnType BinaryConverToList(TreeNode root)
        {
            if (root == null)
            {
                //return null;
                return new ReturnType(null, null);
            }

            ReturnType leftReturn = BinaryConverToList(root.left);
            ReturnType rightReturn = BinaryConverToList(root.right);

            if (leftReturn.tailNode != null)
            {
                root.left = leftReturn.tailNode;

                leftReturn.tailNode.right = root;
            }
            else
            {
                leftReturn.headNode = root;
            }

            if (rightReturn.headNode != null)
            {
                root.right = rightReturn.headNode;


                rightReturn.headNode.left = root;
            }
            else
            {
                rightReturn.tailNode = root;
            }

            return new ReturnType(leftReturn.headNode, rightReturn.tailNode);
        }
    }

    public class ReturnType
    {
        public TreeNode headNode;
        public TreeNode tailNode;

        public ReturnType(TreeNode start, TreeNode end)
        {
            headNode = start;
            tailNode = end;
        }
    }

    #endregion

    #region Leetcode
    // LeetCode Definition for a Node.
    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node() { }
        public Node(int _val, Node _left, Node _right)
        {
            val = _val;
            left = _left;
            right = _right;
        }
    }

    /// <summary>
    /// 解法二，对应Leetcode上的答案
    /// 
    /// </summary>
    public class Solution3
    {
        public Node TreeToDoublyList(Node root)
        {
            if (root == null)
            {
                return null;
            }

            ReturnTy re = BinaryConverToList(root);
            Node head = re.headNode;
            Node tail = re.tailNode;
            head.left = tail;
            tail.right = head;
            return head;
        }

        public ReturnTy BinaryConverToList(Node root)
        {
            if (root == null)
            {
                //return null;
                return new ReturnTy(null, null);
            }

            ReturnTy leftReturn = BinaryConverToList(root.left);
            ReturnTy rightReturn = BinaryConverToList(root.right);

            if (leftReturn.tailNode != null)
            {
                root.left = leftReturn.tailNode;

                leftReturn.tailNode.right = root;
            }
            else
            {
                leftReturn.headNode = root;
            }

            if (rightReturn.headNode != null)
            {
                root.right = rightReturn.headNode;


                rightReturn.headNode.left = root;
            }
            else
            {
                rightReturn.tailNode = root;
            }

            return new ReturnTy(leftReturn.headNode, rightReturn.tailNode);
        }
    }


    public class Solution
    {
        public Node TreeToDoublyList(Node root)
        {
            if (root == null)
            {
                return null;
            }

            return BinaryConverToList(root).headNode;
        }

        public ReturnTy BinaryConverToList(Node root)
        {
            if (root == null)
            {
                //return null;
                return new ReturnTy(null, null);
            }

            ReturnTy leftReturn = BinaryConverToList(root.left);
            ReturnTy rightReturn = BinaryConverToList(root.right);

            if (leftReturn.tailNode != null)
            {
                root.left = leftReturn.tailNode;

                leftReturn.tailNode.right = root;
            }
            else
            {
                leftReturn.headNode = root;
            }

            if (rightReturn.headNode != null)
            {
                root.right = rightReturn.headNode;


                rightReturn.headNode.left = root;
            }
            else
            {
                rightReturn.tailNode = root;
            }

            return new ReturnTy(leftReturn.headNode, rightReturn.tailNode);
        }
    }

    public class ReturnTy
    {
        public Node headNode;
        public Node tailNode;

        public ReturnTy(Node start, Node end)
        {
            headNode = start;
            tailNode = end;
        }
    }

    #endregion
}
