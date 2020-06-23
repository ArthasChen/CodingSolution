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
            int[] intArray = { 1, 2, 3, 4, 5, 6 };

            Solution s = new Solution();
            var aaa = s.minNumberInRotateArray(intArray);

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
        public int minNumberInRotateArray(int[] rotateArray)
        {
            // write code here
            // 1 2 2 3 4 5 6

            // 1 2 2 3 4 5 6 拿了0个元素旋转
            // 2 3 4 5 6 1 2 从重复元素旋转

            // 3 4 5 6 1 2
            // 5 6 1 2 3 4


            // 0 1 2 3 4 5
            if (rotateArray.Length <= 0)
            {
                return 0;
            }

            int minNumber = 0;

            int leftIndex = 0;
            int rightIndex = rotateArray.Length - 1;
            int midIndex = leftIndex;

            while (rotateArray[leftIndex] >= rotateArray[rightIndex])
            {
                if (rightIndex - leftIndex == 1)
                {
                    midIndex = rightIndex;
                    break;
                }

                // left < mid 证明旋转的子数组在mid右边
                if (rotateArray[leftIndex] < rotateArray[midIndex])
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



            /*
            int minNumber = 0;

            int leftIndex = 0;
            int rightIndex = rotateArray.Length - 1;
            // 这里把midindex改为0 检查 旋转数组从头拿了0个元素到末尾
            int midIndex = leftIndex + (rightIndex - leftIndex) / 2;
            //int midIndex = 0;

            while (midIndex != leftIndex && midIndex != rightIndex)
            {
                if (rotateArray[midIndex] > rotateArray[leftIndex])
                {
                    leftIndex = midIndex;
                    midIndex = leftIndex + (rightIndex - leftIndex) / 2;
                }
                else
                {
                    rightIndex = midIndex;
                    midIndex = leftIndex + (rightIndex - leftIndex) / 2;
                }
            }

            if (rotateArray[leftIndex] > rotateArray[rightIndex])
            {
                minNumber = rotateArray[rightIndex];
            }
            else
            {
                minNumber = rotateArray[leftIndex];
            }*/

            return minNumber;
        }
    }
}
