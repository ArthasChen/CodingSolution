using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q58_01_ReverseWordsInSentence
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 解法一：用C#自带的库拆分字符串。然后从尾往头遍历拆分后的字符串；或者顺序遍历，利用栈来解答题目。
    /// </summary>
    public class Solution
    {
        public string ReverseWords(string s)
        {
            if (s == null)
            {
                return null;
            }

            if (s == string.Empty)
            {
                return string.Empty;
            }

            string[] strArray = s.Split(' ');
            StringBuilder sb = new StringBuilder();

            for (int i = strArray.Length - 1; i >= 0; i--)
            {
                if (strArray[i] != string.Empty)
                {
                    sb.Append(strArray[i] + " ");
                }
            }

            if (sb.ToString() == "")
            {
                return string.Empty;
            }

            sb.Remove(sb.Length - 1, 1);

            string res = sb.ToString();


            return res;
        }
    }

    /// <summary>
    /// 解法二：反转两次字符串，第一次字符串整体反转，第二次只反转独立的单词，结果是单词的位置都反转了，但是每个单词本身字符的顺序不变。然后进行去除空格操作。
    /// </summary>
    public class Solution2
    {
        public string ReverseWords2(string s)
        {
            if (s == null)
            {
                return null;
            }

            if (s == string.Empty)
            {
                return string.Empty;
            }

            char[] charArray = s.ToCharArray();
            int beginIndex = 0;
            int endIndex = s.Length - 1;

            // 第一次反转，全部反转
            Reverse(charArray, beginIndex, endIndex);

            // 按顺序反转每个单词， 遍历的同时处理中间的空格问题
            beginIndex = 0;
            endIndex = 0;
            StringBuilder sb = new StringBuilder();

            while (beginIndex < charArray.Length)
            {
                if (charArray[beginIndex] == ' ')
                {
                    beginIndex++;
                    endIndex++;
                }
                else if (endIndex >= charArray.Length || charArray[endIndex] == ' ')
                {
                    endIndex--;
                    sb.Append(ReverseReturnSB(charArray, beginIndex, endIndex) + " ");
                    beginIndex = ++endIndex;
                }
                else
                {
                    endIndex++;
                }
            }

            string res = sb.ToString();

            return res.Trim();
        }

        public void Reverse(char[] charArray, int beginIndex, int endIndex)
        {
            if (charArray == null || charArray.Length <= 0)
            {
                return;
            }

            while (beginIndex < endIndex)
            {
                char temChar = charArray[beginIndex];
                charArray[beginIndex] = charArray[endIndex];
                charArray[endIndex] = temChar;

                beginIndex++;
                endIndex--;
            }
        }

        public StringBuilder ReverseReturnSB(char[] charArray, int beginIndex, int endIndex)
        {
            if (charArray == null || charArray.Length <= 0)
            {
                return null;
            }

            int head = beginIndex;
            int tail = endIndex;

            while (beginIndex < endIndex)
            {
                char temChar = charArray[beginIndex];
                charArray[beginIndex] = charArray[endIndex];
                charArray[endIndex] = temChar;

                beginIndex++;
                endIndex--;
            }

            StringBuilder sb = new StringBuilder();
            while (head <= tail)
            {
                sb.Append(charArray[head++]);
            }

            return sb;
        }
    }
}
