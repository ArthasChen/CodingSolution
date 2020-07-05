using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q21_ReorderArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ss = new int[] { 1,6,6,6,6,9,2,3,4};
            Solution s=new Solution();
            var a = s.Exchange(ss);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int[] Exchange(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return new int[0];
            }

            int leftIndex = 0;
            int rightIndex = nums.Length - 1;
            bool leftIsOdd = false;
            bool rightIsEven = false;

            while (leftIndex < rightIndex)
            {
                leftIsOdd = (nums[leftIndex] % 2) == 1 ? true : false;
                rightIsEven = (nums[rightIndex] % 2) == 0 ? true : false;


                // 左边是奇数 右边是偶数 分别右移 左移
                if (leftIsOdd && rightIsEven)
                {
                    leftIndex++;
                    rightIndex--;
                }
                // 左边是奇数 右边是奇数 左移 右不动
                else if (leftIsOdd && !rightIsEven)
                {
                    leftIndex++;
                }
                // 左边是偶数 右边是偶数 右移 左不动
                else if (!leftIsOdd && rightIsEven)
                {
                    rightIndex--;
                }
                // 左边是偶数 右边是奇数 对换 然后分别右移 左移
                else
                {
                    int tem = nums[rightIndex];
                    nums[rightIndex] = nums[leftIndex];
                    nums[leftIndex] = tem;

                    leftIndex++;
                    rightIndex--;
                }
            }

            return nums;
        }
    }
}
