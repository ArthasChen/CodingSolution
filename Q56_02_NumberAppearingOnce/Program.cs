using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q56_02_NumberAppearingOnce
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = { 1, 12, 1, 1,4,4,4 };
            Solution s = new Solution();
            var a = s.SingleNumber(input);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1) 辅助数组是固定长度为32的数组，因此是常数级别的空间复杂度。
    /// </summary>
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            int[] bitArray = new int[32];

            for (int j = 0; j < nums.Length; j++)
            {
                int num = 1;

                for (int i = 31; i >= 0; i--)
                {
                    int toBeAddNum = (nums[j] & num) != 0 ? 1 : 0;
                    bitArray[i] += toBeAddNum;
                    num = num << 1;
                }
            }

            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                result = result << 1;

                if (bitArray[i] % 3 != 0)
                {
                    result += 1;
                }

                // 这一行是之前算错的地方，题目规定，数组的所有的数都是正数，并且给出的范围是int的正数范围，int 32位里面最高位是符号位，0表示正数，
                // 因此我们构建返回值的时候，0一开始就应该往左移位，用来表示符号位，然后开始计算各个位上的数。
                //result = result << 1;
            }

            return result;
        }
    }
}
