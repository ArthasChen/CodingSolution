using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q58_02_LeftRotateString
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s =new Solution();
            string input = "123456";
            var a = s.ReverseLeftWords(input,3);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public string ReverseLeftWords(string s, int n)
        {
            if (s == null || n < 0 || n > s.Length)
            {
                return null;
            }

            if (s == string.Empty)
            {
                return string.Empty;
            }

            char[] charArray = s.ToCharArray();

            // reverse all string

            ReverseCharArray(charArray, 0, s.Length - 1);

            // 分别反转两部分
            ReverseCharArray(charArray, 0, s.Length - 1 - n);

            ReverseCharArray(charArray, s.Length - n, s.Length - 1);

            StringBuilder sb = new StringBuilder();
            foreach (var item in charArray)
            {
                sb.Append(item);
            }

            return sb.ToString();
        }

        public void ReverseCharArray(char[] charArray, int beginIndex, int endIndex)
        {
            while (beginIndex < endIndex)
            {
                char tem = charArray[beginIndex];
                charArray[beginIndex] = charArray[endIndex];
                charArray[endIndex] = tem;

                beginIndex++;
                endIndex--;
            }
        }
    }
}
