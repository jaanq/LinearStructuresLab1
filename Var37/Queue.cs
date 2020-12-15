using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var37
{
    class Queue
    {
        int[] storage; // 0 <=> null <=> None <=> non-init <=> пусто
        int head_pos_cur; // Текущая позиция головки
        int head_pos_max; // Максимальная позиция головки
        int size = 0; // Текущее кол-во элементов
        public Queue(int n)
        {
            storage = new int[n];
            for(int i=0;i<n;i++) { storage[i] = 0; } // Заполняем пустыми значениями
            head_pos_max = n - 1;
            head_pos_cur = n; // При обращении к головке используется "-1" => ставим текущую на ='n'
        }

        public void AddLast(int item) // Добавить в конец очереди
        {
            if (head_pos_cur == 0 & storage[0] == 0) // Если мы в конце очереди и конец пустой
            { // Без этого условия можно было бы изменять конец заполненной очереди
                storage[head_pos_cur-1] = item;
                size++;
            }
            if (head_pos_cur != 0)
            {
                storage[head_pos_cur-1] = item;
                head_pos_cur--;
                size++; 
            }
        }
        public int GetFirst() // Забрать из начала очереди
        {
            int toReturn = storage[head_pos_max]; // Макс, тк очередь двигается к правому краю
            
            // Сдвиг на 1 вправо всех других элементов и головки
            for (int i=head_pos_max; i > 0; i--)
            {
                storage[i] = storage[i - 1];
                if (i < (head_pos_max+1 - size)+1)
                {
                    storage[i] = 0;
                }
                if (i == 1) { storage[0] = 0; }
            }
            // Очередь полностью сдвинулась на 1 вправо, т.е. [0] пусто
            size--;
            head_pos_cur++;
            return toReturn;
        }
        public int Peek() // Нужно, чтобы соответстсвовать АТД
        { // Возвращает первого из очереди без удаления
            return storage[head_pos_max];
        }
        public int Length() { return head_pos_max+1; } // Возвращает длину
        public void Show() // Выводит
        {
            Console.Write("Size: "+size+"   ");
            foreach (int x in storage)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
        public int[] ToArray() // Возвращает массив
        {
            return storage;
        }
        public bool isEmpty() // Метод првоерки на пустоту. Для соответствия АТД.
        {
            foreach (int x in storage)
            {
                if (x != 0) { return false; } // Нули = пустота
                return true;
            }
            return true;
        }




        // Sorting block
        static internal void StartQSort(ref Queue ex) // Метод для запуска сортировки
        {
            QSort(ex.ToArray());
        }
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        static internal void QSort( int[] array, int firstIndex = 0, int lastIndex = -1)
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
        static internal void Clear(Queue q) // Инкапсулированное обнуление для соответствия АТД
        {
            q.storage = new int[0];
            q.head_pos_cur = 0;
            q.head_pos_max = 0;
            q.size = 0;
        }
    }
}
