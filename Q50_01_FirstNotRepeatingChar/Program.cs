using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q50_01_FirstNotRepeatingChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "leetcode";

            Solution s = new Solution();
            var result = s.FirstUniqChar(input);

            Solution2 s2=new Solution2();
            s2.FirstUniqChar("");

            Console.ReadKey();
        }
    }
    public class Solution
    {
        public char FirstUniqChar(string s)
        {
            char result = ' ';

            if (string.IsNullOrEmpty(s))
            {
                return result;
            }

            Dictionary<char, int> repeatChar = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char theChar = Convert.ToChar(s[i]);
                if (!repeatChar.Keys.Contains(theChar))
                {
                    repeatChar[theChar] = 1;
                }
                else
                {
                    repeatChar[theChar] += 1;
                }
            }

            if (repeatChar.Count != 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (repeatChar[s[i]] == 1)
                    {
                        result = s[i];
                        break;
                    }
                }
            }

            return result;
        }
    }

    /// <summary>
    /// 解法二
    /// </summary>
    public class Solution2
    {
        public char FirstUniqChar(string s)
        {
          
        }
    }
}
