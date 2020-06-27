using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03_01_DuplicationInArray
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int FindRepeatNumber(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] != i)
                {
                    if (nums[i] != nums[nums[i]])
                    {
                        int tem = nums[nums[i]];
                        nums[nums[i]] = nums[i];
                        nums[i] = tem;
                    }
                    else
                    {
                        return nums[i];
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// 牛客答案
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="duplication"></param>
        /// <returns></returns>
        public bool duplicate(int[] numbers, int[] duplication)
        {
            // write code here
            if (numbers.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                while (numbers[i] != i)
                {
                    if (numbers[i] != numbers[numbers[i]])
                    {
                        int tem = numbers[numbers[i]];
                        numbers[numbers[i]] = numbers[i];
                        numbers[i] = tem;
                    }
                    else
                    {
                        duplication[0] = numbers[i];
                        return true;
                    }
                }
            }

            return false;

        }
    }
}
