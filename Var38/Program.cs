using System;

namespace Var38
{           // Массив, Стек, Быстрая сортировка Хоару (c медианным (pivot) элемнтом)
    class Program
    {
        static Random rnd = new Random();
        static internal ulong N_op;
        static void Main(string[] args)
        {
            foreach (int N in new int[] { 10 }) // Шаг Nx20, время N*logN
            { // В цикле перебираем разные N и запрашиваем массив такой же длиной, передаём в стэк
                //Stack st = new Stack(RandomArrayWithLength(N)); // Вернёт рандомный массив длины N и отправит в конструтор
                Stack st = new Stack(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }); // Вернёт рандомный массив длины N и отправит в конструтор
                N_op = 0;
                st.Show();
                DateTime before = DateTime.Now; // Запоминается текущее время
                Stack.QsortWithGetSet(ref st); // Старт сортировки 
                st.Show();
                double time = (DateTime.Now - before).TotalMilliseconds; // !Текущее! время минус запомненное
                Console.WriteLine($"N: {N} TotalMilliseconds: {time} N_ops:{N_op}");
            }
        }

        static int[] RandomArrayWithLength(int count)
        {
            int[] array = new int[count]; // Создадим пустой массив нужной длины
            for (int i = 0; i < count; i++) // В цикле прогоним все числа
            {
                array[i] = rnd.Next(1, 5); // По индексу добавляем рандомное число в жтом промежутке
            }
            return array; // Вернём массив
        }
    }
}
