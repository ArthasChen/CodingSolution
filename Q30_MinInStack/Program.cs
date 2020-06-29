using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Q30_MinInStack
{
    class Program
    {
        static void Main(string[] args)
        {

            MinStack s = new MinStack();
            s.Push(-2);
            s.Push(0);
            s.Push(-1);

            var a = 0;
            a = s.Min();
            a=s.Top();
            s.Pop();
            a = s.Min();


            Console.ReadKey();
        }
    }
}

public class MinStack
{
    public Stack<int> stack;
    public Stack<int> minStack;

    /** initialize your data structure here. */
    public MinStack()
    {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }

    public void Push(int x)
    {
        if (stack.Count == 0 || x < minStack.Peek())
        {
            minStack.Push(x);
        }
        else
        {
            minStack.Push(minStack.Peek());
        }

        //if (stack.Count == 0)
        //{
        //    minStack.Push(x);
        //}
        //else
        //{
        //    if (x < minStack.Peek())
        //    {
        //        minStack.Push(x);
        //    }
        //    else
        //    {
        //        minStack.Push(minStack.Peek());
        //    }
        //}

        stack.Push(x);
    }

    public void Pop()
    {
        minStack.Pop();
        stack.Pop();
    }

    public int Top()
    {
        return stack.Peek();
    }

    public int Min()
    {
        return minStack.Peek();
    }
}

/*
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.Min();
 */

