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
            size = array.Length;
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
                size++;
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
        //  1   2   3   4   _5_   6   7           -> head     storage[]
        // [0] [1] [2] [3]  [4]  [5] [6]          -> normal indexing
        // [6] [5] [4] [3]  [2]  [1] [0]          -> stack's indexing
        //public int Get(int index)
        //{
        //    Stack temporary_st = new Stack(Length()-1);
        //    for (int i=0; i<index; i++)
        //    {
        //        temporary_st.Push(   this.Pop()   );
        //    }
        //
        //    int toReturn = this.Pop();
        //    for(int i=0; i < this.Length() - index - 1 ; i++)
        //    {
        //        temporary_st.Push(   this.Pop()   );
        //    }
        //
        //    
        //    for (int i=temporary_st.Length(); i>0; i--)
        //    {
        //        this.Push(   temporary_st.Pop()   );
        //    }
        //
        //    return toReturn;
        //}

        public int GetAlternative(int index)
        {
            Stack temporary_st = new Stack(Length());
            for (int i = 0; i < index; i++)
            {
                temporary_st.Push(this.Pop());
            }

            int toReturn = this.Peek();
            temporary_st.Push(this.Pop());
            for (int i = 0; i < this.Length() - index - 1; i++)
            {
                temporary_st.Push(this.Pop());
            }


            for (int i = temporary_st.Length(); i > 0; i--)
            {
                this.Push(temporary_st.Pop());
            }

            return toReturn;
        }
        public void SetAlternative(int index, int item)
        {
            Stack temporary_st = new Stack(Length());
            for (int i = 0; i < index; i++)
            {
                temporary_st.Push(this.Pop());
            }
            temporary_st.Push(item);
            int todelete = this.Pop();
            for (int i = 0; i < this.Length() - index - 1; i++)
            {
                temporary_st.Push(this.Pop());
            }
            for (int i = temporary_st.Length(); i > 0; i--)
            {
                this.Push(temporary_st.Pop());
            }
        }

        //public void Set(int index, int item)
        //{
        //    if (this.size != this.Length())
        //    {
        //        Stack temporary_st = new Stack(Length());
        //        for (int i=0; i<index; i++)
        //        {
        //            temporary_st.Push(   this.Pop()   );
        //        }
        //        temporary_st.Push(item);
        //        for (int i=0; i<this.Length() - index -1; i++)
        //        {
        //            temporary_st.Push(   this.Pop()   );
        //        }
        //        for (int i = temporary_st.Length(); i > 0; i--)
        //        {
        //            this.Push(temporary_st.Pop());
        //        }
        //    }
        //}

        // Sorting block
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
            QSort(array, firstIndex, currentIndex - 1); // 0   5   
            QSort(array, currentIndex + 1, lastIndex); //       6   10
        }
        
        static internal void QsortWithGetSet(ref Stack st, int firstindex = 0, int lastindex = -1)
        {
            if (lastindex < 0) lastindex = st.Length() - 1;
            if (firstindex >= lastindex) return;
            int middleindex= ( lastindex-firstindex) /2 + firstindex, currentindex = firstindex;
            //Swap(ref st.Get(firstindex), ref st.Get(currentindex));
            // My own swap
            int fi = st.GetAlternative(firstindex);   // Swap on Get/Set
            int mi = st.GetAlternative(middleindex);  // Swap on Get/Set
            int ci;                        // Swap on Get/Set
            st.SetAlternative(firstindex, mi);        // Swap on Get/Set
            st.SetAlternative(middleindex, fi);       // Swap on Get/Set

            for (int i=firstindex +1; i <= lastindex; ++i) {
                if (st.GetAlternative(st.Length() - i) <= st.GetAlternative(st.Length() - firstindex))
                {
                    ci = st.GetAlternative(++currentindex);  // Swap on Get/Set
                    int k = st.GetAlternative(i);            // Swap on Get/Set
                    st.SetAlternative(currentindex, ci);     // Swap on Get/Set
                    st.SetAlternative(i, k);                 // Swap on Get/Set

                }
            }
            fi = st.GetAlternative(firstindex);   // Swap on Get/Set
            ci = st.GetAlternative(currentindex); // Swap on Get/Set  
            st.SetAlternative(firstindex, ci);    // Swap on Get/Set
            st.SetAlternative(currentindex, fi);  // Swap on Get/Set

            QsortWithGetSet(ref st, firstindex, currentindex - 1);
            QsortWithGetSet(ref st, currentindex + 1, lastindex);
        }
    }
}
