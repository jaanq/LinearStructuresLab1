using System;

namespace Var38
{           // Массив, Стек, Быстрая сортировка Хоару (c медианным (pivot) элемнтом)
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            foreach (int N in new int[] { 3000, 60000, 120000, 240000, 480000, 9600000 })
            {
                Stack st = new Stack(N);
                AddNrandoms(st, N);

                DateTime before = DateTime.Now;
                Stack.StartQSort(ref st);
                double time = (DateTime.Now - before).TotalMilliseconds;

                Console.WriteLine($"N: {N} TotalMilliseconds: {time}");
            }
        }

        static void AddNrandoms(Stack q, int count)
        {
            for (int i = 0; i < count; i++)
            {
                q.Push(rnd.Next(1, 1000000));
            }
        }
    }
}
