using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q14_01_CuttingRope1
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var a = s.CuttingRope(10);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 解法一：动态规划
    /// 时间复杂度：O(n^2)
    /// 空间复杂度：O(n)
    /// dp[n] 表示长度为n的绳子被剪后乘积的最大值
    /// dp[n] = Max(dp[i] * dp[n-i])   1 <= i < n
    /// </summary>
    public class Solution
    {

        public int CuttingRope(int n)
        {
            int[] dp = new int[n + 1];
            if (n < 2)
            {
                return 0;
            }

            if (n == 2)
            {
                return 1;
            }

            if (n == 3)
            {
                return 2;
            }

            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;// dp[2]可以分解成1和1，理论上dp[2] = 1*1 =1，但是乘积没有“不剪”大，因此这里直接给定dp[2]=2。
            dp[3] = 3;// dp[3]可以分解成1和2，理论上dp[3] = 1*2 =2，但是乘积没有”不剪“大，因此这里直接给定dp[3]=3。
                      // 如果这里完全按照定义来，即dp[n]表示长度为n的绳子被剪后乘积的最大值，则在比较乘积最大值的时候多判断一步跟n直接对比，即n一刀都不剪。

            for (int i = 4; i < n + 1; i++)
            {
                int max = 0;

                for (int j = 1; j <= i / 2; j++)// 可以写j<i但是多余计算
                {
                    int products = dp[j] * dp[i - j];
                    if (products > max)
                    {
                        max = products;
                    }

                    dp[i] = max;
                }
            }

            #region 下面的代码为需要判断n是否继续分解的思路
            //dp[0] = 0;
            //dp[1] = 0;
            //dp[2] = 1;
            //dp[3] = 2;

            //for (int i = 2; i < n + 1; i++)
            //{
            //    int max = 0;

            //    for (int j = 1; j <= i / 2; j++)// 可以写j<i但是多余计算
            //    {
            //        int products = dp[j] * dp[i - j];
            //        max = Math.Max(Math.Max(max, products),i);// 在乘积以及之前最大的乘积以及自身（不剪）之间取最大值
            //    }

            //    dp[i] = max;
            //}
            #endregion

            return dp[n];
        }
    }
}
