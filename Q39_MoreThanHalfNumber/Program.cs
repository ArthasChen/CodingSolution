using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q39_MoreThanHalfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3,3,4 };

            Solution2 s = new Solution2();
            int re = s.MajorityElement(array);


            Console.ReadKey();
        }
    }

    /// <summary>
    /// 解法一
    /// 最朴素的解法，遍历一遍数组，把值存到哈希表里，哈希表的key是数组的每个值，value是对应出现的次数，然后遍历哈希表，找到value 大于数组一般的 key。
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n) 
    /// </summary>
    public class Solution
    {
        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    dic[nums[i]]++;
                }
                else
                {
                    dic[nums[i]] = 1;
                }
            }

            foreach (var item in dic)
            {
                if (item.Value > nums.Length / 2)
                {
                    return item.Key;
                }
            }

            return 0;
        }
    }

    /// <summary>
    /// 解法二
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution2
    {
        public int MajorityElement(int[] nums)
        {
            int preValue = 0;
            int counts = 0;

            // 从题意得出返回的值出现的次数必然大于其它所有数字个数之和。
            // 思路是用1个变量保存前一个值，用1个变量保存次数，初始存入某个值，次数+1，然后到后一个值，如果等于前一个值，次数+1；如果不等于前一个值，次数-1；当到某个值时，次数等于0，保存此值，次数+1
            // 结束时候如果次数大于0，当前保存的值就是出现次数超过一半的值。
            for (int i = 0; i < nums.Length; i++)
            {
                if (counts == 0)
                {
                    preValue = nums[i];
                    counts++;
                }
                else if (nums[i] == preValue)
                {
                    counts++;
                }
                else
                {
                    counts--;
                }
            }

            // 因为题意说给定的数组中必然有一个值出现的次数大于一般，因此可以直接返回preValue，如果没有这个保证，需要判断count，如果大于0，则preValue是返回值


            return preValue;
        }
    }
}
