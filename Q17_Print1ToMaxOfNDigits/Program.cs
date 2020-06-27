using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Q17_Print1ToMaxOfNDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var re = s.PrintNumbers(3);

            //StringBuilder sb = new StringBuilder();
            //JZOffer jz = new JZOffer();
            //jz.Print1ToMaxOfNDigits(34);

            JZOffer2 jz2 = new JZOffer2();
            jz2.Print1ToMaxOfNDigits(2);

            Console.ReadKey();


        }
    }

    /// <summary>
    /// 这是leetcode中的题目，因为返回的是int[]类型，因此无需考虑大数问题。
    /// </summary>
    public class Solution
    {
        public int[] PrintNumbers(int n)
        {
            long max = 1;
            for (int i = 0; i < n; i++)
            {
                max *= 10;
            }

            max -= 1;

            int[] resultArray = new int[max];
            for (int i = 0; i < max; i++)
            {
                resultArray[i] = i + 1;
            }

            return resultArray;
        }
    }

    /// <summary>
    /// 剑指Offer原题,利用string模拟加法
    /// </summary>
    public class JZOffer
    {
        public void Print1ToMaxOfNDigits(int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append('0');
            }

            while (!Increment(sb))
            {
                // print without pre 0
                int maxIndexOf0 = -1;
                //bool isPre0 = true;
                for (int i = 0; i < sb.Length; i++)
                {
                    if (sb[i] == '0')
                    {
                        maxIndexOf0 = i;
                    }
                    else
                    {
                        break;
                    }
                }

                // print 
                Console.WriteLine(sb.ToString().Substring(maxIndexOf0 + 1));
            }
        }

        private bool Increment(StringBuilder sb)
        {
            bool isOverFlow = false;

            // 模拟加法，如果最高位进位了。则溢出
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                char value = (char)(sb[i] + 1);
                if (value > '9')
                {
                    // 本次位置变为0，进入下一个位置+1.
                    sb[i] = '0';
                    if (i == 0)
                    {
                        isOverFlow = true;
                    }
                }
                else
                {
                    sb[i] = value;
                    break;
                }
            }



            return isOverFlow;
        }
    }

    /// <summary>
    /// 剑指Offer原题,利用递归解题
    /// </summary>
    public class JZOffer2
    {
        public void Print1ToMaxOfNDigits(int n)
        {
            // init StringBuilder
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append('0');
            }

            int index = 0;

            Recursive(sb, 0);
        }

        public void Recursive(StringBuilder sb, int index)
        {
            if (index >= sb.Length)
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                char s = Convert.ToChar(i);
                sb[index] = char.Parse(i.ToString());

                Recursive(sb, index + 1);
                PrintWithout0(sb);
            }
        }

        private void PrintWithout0(StringBuilder sb)
        {
            int maxIndexOf0 = -1;
            //bool isPre0 = true;
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == '0')
                {
                    maxIndexOf0 = i;
                }
                else
                {
                    break;
                }
            }

            // print 
            Console.WriteLine(sb.ToString().Substring(maxIndexOf0 + 1));
        }
    }
}
