using System;
namespace Var29 // Массив, Очередь, Квиксорт
{
    static internal class Program
    {
        static Random rnd = new Random();
        static internal ulong N_op;
        static void Main(string[] args)
        {
            foreach (int N in new int[] { 3000, 60000, 120000, 240000, 350000, 450000, 700000, 3840000 }) {
                N_op = 0;
                Queue1 qu = new Queue1(N);
                AddNrandoms(qu, N);
                DateTime before = DateTime.Now;
                Queue1.StartQSort(ref qu);
                double time = (DateTime.Now - before).TotalMilliseconds;

                Console.WriteLine($"N: {N}    TotalMilliseconds: {time}    N_ops:{N_op}");
                
            }
        }

        static void AddNrandoms(Queue1 q, int count)
        {
            for (int i = 0; i < count; i++)
            {
                q.AddLast(rnd.Next(1, 100));
            }
        }
    }
}
