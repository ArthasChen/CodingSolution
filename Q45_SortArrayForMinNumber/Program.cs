using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q45_SortArrayForMinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] array = new[] { "2", "1" };
            //List<string> a = new List<string>();
            //a.Add("3");
            //a.Add("32");
            //a.Add("321");

            //MyComparer mc = new MyComparer();
            //a.Sort(mc);

            int[] input = { 3, 30, 34, 4, 5 };
            Solution s = new Solution();
            var ss = s.MinNumber(input);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 解法一：不能直接用数值进行对比，有可能产生大数问题。因此需要把整数数组转为字符串数组，然后对两个字符串相加后进行比较，需要实现一个比较器。
    /// 因此思路是，实现一个符合题意得比较器，然后实现一个快速的排序算法，利用比较器来进行排序，然后组合排好序的字符串数组，返回。
    /// 时间复杂度：O(n^2),此方法用了最简单的比较排序，后续改为nlogn的排序算法。
    /// 空间复杂度：O(n) 
    /// </summary>
    public class Solution
    {
        public string MinNumber(int[] nums)
        {
            // verification
            if (nums == null)
            {
                return null;
            }

            if (nums.Length == 0)
            {
                return string.Empty;
            }

            //  
            string[] strArray = new string[nums.Length];
            List<string> strList = new List<string>();
            for (int i = 0; i < nums.Length; i++)
            {
                strArray[i] = nums[i].ToString();
                //strList.Add(nums[i].ToString());
            }

            // 比较排序，后面换成快一点的排序
            CompareSort(strArray);

            //MyComparer mc = new MyComparer();
            //strList.Sort(mc);

            StringBuilder sb = new StringBuilder();
            foreach (var str in strArray)
            {
                sb.Append(str);
            }

            string resuleString = sb.ToString();

            return resuleString;
        }

        private void CompareSort(string[] strArray)
        {
            for (int i = 0; i < strArray.Length; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < strArray.Length; j++)
                {
                    string xy = strArray[minIndex] + strArray[j];
                    string yx = strArray[j] + strArray[minIndex];

                    if (xy.CompareTo(yx) > 0)
                    {
                        minIndex = j;
                    }
                }

                Swap(strArray, i, minIndex);
            }
        }

        private void Swap(string[] strArray, int i, int minIndex)
        {
            string tem = strArray[i];
            strArray[i] = strArray[minIndex];
            strArray[minIndex] = tem;
        }
    }

    public class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string xy = x + y;
            string yx = y + x;

            if (xy.CompareTo(yx) < 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
