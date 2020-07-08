using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q57_01_TwoNumbersWithSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 10, 26, 30, 31, 47, 60 };

            int targe = 40;

            Solution s = new Solution();
            int[] re = s.TwoSum(input, targe);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length <= 1)
            {
                return new int[0];
            }

            int[] resultArray = new int[2];

            int minIndex = 0;
            int maxIndex = nums.Length - 1;


            while (minIndex < maxIndex)
            {
                if (nums[minIndex] + nums[maxIndex] == target)
                {
                    resultArray[0] = nums[minIndex];
                    resultArray[1] = nums[maxIndex];
                    break;
                }
                else if (nums[minIndex] + nums[maxIndex] < target)
                {
                    minIndex++;
                }
                else
                {
                    maxIndex--;
                }
            }


            return resultArray;
        }
    }
}
