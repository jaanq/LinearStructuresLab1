using System;

namespace Var38
{           // Массив, Стек, Быстрая сортировка Хоару (c медианным (pivot) элемнтом)
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack(5);
            stack.Push(1);
            stack.Pop();
            Console.WriteLine(stack.Peek());
        }
    }
}
