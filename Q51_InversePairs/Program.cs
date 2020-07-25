using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q51_InversePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            int[] input = { 7, 5, 6, 4 };

            int re = s.ReversePairs(input);

            Console.ReadKey();
        }
    }

    // 解法一：从头开始，每遍历到一个数，都跟这个数后面每个数字对比。两层循环，时间复杂度O(n^2)

    /// <summary>
    /// 解法二：利用归并排序的分治思想。先把数组拆到最小，然后比较，记录，再整合。
    /// 时间复杂度：O(n*logn)
    /// 空间复杂度：O(n) 辅助数组
    /// </summary>
    public class Solution
    {
        public int ReversePairs(int[] nums)
        {
            // 验证有效性
            if (nums == null || nums.Length < 2)
            {
                return 0;
            }

            // 因为是原地修改的，为了不破坏输入数组，新构建一个
            int[] array = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                array[i] = nums[i];
            }
            int[] temArray = new int[array.Length];


            return ReverseCore(array, temArray, 0, array.Length - 1);
        }

        private int ReverseCore(int[] array, int[] temArray, int start, int end)
        {
            if (start == end)
            {
                return 0;
            }

            //int mid = (start>>1) + (end >> 1);
            int mid = start + (end - start) / 2;
            int leftCount = ReverseCore(array, temArray, start, mid);
            int rightCore = ReverseCore(array, temArray, mid + 1, end);

            if (array[mid] <= array[mid + 1])
            {
                return leftCount + rightCore;
            }

            for (int i = start; i < end + 1; i++)
            {
                temArray[i] = array[i];
            }

            int currentCount = 0;
            int leftIndex = mid;
            int rightIndex = end;
            int latsIndex = end;

            while (leftIndex >= start && rightIndex > mid)
            {
                if (temArray[leftIndex] > temArray[rightIndex])
                {
                    currentCount += (rightIndex - mid);
                    array[latsIndex--] = temArray[leftIndex--];
                }
                else if (temArray[leftIndex] < temArray[rightIndex])
                {
                    array[latsIndex--] = temArray[rightIndex--];
                }
                else
                {
                    array[latsIndex--] = temArray[rightIndex--];
                }
            }

            if (leftIndex < start)
            {
                for (int i = rightIndex; i > mid; i--)
                {
                    array[latsIndex--] = temArray[i];
                }
            }

            if (rightIndex < mid + 1)
            {
                for (int i = leftIndex; i >= start; i--)
                {
                    array[latsIndex--] = temArray[i];
                }
            }


            return leftCount + rightCore + currentCount;
        }
    }
}
