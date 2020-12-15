using System;

namespace Var38
{
    class Stack
    {
        int[] storage; // 0 <=> null <=> None <=> non-init <=> пусто
        int head_pos_cur; // Текущая позиция головки
        int head_pos_max; // Максимальная позиция головки
        int size = 0; // Текущее кол-во элементов
        public Stack(int n)
        {
            storage = new int[n];
            for (int i = 0; i < n; i++) { storage[i] = 0; } // Заполняем пустыми значениями
            head_pos_max = n - 1;
            head_pos_cur = n; // При обращении к головке используется "-1" => ставим текущую на ='n'
        }

        public void Push(int item)
        {
            if (head_pos_cur == 0 & storage[0] == 0) // Если мы в конце очереди и конец пустой
            { // Без этого условия можно было бы изменять конец заполненной очереди
                storage[head_pos_cur - 1] = item;
                size++;
            }
            if (head_pos_cur != 0)
            {
                storage[head_pos_cur - 1] = item;
                head_pos_cur--;
                size++;
            }
        }
        public int Pop()
        {
            int toReturn = storage[head_pos_max]; // Макс, тк очередь двигается к правому краю

            storage[head_pos_cur] = 0;
            size--;
            if (head_pos_cur != head_pos_max)
            {
                head_pos_cur++;
            }
            return toReturn;
        }
        public int Peek()
        {
            return storage[head_pos_cur];
        }
        public int Length() { return head_pos_max+1; }
        public void Show()
        {
            foreach (int x in storage){
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
        public int[] ToArray()
        {
            return storage;
        }




        // Sorting block
        static internal void StartQSort(ref Stack st) // Метод для запуска сортировки
        {
            QSort(st.ToArray());
        }
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static internal void QSort(int[] array, int firstIndex = 0, int lastIndex = -1)
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
    }
}
