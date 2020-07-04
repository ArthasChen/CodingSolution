using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q62_LastNumberInCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int a = s.LastRemaining(10, 17);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int LastRemaining(int n, int m)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(i);
            }

            int step = 0;
            int index = 0;

            while (list.Count > 1)
            {
                step = m + index;
                while (step > list.Count)
                {
                    step -= list.Count;
                }

                index = step - 1;

                list.RemoveAt(index);
            }

            return list[0];
        }
    }
}
