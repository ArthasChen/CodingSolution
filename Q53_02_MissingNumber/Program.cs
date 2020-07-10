using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q53_02_MissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = {0, 1, 3};
            Solution s= new Solution();
            int v= s.MissingNumber(a);
        }
    }

    /// <summary>
    /// 时间复杂度：O(logn)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public int MissingNumber(int[] nums)
        {
            if (nums.Length <= 0)
            {
                return 0;
            }

            int leftIndex = 0;
            int rightIndex = nums.Length - 1;

            while (leftIndex <= rightIndex)
            {
                int midIndex = (leftIndex + rightIndex) >> 1;
                if (nums[midIndex] != midIndex)
                {
                    if (midIndex == 0 || nums[midIndex - 1] == (midIndex - 1))
                    {
                        return midIndex;
                    }

                    rightIndex = midIndex - 1;
                }
                else
                {
                    leftIndex = midIndex + 1;
                }

            }

            if (leftIndex == nums.Length)
            {
                return nums.Length;
            }


            return -1;
        }
    }
}
