using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q13_RobotMove
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int aaa = s.MovingCount(3, 1, 0);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 时间复杂度：O(mn)
    /// 空间复杂度：O(mn)
    /// </summary>
    public class Solution
    {
        public int MovingCount(int m, int n, int k)
        {
            if (m < 1 || n < 1)
            {
                return 0;
            }

            bool[,] visted = new bool[m, n];

            return FindPath(m, n, 0, 0, visted, k);
        }

        public int FindPath(int m, int n, int row, int col, bool[,] visited, int k)
        {
            int pathCounts = 0;

            if (row < 0 || row >= m || col < 0 || col >= n || visited[row, col] == true)
            {
                return pathCounts;
            }

            // 计算当前路径是否合法
            if (Determine(row, col, k))
            {
                visited[row, col] = true;
                pathCounts = 1 + FindPath(m, n, row - 1, col, visited, k) + FindPath(m, n, row + 1, col, visited, k) +
                             FindPath(m, n, row, col - 1, visited, k) + FindPath(m, n, row, col + 1, visited, k);
            }

            return pathCounts;
        }

        private bool Determine(int row, int col, int i)
        {
            bool result = false;
            int sum = 0;

            while ((row / 10) != 0)
            {
                sum += row % 10;
                row /= 10;
            }

            sum += row;

            while ((col / 10) != 0)
            {
                sum += col % 10;
                col /= 10;
            }

            sum += col;

            if (sum > i)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}
