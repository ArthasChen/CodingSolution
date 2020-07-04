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

            Solution2 s2 = new Solution2();
            s2.FirstUniqChar("");

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 解法一
    /// 时间复杂度 O(n) 两次遍历.第一次遍历数组，第二次遍历哈希表或者数组。
    /// 空间复杂度 O(n) 需要额外哈希表
    /// </summary>
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
    /// 自己构造一个哈希表，通过定义一个256位的数组，用char的数值表示下标.这么做的优点在于省去了判断当前字符是否在哈希表里这一步。
    /// 时间复杂度 O(n) 两次遍历.第一次遍历数组，第二次遍历哈希表或者数组。
    /// 空间复杂度 O(n) 需要额外哈希表，但是这个哈希表是自己构建的，用char的数值作为下标，默认数组就包含char了，直接累加就行了，省去了采用系统提供的哈希表，自己还要判断这个步骤。
    /// </summary>
    public class Solution2
    {
        public char FirstUniqChar(string s)
        {
            char result = ' ';

            if (string.IsNullOrEmpty(s))
            {
                return result;
            }

            int[] charArray = new int[256];

            for (int i = 0; i < s.Length; i++)
            {
                char theChar = s[i];

                charArray[theChar] = charArray[theChar] + 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                char theChar = s[i];

                if (charArray[theChar] == 1)
                {
                    result = theChar;
                    break;
                }
            }


            return result;
        }
    }
}
