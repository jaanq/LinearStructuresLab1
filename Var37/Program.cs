using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var37
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue(10);
            q.Push(10);
            q.Push(1);
            q.Push(10);
            q.Push(5);
            q.Push(10);
            q.Push(100);
            q.Push(300);
            q.Push(67);
            q.Push(23);
            q.Push(1);
            q.Show();
            Queue.QSort(q.ToArray());
            q.Show();
            int a = 10;
        }
    }
}
