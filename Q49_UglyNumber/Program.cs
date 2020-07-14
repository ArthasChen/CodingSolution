using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q49_UglyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int ssss = s.NthUglyNumber(10);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int NthUglyNumber(int n)
        {
            int resultNum = 0;
            int nextIndex = 0;
            int[] uglyArray = new int[n];
            uglyArray[0] = 1;
            nextIndex++;

            int p2index = 0;
            int p3index = 0;
            int p5index = 0;

            while (nextIndex < n)
            {
                int minNum = Math.Min(Math.Min(uglyArray[p2index] * 2, uglyArray[p3index] * 3), uglyArray[p5index] * 5);

                uglyArray[nextIndex] = minNum;

                if (uglyArray[p2index] * 2 == minNum)
                {
                    p2index++;
                }

                if (uglyArray[p3index] * 3 == minNum)
                {
                    p3index++;
                }
                if (uglyArray[p5index] * 5 == minNum)
                {
                    p5index++;
                }

                nextIndex++;
            }

            resultNum = uglyArray[n - 1];
            return resultNum;
        }
    }
}
