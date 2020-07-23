using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q47_MaxValueOfGifts
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 解法一
    /// 时间复杂度：O(mn)
    /// 空间复杂度：O(mn) 借助mn大小的数组二维数组
    /// </summary>
    public class Solution
    {
        public int MaxValue(int[][] grid)
        {
            if (grid == null || grid.Length <= 0 || grid[0].Length <= 0)
            {
                return 0;
            }

            int rows = grid.Length;
            int cols = grid[0].Length;

            int[,] maxValue = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int upValue = 0;
                    int leftValue = 0;

                    if (i == 0 && j == 0)
                    {
                        maxValue[i, j] = grid[i][j];
                    }
                    else
                    {
                        if (i > 0)
                        {
                            upValue = maxValue[i - 1, j];
                        }

                        if (j > 0)
                        {
                            leftValue = maxValue[i, j - 1];
                        }

                        //if (upValue >= leftValue)
                        //{
                        //    maxValue[i, j] = upValue + grid[i][j];
                        //}
                        //else
                        //{
                        //    maxValue[i, j] = leftValue + grid[i][j];
                        //}

                        maxValue[i, j] = Math.Max(upValue,leftValue) + grid[i][j];
                    }
                }
            }

            return maxValue[rows - 1, cols - 1];
        }
    }

    /// <summary>
    /// 解法二，修改原数组
    /// 时间复杂度：O(mn)
    /// 空间复杂度：O(1) 
    /// </summary>
    public class Solution2
    {
        public int MaxValue(int[][] grid)
        {
            if (grid == null || grid.Length <= 0 || grid[0].Length <= 0)
            {
                return 0;
            }

            int rows = grid.Length;
            int cols = grid[0].Length;

            // 先算第一行
            for (int i = 0; i < 1; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    grid[i][j] += grid[i][j - 1];
                }
            }

            // 再算第一列
            for (int j = 0; j < 1; j++)
            {
                for (int i = 1; i < rows; i++)
                {
                    grid[i][j] += grid[i - 1][j];
                }
            }

            // 然后从第二行第二列开始 避免 m n 比较大的时候 重复判断
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    grid[i][j] += Math.Max(grid[i - 1][j], grid[i][j - 1]);
                }
            }

            return grid[rows - 1][cols - 1];
        }
    }
}
