using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q40_KLeastNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var aaa = s.GetLeastNumbers(new int[] { 3, 2, 1 }, 2);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int[] GetLeastNumbers(int[] arr, int k)
        {
            int[] resultArray = new int[] { };

            if (arr == null || k <= 0)
            {
                return resultArray;
            }

            if (arr.Length == 0 || k >= arr.Length)
            {
                return arr;
            }

            resultArray = new int[k];


            for (int i = 0; i < k; i++)
            {
                resultArray[i] = arr[i];
            }

            int indexOfRsultArrayMax = GetMax(resultArray);

            for (int i = k; i < arr.Length; i++)
            {
                if (arr[i] < resultArray[indexOfRsultArrayMax])
                {
                    resultArray[indexOfRsultArrayMax] = arr[i];
                    indexOfRsultArrayMax = GetMax(resultArray);
                }
            }

            return resultArray;
        }

        private int GetMax(int[] resultArray)
        {
            int index = 0;

            for (int i = 0; i < resultArray.Length; i++)
            {
                if (resultArray[index] < resultArray[i])
                {
                    index = i;
                }
            }

            return index;
        }
    }
}
