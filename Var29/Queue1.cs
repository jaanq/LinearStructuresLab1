using System;
namespace Var29
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
        public int Get(int index)
        {
            Queue1 temporary_q = new Queue1(Length()-1);
            for (int i = 0; i < index; i++)
            {
                temporary_q.AddLast(this.GetFirst());
            }
            int toReturn = this.GetFirst();
            for (int i = 1; i < Length() - index; i++)
            {
                temporary_q.AddLast(this.GetFirst());
            }
            for (int i = 0; i < Length(); i++)
            {
                this.AddLast(temporary_q.GetFirst());
            }
            temporary_q.Clear();
            size--;
            head_pos_cur++;
            return toReturn;
        }
        public void Set(int index, int item)               // Queue 0 1 2 3 4 5 6
        {                                                  // Set(2,9) -> 
            if (size != storage.Length)                    // Queue 1 2 3 4 9 5 6
            {
                size++;
                head_pos_cur--;
                Queue1 temporary_q = new Queue1(Length());
                for (int i = 0; i < index;i++)
                {
                    temporary_q.AddLast(this.GetFirst());
                }
                temporary_q.AddLast(item);
                for (int i = 1; i < Length()-index; i++)
                {
                    temporary_q.AddLast(this.GetFirst());
                }
                for(int i=0; i < Length(); i++)
                {
                    this.AddLast(temporary_q.GetFirst());
                }
                temporary_q.Clear();
            }
        }




        // Sorting block
        static internal void StartQSort(ref Queue1 ex) // Метод для запуска сортировки
        {
            Program.N_op += 1;
            quickSort(ex.ToArray(),0,ex.Length()-1);
        }
        static void Swap(int[] array,
                 int position1,
                 int position2)
        {
            // Swaps elements in an array

            // Copy the first position's element
            int temp = array[position1];

            // Assign to the second element
            array[position1] = array[position2];

            // Assign to the first element
            array[position2] = temp;
            Program.N_op += 10;
        }
        static int partition(int[] arr, int low,
                                int high)
        {
            int pivot = arr[high];
            Program.N_op += 7;
            // Index of smaller element
            int i = (low - 1);
            Program.N_op += 2;
            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller
                // than or equal to pivot
                if (arr[j] <= pivot)
                {
                    i++; // increment index of
                         // smaller element
                    Swap(arr, i, j);
                    Program.N_op += 9;
                }
            }
            Swap(arr, i + 1, high);
            Program.N_op += 2;
            return (i + 1);
        }
        static void quickSort(int[] arr, int low,
                                 int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, 
                arr[p] is now at right place */
                int pi = partition(arr, low, high);
                Program.N_op += 7;
                // Separately sort elements before
                // partition and after partition
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }
        internal void Clear() // Инкапсулированное обнуление для соответствия АТД
        {
            this.storage = new int[0];
            this.head_pos_cur = 0;
            this.head_pos_max = 0;
            this.size = 0;
        }
    }
}

