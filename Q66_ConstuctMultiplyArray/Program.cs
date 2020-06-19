using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution2 s = new Solution2();
            var output = s.multiply(new int[] { 1, 2, 3 });

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(output[i]);
            }
            Console.ReadKey();
        }
    }

    class Solution
    {
        public int[] multiply(int[] A)
        {
            // write code here
            // creat return array depend on input A array
            int length = A.Length;
            int[] BArray = new int[length];
            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    BArray[i] = 1;
                    for (int j = 1; j < length; j++)
                    {
                        BArray[i] *= A[j];
                    }
                    continue;
                }
                else if (i < length - 1)
                {
                    int num = 1;
                    for (int j = 0; j < i; j++)
                    {
                        num *= A[j];
                    }
                    for (int j = i + 1; j < length; j++)
                    {
                        num *= A[j];
                    }
                    BArray[i] = num;
                    continue;
                }
                else
                {
                    BArray[i] = A[0];
                    for (int j = 1; j < length - 1; j++)
                    {
                        BArray[i] *= A[j];
                    }
                    continue;
                }
            }

            return BArray;
        }
    }

    class Solution2
    {
        public int[] multiply(int[] A)
        {
            // write code here
            // creat return array depend on input A array
            int length = A.Length;
            int[] BArray = new int[length];
            int[] BLeftArray = new int[length];

            if (length == 0)
            {
                return null;
            }

            BArray[0] = 1;

            for (int i = 1; i < length; i++)
            {
                BArray[i] = BArray[i - 1] * A[i - 1];
            }

            BLeftArray[length - 1] = 1;
            for (int i = length - 2; i >= 0; i--)
            {
                BLeftArray[i] = BLeftArray[i + 1] * A[i + 1];
            }

            for (int i = 0; i < length; i++)
            {
                BArray[i] *= BLeftArray[i];
            }

            return BArray;
        }
    }
}
