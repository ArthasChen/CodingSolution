using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Q50_02_FirstCharacterInStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution so = new Solution();
            //Console.WriteLine(so.FirstAppearingOnce());
            char c;
           

            Console.ReadKey();
        }
    }

    class Solution
    {
        private int[] array = new int[256];
        private char[] arrayChars = new char[] { 'g', 'o', 'o','g','l' };
        int count = 0;

        public Solution()
        {
            InitArray();
        }

        public void InitArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -1;
            }
        }

        public char FirstAppearingOnce()
        {

            int min = int.MaxValue; 
            int minIndex = -1;

            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (array[i] > -1)
            //    {
            //        min = array[i];
            //        break;
            //    }
            //}

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]>-1 && array[i]<min)
                {
                    min = array[i];
                    minIndex = i;
                }   
            }

            return minIndex > -1 ? (char) minIndex : '#';

        }

        public void Insert(char c)
        {
            // write code here
            if (array[c] == -1)
            {
                array[c] = count;
            }
            else if (array[c] >= 0)
            {
                array[c] = -2;
            }

            count++;
        }


    }
}
