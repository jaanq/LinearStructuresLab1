using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_var10
{
    class Program
    { // Бинарное дерево, Список сыновей, А=A\B, А– прямой В – симметричный
        // Из дерева А исключаются узлы, присутствующие в дереве В.
        public static List<int> treeA = new List<int> { };
        public static List<int> treeB = new List<int> { };
        static void Main(string[] args)
        {
            BinarySearchTree bstA = new BinarySearchTree();
            BinarySearchTree bstB = new BinarySearchTree();
            bstA.put(5, 5);
            bstA.put(10, 10);
            bstA.put(3, 3);
            bstA.put(1, 1);
            bstA.put(4, 4);       // Добавление в дерево А
            bstA.put(6, 6);
            bstA.put(11, 11);

            bstB.put(6, 6);
            bstB.put(11, 11);       // Добавление в дерево B
            bstB.put(5, 5);
            bstB.root.toListB();    // Создание списка элементов дерева B


            Console.WriteLine("Дерево A до изменения. Прямой обход:");
            bstA.root.preorder(); // Вывод A в прямом
            Console.WriteLine("\nДерево B. Симметричный обход:");
            bstB.root.inorder(); // Вывод B в симметричном


            foreach (int x in treeB)
            {
                bstA.delete(x);   // Процедура удаления
            }

            Console.WriteLine("\nДерево A после изменений. Прямой обход:");
            bstA.root.preorder();   // Вывод А в прямом

            Console.WriteLine();
        }
    }

    class TreeNode
    {
        public int key;
        public int value;
        public TreeNode rightChild = null;
        public TreeNode leftChild = null;
        public TreeNode parent = null;

        public TreeNode(int key, int value, TreeNode left = null, TreeNode right = null, TreeNode parent = null)
        {
            this.key = key;
            this.value = value;
            this.leftChild = left;
            this.rightChild = right;
            this.parent = parent;
        }

        public bool hasLeftChild() // Имеет левого реб?
        {
            if (leftChild != null)
            {
                return true;
            }
            return false;
        }
        public bool hasRightChild() // Имеет правого реб?
        {
            if (rightChild != null)
            {
                return true;
            }
            return false;
        }
        public bool isLeftChild() // Является левым реб?
        {
            if (this.parent != null & this.parent.leftChild == this) // this.Родитель не нул и левыйреб родителя == this
            {
                return true;
            }
            return false;
        }
        public bool isRightChild() // Является правым реб?
        {
            if (this.parent != null & this.parent.rightChild == this) // this.Родитель не нул и правыйреб родителя == this
            {
                return true;
            }
            return false;
        }
        public bool isRoot() // Является корнем?
        {
            if (this.parent == null) // Нет родителя => корень
            {
                return true;
            }
            return false;
        }
        public bool hasNoChildren() // Не имеет детей?
        {
            if (rightChild == null & leftChild == null)
            {
                return true;
            }
            return false;
        }
        public bool hasAnyChildren() // Имеет хотя бы одного реб?
        {
            if (rightChild != null | leftChild != null) // Или один или другой не нул
            {
                return true;
            }
            return false;
        }
        public bool hasBothChildren() // Имеет обоих детей?
        {
            if (rightChild != null & leftChild != null)
            {
                return true;
            }
            return false;
        }
        public void replaceNodeData(int key, int value, TreeNode left, TreeNode right) // Заменить инфу текущей ноды
        {
            this.key = key;
            this.value = value;
            this.leftChild = left;
            this.rightChild = right;
        }
        public TreeNode findMin() // Поиск минимального в дереве
        {
            TreeNode current = this;
            while (current.hasLeftChild()) // Спускаться влево пока левые ветви существуют
            { // (По определению дерева самый минимум будет в самой левой позиции, макс - правой)
                current = current.leftChild;
            }
            return current;
        }

        public TreeNode findSuccessor() // Найти приемника (буква е, приЕмник)
        {
            TreeNode successor = null;
            if (this.hasRightChild()) // Есть правые реб => найти минимум в его поддереве (ниже него)
            {
                successor = this.rightChild.findMin();
            }
            else
            {
                if (this.parent != null)
                {
                    if (this.isLeftChild())
                    {
                        successor = this.parent;
                    }
                    else
                    {
                        this.parent.rightChild = null;
                        successor = this.parent.findSuccessor();
                        this.parent.rightChild = this;
                    }
                }
            }
            return successor;
        }

        public void spliceOut() // Вырезать ноду
        {
            if (this.hasNoChildren()) // Ситуация 1: у ноды нет детей
            {
                if (this.isLeftChild()) // Я левый ребёнок?
                {
                    this.parent.leftChild = null; // Да -> делаем у родителя левого ребёнка нулом
                }
                else
                {
                    this.parent.rightChild = null; // Нет -> делаем у родителя правого ребёнка нулом
                }
            }
            else if (this.hasAnyChildren()) // Ситуация 2: у ноды есть дети
            {
                if (this.hasLeftChild()) // Есть левый ребёнок?
                {
                    if (this.isLeftChild()) // Да + я сам левый -> теперь родительская ссылка на левого ребёнка будет ссылаться на левого "внука" (картинка 1)
                    {
                        this.parent.leftChild = this.leftChild;
                    }
                    else // Да + я сам правый -> теперь родительская ссылка на правого ребёнка будет ссылаться на левого "внука" (картинка 2)
                    {
                        this.parent.rightChild = this.leftChild;
                    }
                    this.leftChild.parent = this.parent;
                }
                else // (Есть левый ребёнок? -> нет)
                {
                    if (this.isLeftChild()) // Нет + я сам левый -> теперь родительская ссылка на левого ребёнка будет ссылаться на правого "внука"
                    {
                        this.parent.leftChild = this.rightChild;
                    }
                    else // Нет + я сам правый -> теперь родительская ссылка на правого ребёнка будет ссылаться на правого "внука"
                    {
                        this.parent.rightChild = this.rightChild;
                    }
                    this.rightChild.parent = this.parent;
                }
            }
        }

        public void preorder()
        {
            Console.Write(this.key + " ");
            if (this.hasLeftChild())
            {
                this.leftChild.preorder();
            }
            if (this.hasRightChild())
            {
                this.rightChild.preorder();
            }
        }

        public void inorder()
        {
            if (this.hasLeftChild())
            {
                this.leftChild.inorder();
            }
            Console.Write(this.key + " ");
            if (this.hasRightChild())
            {
                this.rightChild.inorder();
            }
        }

        public void toListB() // Прямой обход, но вместо вывода идёт заполнение листа Program.treeB
        {
            Program.treeB.Add(this.key);
            if (this.hasLeftChild())
            {
                this.leftChild.toListB();
            }
            if (this.hasRightChild())
            {
                this.rightChild.toListB();
            }
        }

    }

    class BinarySearchTree
    {
        public TreeNode root = null;
        public int size = 0;

        public void put(int key, int val) // Прямое добавление
        {
            if (this.root == null) // Если нет корня, то сделать добавлемую ноду корнем (Сработает только 1 раз)
            {
                this.root = new TreeNode(key, val);
            }
            else // Если есть корень: рекурсивное добавление
            {
                this._put(key, val,this.root);
            }
            this.size++;
        }

        public void _put(int key, int val, TreeNode currentNode) // Рекурсивное добавление. ((key,val) - инфа о добавляемой ноде.) (currentNode - текущая рассматриваемая нода.)
        {
            if (key < currentNode.key) // Ключ добавляемой ноды меньше ключа текущей ноды -> её нужно добавить в качестве левого ребёнка
            {
                if (currentNode.hasLeftChild()) // Если у текущей ноды уже есть левый ребёнок, рекурсивно вызываем добавл и начинаем рассматривать ситуацию уже относительно него
                {
                    this._put(key, val, currentNode.leftChild);
                }
                else // Если у текущей ноды нет левого ребёнка, то добавляемая нода становится им.
                {
                    currentNode.leftChild = new TreeNode(key, val, parent: currentNode);
                }
            }
            else  // Ключ добавляемой ноды больше ключа текущей ноды -> её нужно добавить в качестве правого ребёнка
            {
                if (currentNode.hasRightChild()) // Если у текущей ноды уже есть правый ребёнок, рекурсивно вызываем добавл и начинаем рассматривать ситуацию уже относительно него
                {
                    this._put(key, val, currentNode.rightChild);
                }
                else // Если у текущей ноды нет правого ребёнка, то добавляемая нода становится им.
                {
                    currentNode.rightChild = new TreeNode(key, val, parent: currentNode);
                }
            }
        }
        
        int? get(int key) // int? - метод можем возвращать целые числа и null. 
        {
            if (this.root != null)
            {
                TreeNode res = this._get(key, this.root);
                if (res != null)
                {
                    return res.value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        TreeNode _get(int key, TreeNode currentNode) // Аналог _put, но для поиска
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (currentNode.key == key)
            {
                return currentNode;
            }
            else if (key < currentNode.key)
            {
                return this._get(key, currentNode.leftChild);
            }
            else
            {
                return this._get(key, currentNode.rightChild);
            }
        }

        public void delete(int key) // удаление !по ключу (циферка, например 7)!
        {
            if (this.size > 1)
            {
                TreeNode nodeToRemove = this._get(key, this.root);
                if (nodeToRemove != null)
                {
                    this.remove(nodeToRemove);
                    this.size--;
                }
            }
            else if (this.size == 1 & this.root.key == key)
            {
                this.root = null;
                this.size--;
            }
        }

        public void remove(TreeNode currentNode) // удаление !по экземпляру класса (айди, например {Lab2_var10.TreeNode$508})!
        {
            if (currentNode.hasNoChildren()) // На сайте
            {
                if (currentNode == currentNode.parent.leftChild)
                {
                    currentNode.parent.leftChild = null;
                }
                else
                {
                    currentNode.parent.rightChild = null;
                }
            }
            else if (currentNode.hasBothChildren())
            {
                TreeNode successor = currentNode.findSuccessor();
                successor.spliceOut();
                currentNode.key = successor.key;
                currentNode.value = successor.value;
            }
            else
            {
                if (currentNode.hasLeftChild()) {
                    if (currentNode.isLeftChild()) {
                        currentNode.leftChild.parent = currentNode.parent;
                        currentNode.parent.leftChild = currentNode.leftChild;
                    }
                    else if (currentNode.isRightChild()) {
                        currentNode.leftChild.parent = currentNode.parent;
                        currentNode.parent.rightChild = currentNode.leftChild;
                    }
                    else {
                        currentNode.replaceNodeData(currentNode.leftChild.key,
                            currentNode.leftChild.value,
                            currentNode.leftChild.leftChild,
                            currentNode.leftChild.rightChild);
                    }
                }
                else
                {
                    if (currentNode.isLeftChild()) {
                        currentNode.rightChild.parent = currentNode.parent;
                        currentNode.parent.leftChild = currentNode.rightChild;
                    }
                    else if (currentNode.isRightChild()) {
                        currentNode.rightChild.parent = currentNode.parent;
                        currentNode.parent.rightChild = currentNode.rightChild;
                    }
                    else {
                        currentNode.replaceNodeData(currentNode.rightChild.key,
                               currentNode.rightChild.value,
                               currentNode.rightChild.leftChild,
                               currentNode.rightChild.rightChild);
                    }
                }
            }
        }
    }
}
