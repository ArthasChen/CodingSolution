using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q12_StringPathInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[3][] { new char[] { 'a', 'b', 'c' }, new char[] { 'd', 'e', 'f' }, new char[] { 'g', 'h', 'i' } };
            string word = "abc";

            Solution s = new Solution();
            bool r = s.Exist(board, "abc");// t
            bool r1 = s.Exist(board, "aaa");// f
            bool r2 = s.Exist(board, "bcf");// t
            bool r3 = s.Exist(board, "efi");// t
            bool r4 = s.Exist(board, "ifc");// t
            bool r5 = s.Exist(board, "deb");// t
            bool r6 = s.Exist(board, "bbb");// f

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 自己写的第一版
    /// </summary>
    public class Solution
    {
        public bool Exist(char[][] board, string word)
        {
            if (board == null || board.Length <= 0 || word == null || word == string.Empty)
            {
                return false;
            }

            bool isExist = false;

            int rows = board.Length;
            int cols = board[0].Length;
            int curentLength = 0;
            bool[,] visited = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    isExist = isExistCore(board, row, col, rows, cols, curentLength, word, visited);

                    if (isExist)
                    {
                        return isExist;
                    }
                }
            }

            return isExist;
        }

        private bool isExistCore(char[][] board, int row, int col, int rows, int cols, int curentLength, string word, bool[,] visited)
        {
            if (curentLength == word.Length)
            {
                return true;
            }

            if (row < 0 || row >= rows || col < 0 || col >= cols || visited[row, col] == true)
            {
                return false;
            }

            bool res = false;

            if (board[row][col] == word[curentLength])
            {
                visited[row, col] = true;
                curentLength++;

                res = isExistCore(board, row, col + 1, rows, cols, curentLength, word, visited) || isExistCore(board, row + 1, col, rows, cols, curentLength, word, visited) ||
                     isExistCore(board, row - 1, col, rows, cols, curentLength, word, visited) || isExistCore(board, row, col - 1, rows, cols, curentLength, word, visited);

                if (!res)
                {
                    visited[row, col] = false;
                }
            }

            return res;
        }
    }
}
