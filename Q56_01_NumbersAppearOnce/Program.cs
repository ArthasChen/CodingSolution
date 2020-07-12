using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q56_01_NumbersAppearOnce
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = {1, 2, 1,3};
            Solution s=new Solution();
            var a = s.SingleNumbers(input);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public int[] SingleNumbers(int[] nums)
        {
            int[] resultArray = new int[0];

            if (nums == null || nums.Length == 0)
            {
                return resultArray;
            }

            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum ^= nums[i];
            }

            // 找到数的二进制中倒数第N位是1的位数
            int n = FindRightToLeftFirstBitOf1(sum);

            int sumA = 0;
            int sumB = 0;

            // 再次遍历，sumA是第n位是1的数异或运算的结果；sumB是第n位是0的数异或运算的结果。
            for (int i = 0; i < nums.Length; i++)
            {
                if (IsBit1(nums[i], n))
                {
                    sumA ^= nums[i];
                }
                else
                {
                    sumB ^= nums[i];
                }
            }

            resultArray = new int[2] { sumA, sumB };

            return resultArray;
        }

        private int FindRightToLeftFirstBitOf1(int sum)
        {
            int n = 1;

            while ((sum & 1) != 1 )
            {
                sum >>= 1;
                n++;
            }

            return n;
        }

        private bool IsBit1(int num, int n)
        {
            num = num >> (n-1);
            if ((num & 1) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
