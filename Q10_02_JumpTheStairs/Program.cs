using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Q10_02_JumpTheStairs
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int NumWays(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            int mold = 1000000007;
            int sum1 = 1 % mold;
            int sum2 = 1 % mold; ;
            int sum = 0 % mold; ;

            for (int i = 1; i < n; i++)
            {
                sum = (sum1 + sum2) % mold;
                sum2 = sum1 % mold;
                sum1 = sum;
            }

            return sum;
        }
    }
}
