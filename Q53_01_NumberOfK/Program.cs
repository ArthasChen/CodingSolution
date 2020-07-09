using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q53_01_NumberOfK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0,0,1,2,2 };
            int targe = 0;
            Solution s = new Solution();
            int re = s.Search(nums, targe);


            Console.ReadKey();
        }
    }

    /// <summary>
    /// 时间复杂度：O(logn)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            int resultCounts = 0;

            if (nums == null || nums.Length <= 0)
            {
                return resultCounts;
            }

            if (nums.Length <= 2)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == target)
                    {
                        resultCounts++;
                    }
                }
            }
            else
            {
                int leftIndex = 0;
                int rightIndex = nums.Length - 1;
                int midIndex = (rightIndex + leftIndex) / 2;

                while (leftIndex < rightIndex)
                {
                    if (nums[midIndex] == target)
                    {
                        resultCounts++;
                        bool isLeftComplate = false;
                        bool isRightComplate = false;
                        leftIndex = midIndex - 1;
                        rightIndex = midIndex + 1;

                        while (!isLeftComplate || !isRightComplate)
                        {
                            if (leftIndex >= 0 && nums[leftIndex] == target)
                            {
                                resultCounts++;
                                leftIndex--;
                            }
                            else
                            {
                                isLeftComplate = true;
                            }

                            if (rightIndex < nums.Length && nums[rightIndex] == target)
                            {
                                resultCounts++;
                                rightIndex++;
                            }
                            else
                            {
                                isRightComplate = true;
                            }
                        }

                        break;
                    }
                    else if (nums[midIndex] > target)
                    {
                        rightIndex = midIndex - 1;
                        midIndex = (leftIndex + rightIndex) / 2;
                    }
                    else
                    {
                        leftIndex = midIndex + 1;
                        midIndex = (leftIndex + rightIndex) / 2;
                    }
                }

                if (leftIndex >= 0 &&  nums[leftIndex] == target)
                {
                    resultCounts++;
                }
            }

            return resultCounts;
        }
    }
}
