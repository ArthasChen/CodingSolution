using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q63_MaximalProfit
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1)
            {
                return 0;
            }

            int currentProfit = 0;
            int befroeMin = prices[0];
            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                currentProfit = prices[i] - befroeMin;

                if (currentProfit < 0)
                {
                    befroeMin = prices[i];
                    continue;
                }

                if (currentProfit > maxProfit)
                {
                    maxProfit = currentProfit;
                }
            }

            return maxProfit;
        }
    }
}
