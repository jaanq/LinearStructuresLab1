using System;

namespace Var38_1
{
    internal class Stack
    {
        int MAX; // Максимум
        int top; // Индекс головы
        public int[] stack; // Само хранилище

        bool IsEmpty() // АТД
        {
            return (top < 0); // Если голова отрицательна, то стэк пуст
        }
        public Stack(int max)
        {
            Program.N_op += 4;
            stack = new int[max];
            top = -1;
            MAX = max;
        }
        internal void Push(int item)
        {
            Program.N_op += 1;
            if (top >= MAX)
            {
                Program.N_op += 3;
                Console.WriteLine("Stack Overflow"); // Обработка переполнения стэка
            }
            else
            {
                Program.N_op += 3;
                stack[++top] = item; // Голова двигается и присваивается значение
            }
        }

        internal int Pop()
        {
            if (top < 0)
            {
                Program.N_op += 3;
                Console.WriteLine("Stack Underflow"); // Обработка пустого стэка
                return 0;
            }
            else
            {
                Program.N_op += 4;
                int value = stack[top--]; // Возврат значения головы, сдвиг головы
                return value;
            }
        }

        internal void Peek() // АТД
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");  // Обработка пустого стэка
                return;
            }
            else
                Console.WriteLine("The topmost element of Stack is : {0}", stack[top]); // Вывод головы
        }
        
        internal int Get(int index) // Возвращает и !!НЕ!! удаляет число из стэка
        {
            int toReturn = -1; // Просто любая цифра, чтобы инициализировать переменную
            Stack tmp_st = new Stack(top+1); // ВРеменное хранилище для перебора
            int top_ = this.top; // Сохраним топ, т.к. при Pop() он будет уменьшаться и ломать цикл
            Program.N_op += 8;
            
            for (int i=0; i < top_+1; i++) // Сначала заполним временное хранилище
            {                              // А только потом будем делать необходимое действие,
                Program.N_op += 5;         // при добавлении из временного в постоянное
                tmp_st.Push(this.Pop());   // Это позволит избежать ошибки с обратной индексацией
            }
            for (int i=0; i < top_+1; i++) // Переносим числа из временного в постоянное хранилище
            {
                Program.N_op += 3;
                if (i == index) // Если это искомые индекс
                {
                    Program.N_op += 3;
                    toReturn = tmp_st.Pop(); // Сохраним число для возврата
                    this.Push(toReturn);    // И добавим в постоянное хранилище
                }
                else
                {
                    Program.N_op += 2;
                    this.Push(tmp_st.Pop()); // ИНАЧЕ: просто добавим в пост хран
                }
            }
            Program.N_op += 1;
            return toReturn; // Вернём запомненное число
        }

        internal void Set(int index, int item)
        {
            Stack tmp_st = new Stack(top+1); // Временное хранилище для перебора
            int top_ = this.top; // Сохраним топ, т.к. при Pop() он будет уменьшаться и ломать цикл
            Program.N_op += 8;
            for (int i=0; i<top_+1; i++)    // Сначала заполним временное хранилище
            {                               // А только потом будем делать необходимое действие,
                Program.N_op += 4;          // при добавлении из временного в постоянное
                tmp_st.Push(this.Pop());    // Это позволит избежать ошибки с обратной индексацией
            }
            for(int i=0; i< top_+1; i++)  // Переносим числа из временного в постоянное хранилище
            {
                Program.N_op += 3;
                if (i == index)  // Если это искомые индекс
                {
                    Program.N_op += 4;
                    int toDelete = tmp_st.Pop(); // Заберём число в неиспользуемую переменную
                    this.Push(item);            // И вместо него добавим в пост хран необходимое число (item)
                }
                else
                {
                    Program.N_op += 2;
                    this.Push(tmp_st.Pop());  // ИНАЧЕ: просто добавим в пост хран
                }
            }
        }

        internal void PrintStack()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            else
            {
                Console.WriteLine("Items in the Stack are :");
                for (int i = 0; i<top+1 ; i++)
                {
                    Console.Write(stack[i]+" ");
                }
                Console.WriteLine();
            }
        }
        static internal void SwapGS(ref Stack st, int ind1, int ind2)
        {
            int val1 = st.Get(ind1); // Запоминаем значение по первому индексу
            int val2 = st.Get(ind2); // Запоминаем значение по второму индексу
            st.Set(ind1, val2); // По первому индексу вставляем второе значение
            st.Set(ind2, val1); // По второму индексу вставляем первое значение
            Program.N_op += 9;
        }
        static internal void QSortGS(ref Stack st, int firstIndex = 0, int lastIndex = -1) // Сортировка абсолютно стандартная
        {
            Program.N_op += 22; // Весь QSortGS кроме if в цикле
            if (lastIndex < 0)
            {
                lastIndex = st.top;
                Program.N_op += 2;
            }
                
            if (firstIndex >= lastIndex)
            {
                Program.N_op += 1;
                return;
            }
            int middleIndex = (lastIndex - firstIndex) / 2 + firstIndex, currentIndex = firstIndex;
            SwapGS(ref st, firstIndex, middleIndex);
            for (int i = firstIndex + 1; i <= lastIndex; ++i)
            {
                Program.N_op += 2;
                if (st.Get(i) <= st.Get(firstIndex))
                {
                    Program.N_op += 3;
                    SwapGS(ref st, ++currentIndex, i);
                }
            }
            SwapGS(ref st, firstIndex, currentIndex);
            QSortGS(ref st, firstIndex, currentIndex - 1);
            QSortGS(ref st, currentIndex + 1, lastIndex);
        }
        //static void Swap(ref int a, ref int b)
        //{
        //    int tmp = a;
        //    a = b;
        //    b = tmp;
        //}
        //static internal void QSort(int[] array, int firstIndex = 0, int lastIndex = -1)
        //{
        //    if (lastIndex < 0)
        //        lastIndex = array.Length - 1;
        //    if (firstIndex >= lastIndex)
        //        return;
        //    int middleIndex = (lastIndex - firstIndex) / 2 + firstIndex, currentIndex = firstIndex;
        //    Swap(ref array[firstIndex], ref array[middleIndex]);
        //    for (int i = firstIndex + 1; i <= lastIndex; ++i)
        //    {
        //        if (array[i] <= array[firstIndex])
        //        {
        //            Swap(ref array[++currentIndex], ref array[i]);
        //        }
        //    }
        //    Swap(ref array[firstIndex], ref array[currentIndex]);
        //    QSort(array, firstIndex, currentIndex - 1); // 0   5   
        //    QSort(array, currentIndex + 1, lastIndex); //       6   10
        //}
    }
}
