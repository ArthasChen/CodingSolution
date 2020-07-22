using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q61_ContinousCards
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public bool IsStraight(int[] nums)
        {
            if (nums == null || nums.Length != 5)
            {
                return false;
            }


            // 1 排序
            Array.Sort(nums);

            // 2 从第一个不为0的数开始遍历，记录到尾之间缺少的数的个数
            // 3 当0的个数大于等于缺少个数时true else false

            int countsOf0 = 0;
            int countsOfMiss = 0;
            int indexOf0 = 0;

            while (nums[indexOf0] == 0)
            {
                countsOf0++;
                indexOf0++;
            }

            for (int i = countsOf0 + 1; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] == 0)
                {
                    return false;
                }

                if (nums[i] - nums[i - 1] >= 2)
                {
                    countsOfMiss += nums[i] - nums[i - 1] - 1;
                }
            }

            if (countsOfMiss <= countsOf0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
