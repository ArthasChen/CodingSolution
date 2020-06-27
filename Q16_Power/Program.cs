using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q16_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            //2.00000
            //    - 2147483648
            Solution2 s = new Solution2();
            var r = s.MyPow(2.00000, -2147483648);
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 时间复杂度O(n)
    /// </summary>
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            if (Equals(x, 0d))
            {
                if (n < 0)
                {
                    throw new Exception("分母不能为0");
                }
                else
                {
                    return 0;
                }
            }

            double res = 1d;

            if (n < 0)
            {
                for (int i = 0; i < (-n); i++)
                {
                    res *= x;
                }

                res = 1d / res;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    res *= x;
                }
            }

            return res;
        }
    }

    /// <summary>
    /// 时间复杂度O(Logn)
    /// </summary>
    public class Solution2
    {
        public double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n == 1)
            {
                return x;
            }

            int nextN = 0;

            if (n < 0)
            {
                // 这么处理的原因是如果n是int的最小值-2147483648，如果直接改符号，2147483648就超过了int的最大值2147483647，因此这里先/2，再改符号
                nextN = (n / 2) * (-1);
            }
            else
            {
                nextN = n / 2;
            }

            double result = MyPow(x, nextN);
            result *= result;
            if (n % 2 == 1 || n % 2 == -1)
            {
                result *= x;
            }

            if (n < 0)
            {
                result = 1d / result;
            }

            return result;
        }
    }
}
