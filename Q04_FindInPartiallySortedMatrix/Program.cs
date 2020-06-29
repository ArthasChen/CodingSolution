using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04_FindInPartiallySortedMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public bool FindNumberIn2DArray(int[][] matrix, int target)
        {
            if (matrix.Length == 0)
            {
                return false;
            }

            bool isFindOut = false;

            int maxIndex = 0;
            int xLength = matrix[0].Length;
            int yLength = matrix.Length;

            maxIndex = xLength;

            for (int y = 0; y < yLength; y++)
            {
                for (int x = 0; x < maxIndex; x++)
                {
                    if (matrix[y][x] < target)
                    {

                    }
                    else if (matrix[y][x] > target)
                    {
                        maxIndex = x;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return isFindOut;
        }
    }
}
