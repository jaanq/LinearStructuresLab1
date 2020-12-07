using System;

namespace Var38
{           // Массив, Стек, Быстрая сортировка Хоару (c медианным (pivot) элемнтом)
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack(5);
            stack.Push(1);
            stack.Push(10);
            stack.Push(22);
            stack.Push(2);
            stack.Push(5);
            stack.Push(100);
            stack.Show();
            Stack.QSort(stack.ToArray());
            stack.Show();
        }
    }
}
