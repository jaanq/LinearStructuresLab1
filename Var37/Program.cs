using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var37 // Массив, Очередь, Квиксорт
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            foreach (int N in new int[] { 3000, 60000, 120000, 240000, 480000, 9600000 }) {
                Queue qu = new Queue(N);
                AddNrandoms(qu, N);

                DateTime before = DateTime.Now;
                Queue.StartQSort(ref qu);
                double time = (DateTime.Now - before).TotalMilliseconds;

                Console.WriteLine($"N: {N} TotalMilliseconds: {time}");
            }
        }

        static void AddNrandoms(Queue q, int count)
        {
            for (int i = 0; i < count; i++)
            {
                q.AddLast(rnd.Next(1, 1000000));
            }
        }
    }
}
