using System;
namespace Var37
{
    class Queue1
    {
        int[] storage; // 0 <=> null <=> None <=> non-init <=> пусто
        int head_pos_cur; // Текущая позиция головки
        int head_pos_max; // Максимальная позиция головки
        int size = 0; // Текущее кол-во элементов
        public Queue1(int n)
        {
            Program.N_op += 11;
            storage = new int[n];
            for (int i = 0; i < n; i++) { storage[i] = 0; Program.N_op += 3; } // Заполняем пустыми значениями
            head_pos_max = n - 1;
            head_pos_cur = n; // При обращении к головке используется "-1" => ставим текущую на ='n'
        }

        public void AddLast(int item) // Добавить в конец очереди
        {
            if (head_pos_cur == 0 & storage[0] == 0) // Если мы в конце очереди и конец пустой
            { // Без этого условия можно было бы изменять конец заполненной очереди
                storage[head_pos_cur - 1] = item;
                size++;
                Program.N_op += 7;
            }
            if (head_pos_cur != 0)
            {
                storage[head_pos_cur - 1] = item;
                head_pos_cur--;
                size++;
                Program.N_op += 6;
            }
        }
        public int GetFirst() // Забрать из начала очереди
        {
            int toReturn = storage[head_pos_max]; // Макс, тк очередь двигается к правому краю
            Program.N_op += 3;
            // Сдвиг на 1 вправо всех других элементов и головки
            for (int i = head_pos_max; i > 0; i--)
            {
                storage[i] = storage[i - 1]; Program.N_op += 3;
                if (i < (head_pos_max + 1 - size) + 1)
                {
                    storage[i] = 0;
                    Program.N_op += 6;
                }
                if (i == 1) { storage[0] = 0; Program.N_op += 3; }
            }
            // Очередь полностью сдвинулась на 1 вправо, т.е. [0] пусто
            Program.N_op += 4;
            size--;
            head_pos_cur++;
            return toReturn;
        }
        public int Peek() // Нужно, чтобы соответстсвовать АТД
        { // Возвращает первого из очереди без удаления
            return storage[head_pos_max];
        }
        public int Length() { return head_pos_max + 1; } // Возвращает длину
        public void Show() // Выводит
        {
            Console.Write("Size: " + size + "   ");
            foreach (int x in storage)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
        public int[] ToArray() // Возвращает массив
        {
            return storage; Program.N_op += 1;
        }
        public bool isEmpty() // Метод проверки на пустоту. Для соответствия АТД.
        {
            foreach (int x in storage)
            {
                if (x != 0) { return false; } // Нули = пустота
                return true;
            }
            return true;
        }




        // Sorting block
        static internal void StartQSort(ref Queue1 ex) // Метод для запуска сортировки
        {
            Program.N_op += 1;
            QSort(ex.ToArray());
        }
        static void Swap(ref int a, ref int b)
        {
            Program.N_op += 5;
            int tmp = a;
            a = b;
            b = tmp;
        }
        static internal void QSort(int[] array, int firstIndex = 0, int lastIndex = -1)
        {
            Program.N_op += 3;
            if (lastIndex < 0)
            {
                Program.N_op += 4;
                lastIndex = array.Length - 1;
            }
            if (firstIndex >= lastIndex)
            {
                Program.N_op += 2;
                return;
            }
            int middleIndex = (lastIndex - firstIndex) / 2 + firstIndex, currentIndex = firstIndex;
            Swap(ref array[firstIndex], ref array[middleIndex]);
            Program.N_op += 9;
            for (int i = firstIndex + 1; i <= lastIndex; ++i)
            {
                if (array[i] <= array[firstIndex])
                {
                    Program.N_op += 9;
                    Swap(ref array[++currentIndex], ref array[i]);
                }
            }
            Program.N_op += 12;
            Swap(ref array[firstIndex], ref array[currentIndex]);
            QSort(array, firstIndex, currentIndex - 1);
            QSort(array, currentIndex + 1, lastIndex);
        }
        static internal void Clear(Queue1 q) // Инкапсулированное обнуление для соответствия АТД
        {
            q.storage = new int[0];
            q.head_pos_cur = 0;
            q.head_pos_max = 0;
            q.size = 0;
        }
    }
}

