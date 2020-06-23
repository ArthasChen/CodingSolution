using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11_MinNumberInRotatedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 1,1,1 };

            Solution s = new Solution();
            var aaa = s.MinArray(intArray);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 方法1：遍历，找最小，略。
    /// 方法2: 二分查找
    /// </summary>
    class Solution
    {
        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="rotateArray"></param>
        /// <returns></returns>
        public int MinArray(int[] rotateArray)
        {
            if (rotateArray.Length <= 0)
            {
                return 0;
            }

            if (rotateArray.Length == 1)
            {
                return rotateArray[0];
            }

            int minNumber = 0;

            int leftIndex = 0;
            int rightIndex = rotateArray.Length - 1;
            // 这么赋值是考虑到0个元素旋转，这样其实数组没有变化，此时数组头元素必然比最后一个大。其余情况都是头元素大于等于最后元素，等于的情况是重复数字截断旋转。
            int midIndex = leftIndex;

            while (rotateArray[leftIndex] >= rotateArray[rightIndex])
            {
                if (rightIndex - leftIndex == 1)
                {
                    midIndex = rightIndex;
                    break;
                }

                // 因为刚开始minIndex赋值为0，而进了这个循环体意味着排出了minIndex是0的情况，因此立刻给minIndex赋值为left和right的中点
                midIndex = leftIndex + (rightIndex - leftIndex) / 2;

                if (rotateArray[leftIndex] == rotateArray[midIndex] && rotateArray[rightIndex] == rotateArray[midIndex])
                {
                    int newArrayLength = rightIndex - leftIndex + 1;
                    int[] newArray = new int[newArrayLength];
                    for (int i = 0; i < newArrayLength; i++)
                    {
                        newArray[i] = rotateArray[i + leftIndex];
                    }
                    // 老老实实顺序查找吧
                    midIndex = GetMinNumber(newArray);
                    break;
                }
                // left < mid 证明旋转的子数组在mid右边
                else if (rotateArray[leftIndex] < rotateArray[midIndex])
                {
                    leftIndex = midIndex;
                    midIndex = leftIndex + (rightIndex - leftIndex) / 2;
                }
                // left == mid 证明mid的数值跟left一样，所以mid一定在旋转数组里，应该继续往左走找最小
                else if (rotateArray[leftIndex] == rotateArray[midIndex])
                {
                    leftIndex = midIndex;
                    midIndex = leftIndex + (rightIndex - leftIndex) / 2;
                }
                // left > mid 证明旋转的子数组在mid左边
                else
                {
                    rightIndex = midIndex;
                    midIndex = leftIndex + (rightIndex - leftIndex) / 2;
                }
            }

            minNumber = rotateArray[midIndex];

            return minNumber;
        }

        private int GetMinNumber(int[] intArray)
        {
            if (intArray.Length <= 0)
            {
                return -1;
            }
            int minIndex = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] < intArray[minIndex])
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
