using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q19_RegularExpressionMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            SolutionNK s = new SolutionNK();
            Console.WriteLine(s.match("".ToCharArray(), ".*".ToCharArray()).ToString());
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            SolutionNK snk = new SolutionNK();

            return snk.match(s.ToCharArray(), p.ToCharArray());
        }
    }

    class SolutionNK
    {
        public bool match(char[] str, char[] pattern)
        {
            // 判断输入字符串是否符合规范
            if (str == null || pattern == null)
            {
                return false;
            }

            // 符合规范的输入就从头开始匹配
            return matchCore(str, 0, pattern, 0);
        }

        public bool matchCore(char[] str, int strIndex, char[] pattern, int patternIndex)
        {
            if (strIndex >= str.Length && patternIndex >= pattern.Length)
            {
                return true;
            }

            if (strIndex < str.Length && patternIndex >= pattern.Length)
            {
                return false;
            }


            // begin match
            // first determine second *

            if ((patternIndex + 1 < pattern.Length) && pattern[patternIndex + 1] == '*')
            {
                if (strIndex >= str.Length)
                {
                    return matchCore(str, strIndex, pattern, patternIndex + 2);
                }
                // determine 字符 和 模式是否match
                if (str[strIndex] == pattern[patternIndex] || pattern[patternIndex] == '.')
                {
                    return
                    // 把*和前面算0次
                    matchCore(str, strIndex, pattern, patternIndex + 2) ||
                    // 把*和前面算1次
                    matchCore(str, strIndex + 1, pattern, patternIndex + 2) ||
                    // 继续用*和前面的匹配
                    matchCore(str, strIndex + 1, pattern, patternIndex);
                }
                else
                {
                    // determine * 后面的模式是否匹配
                    return matchCore(str, strIndex, pattern, patternIndex + 2);
                }
            }
            // second index isn't *
            else
            {
                if (strIndex >= str.Length)
                {
                    return false;
                }
                if (str[strIndex] == pattern[patternIndex] || (pattern[patternIndex] == '.' && strIndex < str.Length))
                {
                    // match success
                    return matchCore(str, strIndex + 1, pattern, patternIndex + 1);
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
