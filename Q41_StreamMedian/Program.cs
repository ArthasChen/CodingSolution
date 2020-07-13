using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q41_StreamMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class MedianFinder
    {
        private List<int> sortedList;
        private int currentLength;

        /** initialize your data structure here. */
        public MedianFinder()
        {
            sortedList = new List<int>();
            currentLength = 0;
        }

        public void AddNum(int num)
        {
            // 添加 排序
            if (sortedList.Count == 0)
            {
                sortedList.Add(num);
                currentLength++;
                return;
            }

            // 当前长度+1
            sortedList.Add(num);
            currentLength++;

            int currentAddIndex = currentLength - 1;
            int compareIndex = currentAddIndex - 1;

            while (compareIndex >= 0 && num < sortedList[compareIndex])
            {
                Swap(sortedList, compareIndex, currentAddIndex);

                currentAddIndex--;
                compareIndex--;
            }
        }

        private void Swap(List<int> list, int compareIndex, int currentAddIndex)
        {
            int tem = list[currentAddIndex];
            list[currentAddIndex] = list[compareIndex];
            list[compareIndex] = tem;
        }

        private void AddNumWithSorted(List<int> list, int curLength, int num)
        {
            if (list.Count == 0)
            {
                list.Add(num);

                return;
            }

            list.Add(num);
        }

        public double FindMedian()
        {
            int index = 0;
            double re = 0d;

            if (currentLength % 2 == 0)
            {
                //index = currentLength / 2;
                index = currentLength >> 1;
                re = (sortedList[index] + sortedList[index - 1]) / 2d;
            }
            else
            {
                //index = currentLength / 2;
                index = currentLength >> 1;
                re = sortedList[index];
            }

            return re;
        }
    }

    /**
    * Your MedianFinder object will be instantiated and called as such:
    * MedianFinder obj = new MedianFinder();
    * obj.AddNum(num);
    * double param_2 = obj.FindMedian();
    */
}
