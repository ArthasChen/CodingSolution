using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q38_StringPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "aab";
            Solution s = new Solution();
            var v = s.Permutation(input);

            Console.ReadKey();
        }
    }

    public class Solution
    {
        private char[] charOfString;
        private List<string> resultList;
        private HashSet<string> resultSet;

        public string[] Permutation(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return new string[] { "" };
            }

            charOfString = s.ToCharArray();
            resultList = new List<string>();
            resultSet = new HashSet<string>();

            string[] strArray = null;

            PermutationCore(0);

            string[] resultArray = resultList.ToArray();

            return resultArray;
        }

        public void PermutationCore(int index)
        {
            if (index == charOfString.Length)
            {
                if (!resultSet.Contains(new string(charOfString)))
                {
                    resultSet.Add(new string(charOfString));
                    resultList.Add(new string(charOfString));
                    Debug.Print(charOfString.ToString());
                }
                return;
            }

            for (int i = index; i < charOfString.Length; i++)
            {

                Swap(index, i);

                PermutationCore(index + 1);

                Swap(index, i);
            }
        }

        public void Swap(int i, int j)
        {
            char tem = charOfString[i];
            charOfString[i] = charOfString[j];
            charOfString[j] = tem;
        }
    }
}
