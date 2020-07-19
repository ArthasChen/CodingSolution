using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q14_02_CuttingRope2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 剪绳子2：在上一题的基础上，增加n的取值范围，因此题目就涉及到到大数问题。
    /// </summary>
    public class Solution
    {
        public int CuttingRope(int n)
        {
            if (n == 2)
            {
                return 1;
            }
            if (n == 3)
            {
                return 2;
            }
            int mod = (int)1e9 + 7;
            long res = 1;
            while (n > 4)
            {
                res *= 3;
                res %= mod;
                n -= 3;
            }
            return (int)(res * n % mod);
        }

        
    }

    /// <summary>
    /// 剪绳子2：在上一题的基础上，增加n的取值范围，因此题目就涉及到到大数问题。
    /// </summary>
    public class Solution2
    {
        public int CuttingRope2(int n)
        {
            if (n == 2)
            {
                return 1;
            }

            if (n == 3)
            {
                return 2;
            }

            int mod = (int)1e9 + 7;

            int countsOf3 = n / 3;
            if (n - 3 * countsOf3 == 1)
            {
                countsOf3--;
            }

            int countsOf2 = (n - 3 * countsOf3) / 2;
            long result = 1;

            while (countsOf3 != 0)
            {
                result *= 3;
                result %= mod;
                countsOf3--;
            }

            while (countsOf2 != 0)
            {
                result *= 2;
                result %= mod;
                countsOf2--;
            }

            return (int)result;
        }
    }
}
