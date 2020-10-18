using System;

namespace Var38
{
    class Stack
    {
        int[] storage;
        int length;
        int maxlength;
        public Stack(int n)
        {
            storage = new int[n];
            maxlength = n;
            length = n-1;
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

        public void Sort() { }
    }
}
