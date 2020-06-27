using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q33_SquenceOfBST
{
    class Program
    {
        static void Main(string[] args)
        {
            SolutionNK s = new SolutionNK();
            bool re = s.VerifySquenceOfBST(new[] { 30, 3, 4, 2, 7, 6, 5 });
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public bool VerifyPostorder(int[] postorder)
        {
            if (postorder.Length == 0)
            {
                return true;
            }

            return Verify(postorder);
        }

        public bool Verify(int[] sequence)
        {
            if (sequence.Length == 0)
            {
                return true;
            }

            // get last element ,the element is root of BT
            int root = sequence[sequence.Length - 1];

            int rightArrayLength = 0;
            bool isFindLeftArray = false;
            int arrayLengthWithoutRoot = sequence.Length - 1;

            // find left right array length 
            for (int i = arrayLengthWithoutRoot - 1; i >= 0; i--)
            {
                if (sequence[i] > root)
                {
                    if (!isFindLeftArray)
                    {
                        rightArrayLength++;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    isFindLeftArray = true;
                }
            }

            int leftArrayLength = arrayLengthWithoutRoot - rightArrayLength;
            int[] leftArray = new int[leftArrayLength];
            int[] rightArray = new int[rightArrayLength];

            for (int i = 0; i < leftArrayLength; i++)
            {
                leftArray[i] = sequence[i];
            }
            for (int i = leftArrayLength; i < arrayLengthWithoutRoot; i++)
            {
                rightArray[i - leftArrayLength] = sequence[i];
            }

            bool isLeftIsBST = Verify(leftArray);
            bool isRightIsBST = Verify(rightArray);

            if (isLeftIsBST && isRightIsBST)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class SolutionNK
    {
        public bool VerifySquenceOfBST(int[] sequence)
        {
            if (sequence.Length==0)
            {
                return false;
            }

            return Verify(sequence);
        }

        public bool Verify(int[] sequence)
        {
            if (sequence.Length == 0)
            {
                return true;
            }

            // get last element ,the element is root of BT
            int root = sequence[sequence.Length - 1];

            int rightArrayLength = 0;
            bool isFindLeftArray = false;
            int arrayLengthWithoutRoot = sequence.Length - 1;

            // find left right array length 
            for (int i = arrayLengthWithoutRoot - 1; i >= 0; i--)
            {
                if (sequence[i] > root)
                {
                    if (!isFindLeftArray)
                    {
                        rightArrayLength++;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    isFindLeftArray = true;
                }
            }

            int leftArrayLength = arrayLengthWithoutRoot - rightArrayLength;
            int[] leftArray = new int[leftArrayLength];
            int[] rightArray = new int[rightArrayLength];

            for (int i = 0; i < leftArrayLength; i++)
            {
                leftArray[i] = sequence[i];
            }
            for (int i = leftArrayLength; i < arrayLengthWithoutRoot; i++)
            {
                rightArray[i - leftArrayLength] = sequence[i];
            }

            bool isLeftIsBST = Verify(leftArray);
            bool isRightIsBST = Verify(rightArray);

            if (isLeftIsBST && isRightIsBST)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}