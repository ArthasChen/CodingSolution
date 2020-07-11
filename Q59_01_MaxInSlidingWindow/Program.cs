using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q59_01_MaxInSlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums =
            {
                -95, 92, -85, 59, -59, -14, 88, -39, 2, 92, 94, 79, 78, -58, 37, 48, 63, -91, 91, 74, -28, 39,
                90, -9, -72, -88, -72, 93, 38, 14, -83, -2, 21, 4, -75, -65, 3, 63, 100, 59, -48, 43, 35, -49, 48, -36,
                -64, -13, -7, -29, 87, 34, 56, -39, -5, -27, -28, 10, -57, 100, -43, -98, 19, -59, 78, -28, -91, 67, 41,
                -64, 76,
                5, -58, -89, 83, 26, -7, -82, -32, -76, 86, 52, -6, 84, 20, 51, -86, 26, 46, 35, -23, 30, -51, 54, 19,
                30, 27, 80, 45, 22

            };
            int k = 10;
            int[] test =
            {
                92, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 91, 91, 91, 91, 91, 91, 91, 93, 93, 93, 93, 93, 93, 93, 93,
                93, 93, 63, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 59, -7, 87, 87, 87, 87, 87, 87, 87, 87,
                87, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 78, 78, 78, 78, 78, 83, 83, 83, 83, 83, 83, 86,
                86, 86, 86, 86, 86, 86, 86, 86, 86, 84, 84, 84, 54, 54, 54, 54, 80, 80, 80
            };

            int[] test2 = { 2, 3, 4, 2, 6, 2, 5, 1 };
            int[] test3 = { 7, 2, 4 };
            Solution s = new Solution();
            var re = s.MaxSlidingWindow(test3, 2);

            Console.ReadKey();
        }
    }

    //public class Solution
    //{
    //    public int[] MaxSlidingWindow(int[] nums, int k)
    //    {
    //        int[] maxArray = new int[0];

    //        // 题目规定 k <= 数组大小,因此这里不再做判断
    //        if (nums == null || nums.Length <= 0 || k <= 0)
    //        {
    //            return maxArray;
    //        }

    //        if (k == 1)
    //        {
    //            return nums;
    //        }

    //        int arrayLength = nums.Length - k + 1;
    //        maxArray = new int[arrayLength];
    //        int maxIndex = -1;
    //        int maxSecondIndex = -1;
    //        int maxNum = 0;
    //        int leftWindow = 0;
    //        int rightWindow = k - 1;

    //        for (int i = 0; i < arrayLength; i++)
    //        {
    //            // 上个窗口最大值在滑动窗口里
    //            if (maxIndex >= leftWindow && maxIndex <= rightWindow)
    //            {
    //                // 窗口新的值比最大值大，分配最大值和第二大值
    //                if (nums[rightWindow] > nums[maxIndex])
    //                {
    //                    maxSecondIndex = maxIndex;
    //                    maxIndex = rightWindow;
    //                }
    //                // 窗口新的值比最大值小，比较新值和次大值，
    //                else if (nums[rightWindow] < nums[maxIndex])
    //                {
    //                    // 新值大于等于次大值 分配 ，否则不变
    //                    //if (nums[rightWindow] >= nums[maxSecondIndex])
    //                    //{
    //                    //    maxSecondIndex = rightWindow;
    //                    //}

    //                    // 计算窗口里的第二大值，这里为了保证不修改数组，跳过了最大值，分了2次遍历。
    //                    if (maxIndex != leftWindow)
    //                    {
    //                        maxSecondIndex = leftWindow;
    //                        for (int j = leftWindow + 1; j < maxIndex; j++)
    //                        {
    //                            if (nums[maxSecondIndex] <= nums[j])
    //                            {
    //                                maxSecondIndex = j;
    //                            }
    //                        }

    //                        for (int j = maxIndex + 1; j <= rightWindow; j++)
    //                        {
    //                            if (nums[maxSecondIndex] <= nums[j])
    //                            {
    //                                maxSecondIndex = j;
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        maxSecondIndex = leftWindow + 1;

    //                        for (int j = leftWindow + 2; j <= rightWindow; j++)
    //                        {
    //                            if (nums[maxSecondIndex] <= nums[j])
    //                            {
    //                                maxSecondIndex = j;
    //                            }
    //                        }
    //                    }

    //                }
    //                // 窗口新的值等于最大值，分配最大值和次大值
    //                else
    //                {
    //                    maxSecondIndex = maxIndex;
    //                    maxIndex = rightWindow;
    //                }

    //                // 获取最大值，添加进数组
    //                maxNum = nums[maxIndex];
    //                maxArray[i] = maxNum;
    //            }
    //            // 上个窗口最大值不在滑动窗口里，跟第二大值比较
    //            else if (maxSecondIndex >= leftWindow && maxSecondIndex <= rightWindow)
    //            {
    //                // 窗口新的值比第二大值大，分配最大值和第二大值
    //                if (nums[rightWindow] > nums[maxSecondIndex])
    //                {
    //                    maxIndex = rightWindow;
    //                }
    //                // 窗口新的值比第二大值小，分配最大值和第二大值
    //                else if (nums[rightWindow] < nums[maxSecondIndex])
    //                {
    //                    maxIndex = maxSecondIndex;
    //                    maxSecondIndex = rightWindow;
    //                }
    //                // 窗口新的值等于第二大值，最大值和次大值 都为新值
    //                else
    //                {
    //                    maxIndex = rightWindow;
    //                }

    //                // 获取最大值，添加进数组
    //                maxNum = nums[maxIndex];
    //                maxArray[i] = maxNum;
    //            }
    //            // 上个窗口最大值和第二大值比较都不在滑动窗口里，针对i=0时有效
    //            else
    //            {
    //                maxIndex = 0;
    //                // 计算第一个窗口里的最大值
    //                for (int j = 1; j < k; j++)
    //                {
    //                    if (nums[maxIndex] < nums[j])
    //                    {
    //                        maxIndex = j;
    //                    }
    //                }



    //                if (maxIndex != 0)
    //                {
    //                    // 计算第一个窗口里的第二大值，这里为了保证不修改数组，跳过了最大值，分了2次遍历。
    //                    maxSecondIndex = 0;
    //                    for (int j = 1; j < maxIndex; j++)
    //                    {
    //                        if (nums[maxSecondIndex] <= nums[j])
    //                        {
    //                            maxSecondIndex = j;
    //                        }
    //                    }

    //                    for (int j = maxIndex + 1; j < k; j++)
    //                    {
    //                        if (nums[maxSecondIndex] <= nums[j])
    //                        {
    //                            maxSecondIndex = j;
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    maxSecondIndex = 1;

    //                    for (int j = 2; j < k; j++)
    //                    {
    //                        if (nums[maxSecondIndex] <= nums[j])
    //                        {
    //                            maxSecondIndex = j;
    //                        }
    //                    }
    //                }



    //                maxNum = nums[maxIndex];
    //                maxArray[i] = maxNum;
    //            }

    //            // 计算下个滑动窗口
    //            leftWindow++;
    //            rightWindow++;
    //        }

    //        return maxArray;
    //    }
    //}


    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int[] maxArray = new int[0];

            // 题目规定 k <= 数组大小,因此这里不再做判断
            if (nums == null || nums.Length <= 0 || k <= 0)
            {
                return maxArray;
            }

            if (k == 1)
            {
                return nums;
            }

            maxArray = new int[nums.Length - k + 1];

            List<int> listIndex = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i <= k - 1)
                {
                    while (listIndex.Count != 0 && nums[i] >= nums[listIndex.Last()])
                    {
                        listIndex.RemoveAt(listIndex.LastIndexOf(listIndex.Last()));
                    }

                    listIndex.Add(i);
                    if (i == k - 1)
                    {
                        maxArray[i - k + 1] = nums[listIndex.First()];
                    }
                }
                else
                {
                    if (i - listIndex.First() < k)
                    {

                        while (listIndex.Count != 0 && nums[i] >= nums[listIndex.Last()])
                        {
                            listIndex.RemoveAt(listIndex.LastIndexOf(listIndex.Last()));
                        }

                        listIndex.Add(i);
                    }
                    else
                    {
                        listIndex.RemoveAt(listIndex.IndexOf(listIndex.First()));

                        while (listIndex.Count != 0 && nums[i] >= nums[listIndex.Last()])
                        {
                            listIndex.RemoveAt(listIndex.LastIndexOf(listIndex.Last()));
                        }

                        listIndex.Add(i);

                    }


                    if (listIndex.Count != 0)
                    {
                        maxArray[i - k + 1] = nums[listIndex.First()];
                    }

                }
            }

            return maxArray;
        }
    }
}
