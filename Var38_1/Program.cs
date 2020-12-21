using System;

namespace Var38_1
{
    class Program
    {
        static internal ulong N_op;
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            foreach (int N in new int[] { 100, 400, 500, 600, 700, 800, 900,1000,10000 })
            {
                Stack st = new Stack(N); // Создаём стэк длины n
                RandomDigitsForStack(st, N); // Заполняем его рандомными числами в количестве N
                N_op = 0;
                DateTime before = DateTime.Now; // Засекаем время начала
                Stack.QSortGS(ref st);
                double time = (DateTime.Now - before).TotalMilliseconds; // Вычисляем колво прошедших мсек
                Console.WriteLine($"N: {N} TotalMilliseconds: {time} N_ops:{N_op}");
            }
        }
        static void RandomDigitsForStack(Stack st, int count)
        {
            for (int i = 0; i < count; i++)
            {
                st.Push(rnd.Next(0,100));
            }
        }
    }
}
