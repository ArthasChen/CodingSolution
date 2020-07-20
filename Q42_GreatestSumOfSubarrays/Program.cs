using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q42_GreatestSumOfSubarrays
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length <= 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            int maxSum = nums[0];
            int sum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum < nums[i])
                {
                    sum = nums[i];
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            return maxSum;
        }
    }
}
