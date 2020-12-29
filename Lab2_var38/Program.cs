using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_var38
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tr = new BinarySearchTree();
            tr.put(10,10);
            tr.put(5,5);
            tr.put(15,15);
            tr.put(4,4);
            tr.put(6,6);
            tr.preorder();
            tr.inorder();
        }
    }

    class TreeNode
    {
        public TreeNode leftChild = null;
        public TreeNode rightChild = null;
        public TreeNode parent = null;
        public int key;
        public int value;

        public TreeNode(int key, int value,
            TreeNode lc = null, TreeNode rc = null, TreeNode parent = null)
        {
            this.key = key;
            this.value = value;
            this.leftChild = lc;
            this.rightChild = rc;
            this.parent = parent;
        }
        bool hasAnyChildren() 
        {
            return leftChild != null | rightChild != null;
        }
        bool hasBothChildren()
        {
            return leftChild != null & rightChild != null;
        }

        void replaceNodeData(int key, int value, TreeNode lc, TreeNode rc)
        {
            this.key = key;
            this.value = value;
            this.leftChild = lc;
            this.rightChild = rc;
        }
        
        internal void preorder()
        {
            Console.WriteLine(this.key);
            if (this.leftChild != null)
            {
                this.leftChild.preorder();
            }
            if (this.rightChild != null)
            {
                this.rightChild.preorder();
            }
        }

        internal void inorder()
        {
            if (this.leftChild != null)
            {
                this.leftChild.inorder();
            }
            Console.WriteLine(this.key);
            if (this.rightChild != null)
            {
                this.rightChild.inorder();
            }
        }
    }

    class BinarySearchTree
    {
        TreeNode root = null;
        int size = 0;
        
        public void put(int key, int val)
        {
            if (this.root != null)
            {
                this._put(key, val, this.root);
            }
            else
            {
                this.root = new TreeNode(key, val);
            }
        }
        void _put(int key, int val, TreeNode currentNode)
        {
            if (key < currentNode.key)
            {
                if (currentNode.leftChild != null)
                {
                    this._put(key, val, currentNode.leftChild);
                }
                else
                {
                    currentNode.leftChild = new TreeNode(key, val, null, null, currentNode);
                }
            }
            else
            {
                if (currentNode.rightChild != null)
                {
                    this._put(key, val, currentNode.rightChild);
                }
                else
                {
                    currentNode.rightChild = new TreeNode(key, val, null, null, currentNode);
                }
            }
        }
        public void preorder()
        {
            Console.WriteLine("Preorder:");
            this.root.preorder();
        }
        public void inorder()
        {
            Console.WriteLine("Inorder:");
            this.root.inorder();
        }

    }
}
