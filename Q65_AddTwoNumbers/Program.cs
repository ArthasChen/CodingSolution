using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q65_AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s= new Solution();
            var re= s.Add(15, 6);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int Add(int a, int b)
        {
            int sum = a;
            int tem = b;
            int lastSum =0;
            int lastTem = 1;
            while (tem != 0)
            {
                lastSum = sum ^ tem;
                lastTem = (sum & tem) << 1;

                tem = (lastSum & lastTem) << 1;
                sum = lastSum ^ lastTem;
            }

            return sum;
        }
    }
}
