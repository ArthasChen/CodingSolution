using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Q31_StackPushPopOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.ValidateStackSequences(new int[] { 4, 0, 1, 2, 3 }, new int[] { 4, 2, 3, 0, 1 });

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            if (pushed == null || popped == null || pushed.Length != popped.Length)
            {
                return false;
            }

            if (pushed.Length == 0)
            {
                return true;
            }

            Stack<int> stack = new Stack<int>();
            int pushedIndex = 0;
            int popedIndex = 0;
            stack.Push(pushed[pushedIndex++]);

            while (stack.Count != 0 || popedIndex < popped.Length)
            {

                if (stack.Count == 0)
                {
                    stack.Push(pushed[pushedIndex++]);
                }

                int num = stack.Peek();
                if (popped[popedIndex] == num)
                {
                    stack.Pop();
                    popedIndex++;
                }
                else
                {
                    if (pushedIndex >= pushed.Length)
                    {
                        return false;
                    }
                    else
                    {
                        stack.Push(pushed[pushedIndex++]);
                    }
                }
            }


            return true;
        }
    }
}
