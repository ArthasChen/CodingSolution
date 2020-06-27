using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q15_NumberOf1InBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var aa = s.HammingWeight(11);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 这个解法是按照int的位一位一位的比较，最大要比较32次。
    /// </summary>
    public class Solution
    {
        public int HammingWeight(uint n)
        {
            int countOf1 = 0;
            uint flag = 1;
            while (flag != 0)
            {
                if ((n & flag) == flag)
                {
                    countOf1++;
                }
                flag <<= 1;
            }

            return countOf1;
        }
    }

    /// <summary>
    /// 有几个1就循环几次的解法
    /// </summary>
    public class Solution2
    {
        public int HammingWeight(uint n)
        {
            int countOf1 = 0;
            while (n != 0)
            {
                countOf1++;
                n = (n - 1) & n;
            }

            return countOf1;
        }
    }
}
