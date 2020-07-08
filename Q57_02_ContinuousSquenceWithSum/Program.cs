using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q57_02_ContinuousSquenceWithSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.FindContinuousSequence(9);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int[][] FindContinuousSequence(int target)
        {
            int[][] result = new int[0][];
            if (target <= 2)
            {
                return result;
            }

            List<int[]> list = new List<int[]>();

            for (int i = 1; i <= target / 2; i++)
            {
                int num = i;
                bool isContinue = true;
                int sum = 0;
                int lastNum = 0;
                while (isContinue)
                {
                    sum += num;
                    if (sum < target)
                    {
                        num++;
                    }
                    else if (sum == target)
                    {
                        lastNum = num;
                        isContinue = false;
                    }
                    else
                    {
                        break;
                    }
                }

                if (lastNum != 0)
                {
                    int[] addArray = new int[lastNum - i + 1];
                    for (int j = i; j <= lastNum; j++)
                    {
                        addArray[j - i] = j;
                    }
                    list.Add(addArray);
                }
            }

            result = new int[list.Count][];
            for (int i = 0; i < list.Count; i++)
            {
                result[i] = list[i];
            }

            return result;
        }
    }
}
