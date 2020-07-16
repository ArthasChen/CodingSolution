using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q60_DicesProbability
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var a = s.TwoSum(3);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 根据规律，算出前一半的概率，后一半跟前一半对称。
    /// 把先算出来的值存到哈希表里。
    /// </summary>
    public class Solution
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        public double[] TwoSum(int n)
        {
            double[] resultArray = new double[0];
            if (n <= 0)
            {
                return resultArray;
            }

            double Denominator = Math.Pow(6, n);
            int arrayLength = 5 * n + 1;
            resultArray = new double[arrayLength];
            int min = n * 1;

            for (int i = 0; i < arrayLength; i++)
            {
                int sum = 0;
                int key = min * 1234 + n-1;
                if (dic.ContainsKey(key))
                {
                    resultArray[i] = dic[key] / Denominator;
                    resultArray[arrayLength - 1 - i] = resultArray[i];
                }
                else
                {
                    dic[key] = Find(min, n);
                    resultArray[i] = dic[key] / Denominator;
                    resultArray[arrayLength - 1 - i] = resultArray[i];
                }
              
                if (i == (arrayLength - 1) >> 1)
                {
                    break;
                }

                min++;
            }

            return resultArray;
        }

        public int Find(int target, int counts)
        {
            if (counts == 1)
            {
                return 1;
            }

            int sum = 0;

            for (int i = 1; i <= 6; i++)
            {
                int newTarget = target - i;
                int newCounts = counts - 1;

                if (newTarget < 1 || newTarget < newCounts)
                {
                    break;
                }

                if (newTarget > newCounts * 6)// 可优化，独立判断<1 如果满足 直接退出循环
                {
                    continue;
                }

                int key = newTarget * 1234 + newCounts - 1;
                if (dic.ContainsKey(key))
                {
                    sum += dic[key];
                }
                else
                {
                    dic[key] = Find(newTarget, newCounts);

                    sum += dic[key];
                }
            }

            return sum;
        }
    }
}
