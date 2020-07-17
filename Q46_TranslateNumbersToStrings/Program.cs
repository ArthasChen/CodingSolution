using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q46_TranslateNumbersToStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var a = s.TranslateNum(26);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 解法一
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n) 辅助数组
    /// </summary>
    public class Solution
    {
        public int TranslateNum(int num)
        {
            string strOfNum = num.ToString();
            int length = strOfNum.Length;

            int[] dp = new int[length];
            dp[0] = 1;

            for (int i = 1; i < length; i++)
            {
                dp[i] = dp[i - 1];

                char a = strOfNum[i - 1];
                char b = strOfNum[i];
                int temNum = (a - '0') * 10 + (b - '0');

                // 这里判断必须大于等于10，因为如果两位数是01至09，这样是不算两位数的。
                if (temNum >= 10 && temNum <= 25)
                {
                    if (i - 2 < 0)
                    {
                        dp[i]++;
                    }
                    else
                    {
                        dp[i] += dp[i - 2];
                    }
                }
            }

            return dp[length - 1];
        }
    }
}
