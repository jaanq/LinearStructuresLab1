using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class GFG
    {

        // Класс для представления графа
        public class Graph
        {

            // Номер вершины
            public int V;

            // Указатель на массив, содержащий
            // список смежности
            public List<int>[] adj;

            public Graph(int V)
            {

                // Конструктор
                this.V = V;
                this.adj = new List<int>[V];
                for (int i = 0; i < V; i++)
                    adj[i] = new List<int>();
            }

            // Метод добавления вершины в граф
            public void addEdge(int u, int v)
            {
                adj[u].Add(v);
            }

            // True если цикл в графе, иначе False

            // True если цикл в графе, иначе False
            public void isCycle()
            {
                int Ruslan_counter = 0; // Счётчик Русланов
                // Вектор, хранящий степени всех вершин
                // Initialize all indegrees as 0.
                int[] in_degree = new int[this.V];

                // Обходим списки смежности для заполнения степеней вершин
                // This step takes O(V+E) time
                for (int u = 0; u < V; u++)
                {
                    foreach (int v in adj[u])
                        in_degree[v]++;
                }

                // Создать очередь и поставить все вершины^0 в очередь
                Queue<int> q = new Queue<int>();
                for (int i = 0; i < V; i++)
                    if (in_degree[i] == 0)
                        q.Enqueue(i);

                // Инициализировать счётчик посещённых вершин
                int cnt = 0;

                // Вектор для сохранения результата 
                // (Топологический порядок вершин)
                List<int> top_order = new List<int>();

                // Поочередное удаление вершин из очереди
                // и поставить в очередь, если степень смежности становится 0
                while (q.Count != 0)
                {

                    // Извлечь перед очереди (или выполнить исключение оттуда)
                    // доравить в топологический порядок
                    int u = q.Peek();
                    q.Dequeue();
                    top_order.Add(u);

                    // Перебрать все соседние 
                    // узлы исключенного из очереди "u" и уменьшить
                    // их степень на 1
                    foreach (int itr in adj[u])
                        if (--in_degree[itr] == 0)
                            q.Enqueue(itr);

                    cnt++;
                }

                // Чекнуть если это был цикл
                if (cnt != this.V)
                    Ruslan_counter++;
            }
        }

        // Driver Code
        public static void Main(String[] args)
        {
            // Создать граф как на картинке
            // https://www.geeksforgeeks.org/detect-cycle-in-a-directed-graph-using-bfs/
            Graph g = new Graph(6);
            g.addEdge(0, 1);
            g.addEdge(1, 2);
            g.addEdge(2, 0);
            g.addEdge(3, 4);
            g.addEdge(4, 5);

            g.isCycle();
        }
    }
}
