using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.replaceSpace("I love you");
            Console.WriteLine(s.replaceSpace("I love you"));
            Console.ReadKey();
        }
    }

    class Solution
    {
        public string replaceSpace(string str)
        {
            // write code here
            string output = null;
            string[] strArray = str.Split(' ');
            //for (int i = 0; i < strArray.Length; i++)
            //{
            //    output += strArray[i];
            //}
            output = str.Replace(" ", "%20");

            return output;
        }
    }

    class Solution2
    {
        public string replaceSpace(string str)
        {
            // write code here
            int spaceCount = 0;
            int lengthOld = str.Length;
            int lengthNew = 0;
            int indexOfOld = 0;
            int indexOfNew = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            lengthNew = lengthOld + spaceCount * 2;
            indexOfOld = lengthOld - 1;
            indexOfNew = lengthNew - 1;
            

            while (indexOfOld >= 0 && indexOfNew >= indexOfOld)
            {
                if (str[indexOfOld] ==' ')
                {
                    
                }
            }

            return null;
        }
    }
}
