using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q59_02_QueueWithMax
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxQueue2 m = new MaxQueue2();
            m.Push_back(1);
            m.Push_back(2);
            var a = m.Max_value();
            m.Pop_front();
            a = m.Max_value();

            Console.WriteLine();

            Console.ReadKey();
        }
    }

    public class MaxQueue
    {
        Queue<int> queue;
        List<int> maxQueueHelper;
        Stack<int> preStack;
        Stack<int> postStack;

        public MaxQueue()
        {
            queue = new Queue<int>();
            maxQueueHelper = new List<int>();
            preStack = new Stack<int>();
            postStack = new Stack<int>();
        }

        public int Max_value()
        {
            if (maxQueueHelper.Count == 0)
            {
                return -1;
            }

            return maxQueueHelper.First();
        }

        public void Push_back(int value)
        {
            if (queue.Count != 0)
            {
                // 从数组头开始遍历，遇到小于value的，都换成，value
                while (maxQueueHelper.Count != 0 && maxQueueHelper.First() < value)
                {
                    maxQueueHelper.RemoveAt(maxQueueHelper.IndexOf(maxQueueHelper.First()));
                    preStack.Push(value);
                }

                while (preStack.Count != 0)
                {
                    maxQueueHelper.Insert(0, preStack.Pop());
                }

                // 从数组尾部开始遍历，遇到小于value 都换成value
                while (maxQueueHelper.Count != 0 && maxQueueHelper.Last() < value)
                {
                    maxQueueHelper.RemoveAt(maxQueueHelper.LastIndexOf(maxQueueHelper.Last()));
                    postStack.Push(value);
                }

                while (postStack.Count != 0)
                {
                    maxQueueHelper.Add(postStack.Pop());
                }
            }

            queue.Enqueue(value);
            maxQueueHelper.Add(value);

        }

        public int Pop_front()
        {
            if (queue.Count == 0)
            {
                return -1;
            }

            // 删除辅助数组的第一个值
            maxQueueHelper.RemoveAt(maxQueueHelper.IndexOf(maxQueueHelper.First()));
            return queue.Dequeue();
        }
    }

    /**
     * Your MaxQueue object will be instantiated and called as such:
     * MaxQueue obj = new MaxQueue();
     * int param_1 = obj.Max_value();
     * obj.Push_back(value);
     * int param_3 = obj.Pop_front();
     */


    /// <summary>
    /// 满足题意的解法
    /// </summary>
    public class MaxQueue2
    {
        Queue<int> queue;
        List<int> maxQueueHelper;

        public MaxQueue2()
        {
            queue = new Queue<int>();
            maxQueueHelper = new List<int>();
        }

        public int Max_value()
        {
            if (maxQueueHelper.Count == 0)
            {
                return -1;
            }

            return maxQueueHelper.First();
        }

        public void Push_back(int value)
        {
            while (maxQueueHelper.Count != 0 && maxQueueHelper.Last() < value)
            {
                maxQueueHelper.RemoveAt(maxQueueHelper.LastIndexOf(maxQueueHelper.Last()));
            }

            maxQueueHelper.Add(value);
            queue.Enqueue(value);
        }

        public int Pop_front()
        {
            if (queue.Count == 0)
            {
                return -1;
            }

            if (queue.Peek() == maxQueueHelper.First())
            {
                maxQueueHelper.RemoveAt(0);
            }

            return queue.Dequeue();
        }
    }

}
