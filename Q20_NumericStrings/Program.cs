using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q20_NumericStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string inputString = "12e";

            char[] str = inputString.ToCharArray();
            bool result = s.isNumeric(str);

            Console.WriteLine(result.ToString());
            Console.ReadKey();
        }
    }

    class Solution
    {
        // index of char array
        int index = 0;

        public bool isNumeric(char[] str)
        {
            // 扫描判断整数部分，这部分是有符号整数
            bool isNum = ScanInt(str);

            // 扫描判断是否有小数点
            if (index < str.Length && str[index] == '.')
            {
                index++;

                // 扫描判断小数点后的整数部分，这部分是无符号整数
                bool isUnsignInt = ScanUnsignedInt(str);
                // 小数点前后的数字只要存在一个，小数点就有效，比如 12.=12.0  .12=0.12 12.34 这三种情况都是有效的
                isNum = isNum || isUnsignInt;
            }

            // 扫面判断指数部分 e or E ，这部分是有符号整数
            if (index < str.Length && (str[index] == 'e' || str[index] == 'E'))
            {
                index++;

                // e or E 前后的数字必须同时存在，指数才有效，比如 12e2
                bool isInt = ScanInt(str);
                isNum = isNum && isInt;
            }


            // 当index超过str长度，判断结束
            return isNum && index >= str.Length;
        }

        /// <summary>
        /// 扫描带符号的整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns> bool value,is or not int</returns>
        private bool ScanInt(char[] str)
        {
            // 判断是否带符号
            if (index < str.Length && (str[index] == '+' || str[index] == '-'))
            {
                index++;
            }

            return ScanUnsignedInt(str);
        }

        /// <summary>
        /// 扫描无符号的整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool ScanUnsignedInt(char[] str)
        {
            // 记录扫描前的index，用来和扫描结束后的index比较，若index大于startIndex，则index增加，则为有效的无符号整数，若相等，则字符数组为空，无整数
            int startIndex = index;

            // 判断char[]数组中的每一位是否是0-9的其中一个，当遇到不为0-9，这个无符号整数判断结束
            while (index < str.Length && str[index] >= '0' && str[index] <= '9')
            {
                index++;
            }

            // 返回是否为无符号整数，通过比较扫面前后的index大小
            return index > startIndex;
        }
    }
}
