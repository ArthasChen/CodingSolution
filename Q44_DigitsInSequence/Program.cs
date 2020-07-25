using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Q44_DigitsInSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var bb = s.getNums(11);
            var a = s.FindNthDigit(1000000000);
            var qq= (long)Math.Pow(10, 11);
            Console.ReadKey();
        }
    }

    public class Solution2
    {
        public int FindNthDigit(int n)
        {
            long length = 1;
            long count = 10;
            long tenBase = 9;
            long lastCount = 0;
            // 求出n所命中的数字的总位数
            while (count < n)
            {
                length++;
                tenBase *= 10;
                var currentCount = tenBase * length;
                lastCount = count;
                count += currentCount;
            }

            // n代表的字符在该位所有数字字符串中的索引
            var remainder = n - lastCount;
            // 计算n所命中的数字
            var value = remainder / length;
            if (length > 1)
            {
                value += (int)Math.Pow(10, length - 1);
            }
            // 计算目标字符在数字的第几位
            remainder %= length;
            return value.ToString()[(int)remainder] - '0';
        }
    }





    public class Solution
    {
        public int FindNthDigit(int n)
        {
            if (n < 0)
            {
                return -1;
            }

            long targetbit = n;
            int baseNumber = 10;// 10进制基数
            long nums = 10;// 当前位数的数字共有几个
            long bitNums = 1;// 表示位数 从1位开始

            while (targetbit > nums * bitNums)
            {
                targetbit -= bitNums * nums;

                bitNums++;
                nums = getNums(bitNums);

            }

            int a = (int)(targetbit / bitNums);
            int b = (int)(targetbit % bitNums);

            long lastNumber = (long)Math.Pow(10, bitNums) - nums + a;
            string tem = lastNumber.ToString();

            long resulet = long.Parse(tem[b].ToString());


            return (int)resulet;
        }

        public long getNums(long bitNums)
        {
            if (bitNums==1)
            {
                return 10;
            }

            long count = (long)(Math.Pow(10, bitNums - 1));

            return 9 * count;
        }
    }


















































}
