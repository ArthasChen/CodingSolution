using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q64_Accumulate
{
    class Program
    {
        static void Main(string[] args)
        {

            Solution s = new Solution();

            var inffff = s.SumNums(0);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n)
    /// </summary>
    public struct Solution
    {
        public int SumNums(int n)
        {
            Temp.Reset();
            Temp[] tempArr = Enumerable.Range(1, n).Select(i => new Temp()).ToArray();

            return Temp.ReturnSum();
        }
    }

    public class Temp
    {
        private static int n = 0;
        private static int sum = 0;

        public Temp()
        {
            n++;
            sum += n;
        }

        public static int ReturnSum()
        {
            return sum;
        }

        public static void Reset()
        {
            n = 0;
            sum = 0;
        }
    }
}
