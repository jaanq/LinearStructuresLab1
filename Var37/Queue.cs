using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var37
{
    class Queue
    {
        int[] storage;
        int length;
        int maxlength;
        public Queue(int n)
        {
            storage = new int[n];
            maxlength = n;
            length = n - 1;
        }

        public void Push(int input)
        {
            storage[length] = input;
            if (length != 0)
            {
                length--;
            }
        }
        public int Pop()
        {
            int toReturn = storage[length];
            //Array.Clear(storage, length,maxlength);
            storage[length] = 0;
            if (length != maxlength - 1)
            {
                length++;
            }
            return toReturn;
        }
        public int Peek()
        {
            return storage[length];
        }
        public int Length() { return maxlength; }
        public void Show()
        {
            foreach (int x in storage)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
        public int[] ToArray()
        {
            return storage;
        }
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static internal void QSort(int[] array, int firstIndex = 0, int lastIndex = -1)
        {
            if (lastIndex < 0)
                lastIndex = array.Length - 1;
            if (firstIndex >= lastIndex)
                return;
            int middleIndex = (lastIndex - firstIndex) / 2 + firstIndex, currentIndex = firstIndex;
            Swap(ref array[firstIndex], ref array[middleIndex]);
            for (int i = firstIndex + 1; i <= lastIndex; ++i)
            {
                if (array[i] <= array[firstIndex])
                {
                    Swap(ref array[++currentIndex], ref array[i]);
                }
            }
            Swap(ref array[firstIndex], ref array[currentIndex]);
            QSort(array, firstIndex, currentIndex - 1);
            QSort(array, currentIndex + 1, lastIndex);
        }
    }
}
