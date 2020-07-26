using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q48_LongestSubstringWithoutDup
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "ab";

            Solution s= new Solution();
            var v = s.LengthOfLongestSubstring(input);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1) 因为保存的是字符，字符的 ASCII 码范围为 0 ~ 127 ，哈希表 dic 最多使用 O(128) = O(1) 大小的额外空间。
    /// </summary>
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            // verification
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            if (s.Length == 1)
            {
                return 1;
            }

            // s 长度大于等于2
            char[] charArray = s.ToCharArray();

            // 定义 dp[i] 以i下标为结尾的 不包含重复字符的 子字符串 的最大长度
            int[] dp = new int[s.Length];
            dp[0] = 1;

            // 定义 MaxLength ，遍历i的时候，跟dp[i]比较大小 保存较大的数到MaxLength 最后返回
            int maxLength = 1;

            // 定义 哈希表，用来存某字符最后一次出现的索引;  也可以自己构建一个26个int的数组，数组的下标是字母的顺序，0为A，25为Z，然后存索引。
            Dictionary<char, int> indexOfLastChar = new Dictionary<char, int>();
            indexOfLastChar[charArray[0]] = 0;

            for (int i = 1; i < charArray.Length; i++)
            {
                if (indexOfLastChar.ContainsKey(charArray[i]))
                {
                    int lengthOfCurretnCharToLastChar = i - indexOfLastChar[charArray[i]];

                    if (lengthOfCurretnCharToLastChar <= dp[i - 1])
                    {
                        dp[i] = lengthOfCurretnCharToLastChar;
                    }
                    else
                    {
                        dp[i] = dp[i - 1] + 1;
                    }
                }
                else
                {
                    dp[i] = dp[i - 1] + 1;
                }

                indexOfLastChar[charArray[i]] = i;
                maxLength = Math.Max(maxLength, dp[i]);
            }

            return maxLength;
        }
    }
}
