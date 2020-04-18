using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class BinaryTree
    {
        private BinaryTree parent, left, right;
        private int val;
        private List<int> listForPrint = new List<int>();

        public BinaryTree(int val, BinaryTree parent)
        {
            this.val = val;
            this.parent = parent;
        }

        public void add(int val)
        {
            if (val < (this.val))
            {
                if (this.left == null)
                {
                    this.left = new BinaryTree(val, this);
                }
                else if (this.left != null)
                    this.left.add(val);
            }
            else
            {
                if (this.right == null)
                {
                    this.right = new BinaryTree(val, this);
                }
                else if (this.right != null)
                    this.right.add(val);
            }
        }

        private BinaryTree search(BinaryTree tree, int val)
        {
            if (tree == null) return null;
            switch (val.CompareTo(tree.val))
            {
                case 1: return search(tree.right, val);
                case -1: return search(tree.left, val);
                case 0: return tree;
                default: return null;
            }
        }

        public BinaryTree search(int val)
        {
            return search(this, val);
        }

        public bool remove(int val)
        {
            //Проверяем, существует ли данный узел
            BinaryTree tree = search(val);
            if (tree == null)
            {
                //Если узла не существует, вернем false
                return false;
            }

            BinaryTree curTree;

            //Если удаляем корень
            if (tree == this)
            {
                if (tree.right != null)
                {
                    curTree = tree.right;
                }
                else curTree = tree.left;

                while (curTree.left != null)
                {
                    curTree = curTree.left;
                }

                int temp = curTree.val;
                this.remove(temp);
                tree.val = temp;

                return true;
            }

            //Удаление листьев
            if (tree.left == null && tree.right == null && tree.parent != null)
            {
                if (tree == tree.parent.left)
                    tree.parent.left = null;
                else
                {
                    tree.parent.right = null;
                }

                return true;
            }

            //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if (tree.left != null && tree.right == null)
            {
                //Меняем родителя
                tree.left.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.left;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.left;
                }

                return true;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (tree.left == null && tree.right != null)
            {
                //Меняем родителя
                tree.right.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.right;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.right;
                }

                return true;
            }

            //Удаляем узел, имеющий поддеревья с обеих сторон
            if (tree.right != null && tree.left != null)
            {
                curTree = tree.right;

                while (curTree.left != null)
                {
                    curTree = curTree.left;
                }

                //Если самый левый элемент является первым потомком
                if (curTree.parent == tree)
                {
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = curTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = curTree;
                    }

                    return true;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (curTree.right != null)
                    {
                        curTree.right.parent = curTree.parent;
                    }

                    curTree.parent.left = curTree.right;
                    curTree.right = tree.right;
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    tree.right.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = curTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = curTree;
                    }

                    return true;
                }
            }

            return false;
        }

        private void print(BinaryTree node)
        {
            if (node == null) return;
            print(node.left);
            listForPrint.Add(node.val);
            Console.Write(node + " ");
            if (node.right != null)
                print(node.right);
        }

        public void print()
        {
            listForPrint.Clear();
            print(this);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}
