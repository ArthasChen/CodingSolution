using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q29_PrintMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution test = new Solution();
            //int[][] aa = new int[3][] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
            //int[][] aa = new int[][] { new int[1] { 1 }, new int[1] { 2 }, new int[1] { 3 }, new int[1] { 4 } };
            int[][] aa = new int[3][] { new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 2, 3, 4 } };


            var s = test.SpiralOrder(aa);


            Console.ReadKey();
        }
    }

    public class Solution
    {
        //public int[] SpiralOrder(int[][] matrix)
        //{
        //    if (matrix == null)
        //    {
        //        return null;
        //    }

        //    if (matrix.Length == 0)
        //    {
        //        return new int[] { };
        //    }

        //    int x1 = 0;
        //    int x2 = matrix[0].Length - 1;
        //    int y1 = 0;
        //    int y2 = matrix.Length - 1;
        //    int writeIndex = 0;

        //    int[] result = new int[(x2 + 1) * (y2 + 1)];

        //    while (x1 <= x2 && y1 <= y2)
        //    {
        //        writeIndex = PrintMatrix(matrix, x1, x2, y1, y2, writeIndex, result);

        //        x1 += 1;
        //        x2 -= 1;
        //        y1 += 1;
        //        y2 -= 1;
        //    }

        //    return result;
        //}

        //public int PrintMatrix(int[][] matrix, int x1, int x2, int y1, int y2, int index, int[] resultArray)
        //{
        //    // print top level

        //    for (int i = x1; i <= x2; i++)
        //    {
        //        resultArray[index++] = matrix[x1][i];
        //    }

        //    if (y1 == y2)
        //    {
        //        return index;
        //    }

        //    // print right side level
        //    for (int i = y1 + 1; i < y2; i++)
        //    {
        //        resultArray[index++] = matrix[i][x2];
        //    }

        //    // print bottom level
        //    for (int i = x2; i >= x1; i--)
        //    {
        //        resultArray[index++] = matrix[y2][i];
        //    }
        //    if (x1 == x2)
        //    {
        //        return index;
        //    }

        //    // print left side level
        //    for (int i = y2 - 1; i > y1; i--)
        //    {
        //        resultArray[index++] = matrix[i][x1];
        //    }

        //    return index;
        //}

        /// <summary>
        /// 这个版本跟上面注释的一样，只是把方法体中的内容提出来到While中，减少方法调用的时间。
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[] SpiralOrder(int[][] matrix)
        {
            if (matrix == null)
            {
                return null;
            }

            if (matrix.Length == 0)
            {
                return new int[] { };
            }

            int x1 = 0;
            int x2 = matrix[0].Length - 1;
            int y1 = 0;
            int y2 = matrix.Length - 1;
            int writeIndex = 0;

            int[] result = new int[(x2 + 1) * (y2 + 1)];

            while (x1 <= x2 && y1 <= y2)
            {
                for (int i = x1; i <= x2; i++)
                {
                    result[writeIndex++] = matrix[x1][i];
                }

                if (y1 == y2)
                {
                    x1 += 1;
                    x2 -= 1;
                    y1 += 1;
                    y2 -= 1;
                    continue;
                }

                // print right side level
                for (int i = y1 + 1; i < y2; i++)
                {
                    result[writeIndex++] = matrix[i][x2];
                }

                // print bottom level
                for (int i = x2; i >= x1; i--)
                {
                    result[writeIndex++] = matrix[y2][i];
                }
                if (x1 == x2)
                {
                    x1 += 1;
                    x2 -= 1;
                    y1 += 1;
                    y2 -= 1;
                    continue;
                }

                // print left side level
                for (int i = y2 - 1; i > y1; i--)
                {
                    result[writeIndex++] = matrix[i][x1];
                }

                x1 += 1;
                x2 -= 1;
                y1 += 1;
                y2 -= 1;
            }

            return result;
        }
    }
}
