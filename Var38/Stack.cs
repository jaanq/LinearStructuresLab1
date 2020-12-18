using System;

namespace Var38
{
    class Stack
    {
        int[] storage; // 0 <=> null <=> None <=> non-init <=> пусто
        int slot; // Индекс головы стэка, куда и будет добавлять/убираться элемент.
        int size = 0; // Текущее кол-во элементов
        public Stack(int n) // Добавление по-одному очень медленно для кучи чисел, каждый раз двигать надо
        {
            storage = new int[n];
            for (int i = 0; i < n; i++) { storage[i] = 0; } // Заполняем пустыми значениями
            slot = n - 1;
        }
        public Stack(int[] array) // Добавление по-одному очень медленно для кучи чисел, каждый раз двигать надо
        {
            storage = array;
            slot = array.Length - 1;
        }

        public void Push(int item) // Метод добавления элемента в голову
        {
            if (size != Length()) // Если есть свободное место
            {   // Сдвиг на 1 влево чтобы в голову вставить элемент
                for (int i = 0; i < Length()-1; i++) // Цикл вперёд
                {
                    storage[i] = storage[i + 1]; // Текущий равен следующему, сдвиг на 1 влево => голова освобождается
                }
                storage[slot] = item; // Присваиваем опустевшей голове новое значение
            }
        }
        public int Pop() // Метод удаления с головы
        {
            int toReturn = storage[slot]; // Макс, тк стэк двигается к правому краю

            // Сдвиг на 1 вправо , чтобы заполнить пустоту от элемента, который ушёл с головы
            for (int i = slot; i > 0; i--) // Цикл назад
            {
                storage[i] = storage[i - 1]; // Текущий равен предыдущему (сдвиг на 1 вправо)
                if (i == 1) { storage[0] = 0; } // Дошли до конца -> обнулить нулевой индекс, отдельно
            }                                     // т.к. обращаемся в цикле к [i-1] и может ошибка быть
            // Очередь полностью сдвинулась на 1 влево, т.е. [max] пусто
            size--; // Попнули один => сайз уменьшился
            //head_pos_cur++;
            return toReturn;
        }
        public int Peek() // Вернёт голову без удаления. Для удовлетворения АТД.
        {
            return storage[slot];
        }
        public int Length() { return slot+1; } // Возвратит общий возможный размер стэка.
        public void Show() // Выведет стэк в строку
        {
            foreach (int x in storage){
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
        public int[] ToArray() // Вернёт сам массив
        {
            return storage;
        }
        public bool isEmpty() // Метод проверки на пустоту. Для соответствия АТД.
        {
            foreach (int x in storage)
            {
                if (x != 0) { return false; } // Нули = пустота. Есть не ноль = не пустой
                return true;
            }
            return true;
        }
        public int Get(int index)
        {
            throw new NotImplementedException();
        }

        public int Set(int index)
        {
            throw new NotImplementedException();
        }



        // Sorting block
        static internal void StartQSort(ref Stack st) // Метод для запуска сортировки
        {
            QSort(st.ToArray()); // ____!!!!! Можно конечно сразу в мэине вызывать эту строку, но я помню
                                 // ____!!!!! что препод говорил не использовать костыльные переводы в массив,
                                 // ____!!!!! поэтому конвертация в массив инкапсулируется внутри самого класса стэка
                                 // ____!!!!! и никаких конвертаций в мэине не происходит
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
