using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q09_QueueWithTwoStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            CQueue q=new CQueue();
            q.AppendTail(3);
            var a = q.DeleteHead();
            a = q.DeleteHead();

            Console.ReadKey();
        }
    }

    public class CQueue
    {
        private Stack<int> stackA;
        private Stack<int> stackB;

        public CQueue()
        {
            stackA = new Stack<int>();
            stackB = new Stack<int>();
        }

        public void AppendTail(int value)
        {
            while (stackB.Count != 0)
            {
                stackA.Push(stackB.Pop());
            }

            stackA.Push(value);
        }

        public int DeleteHead()
        {
            while (stackA.Count != 0)
            {
                stackB.Push(stackA.Pop());
            }

            if (stackB.Count == 0)
            {
                return -1;
            }
            else
            {
                return stackB.Pop();
            }

        }
    }

    /*
     * Your CQueue object will be instantiated and called as such:
     * CQueue obj = new CQueue();
     * obj.AppendTail(value);
     * int param_2 = obj.DeleteHead();
     */
}
