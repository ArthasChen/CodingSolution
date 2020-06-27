using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Q10_01_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int a = s.Fib(45);
            //int b = s.FibRecurisve(47);

            Solution2 s2=new Solution2();
            var f = s2.Fib(10);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        public int Fib(int n)
        {
            if (n <= 1)
            {
                return n % 1000000007;
            }

            if (dic.ContainsKey(n) == true)
            {
                return dic[n];
            }
            else
            {
                dic[n] = (Fib(n - 1) + Fib(n - 2)) % 1000000007;
                return dic[n];
            }
        }

        Dictionary<int, int> dicRecurisve = new Dictionary<int, int>();
        public int FibRecurisve(int n)
        {
            if (n <= 1)
            {
                return n;
            }


            dicRecurisve[n] = FibRecurisve(n - 1) + FibRecurisve(n - 2);
            return dicRecurisve[n];
        }
    }

    public class Solution2
    {
        public int Fib(int n)
        {
            if (n<=1)
            {
                return n % 1000000007;
            }

            int sum1 = 1;
            int sum2 = 0;
            int sum = 0;

            for (int i = 2; i <= n; i++)
            {
                sum = (sum1 % 1000000007 + sum2 % 1000000007) % 1000000007;
                sum2 = sum1 % 1000000007;
                sum1 = sum;
            }

            return sum;
        }
    }
}
