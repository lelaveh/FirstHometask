using System;

namespace ConsoleApp1
{
    public class MyLinkedList<Type>
    {
        private Node<Type> headNode;
        private Node<Type> tailNode;
        private int length;

        public MyLinkedList()
        {
            headNode = null;
            tailNode = null;
            length = 0;
        }

        public void addNode(Node<Type> node)
        {
            if (length == 0)
            {
                headNode = node;
                tailNode = node;
            }
            else
            {
                tailNode.NextNode = node;
                tailNode = node;
            }
            length++;
        }

        public void deleteNode(Node<Type> node)
        {
            if (node.Value.Equals(headNode.Value))
            {
                headNode = headNode.NextNode;
                return;
            }
            
            Node<Type> prevNode = headNode;
            while (!prevNode.NextNode.Value.Equals(node.Value))
            {
                prevNode = prevNode.NextNode;
            }

            if (prevNode.NextNode == tailNode)
            {
                tailNode = prevNode;
                tailNode.NextNode = null;
                return;
            }
            
            prevNode.NextNode = prevNode.NextNode.NextNode;
        }

        public void printList()
        {
            Node<Type> node = headNode;
            while (node.NextNode != null)
            {
                Console.WriteLine(node.Value);
                node = node.NextNode;
            }
            Console.WriteLine(node.Value);
        }

        public void reverse()
        {
            Node<Type> reversedNode = null;
            Node<Type> current = headNode;
            while (current != null) {
                Node<Type> next = current.NextNode;
                current.NextNode = reversedNode;
                reversedNode = current;
                current = next;
            }
            headNode = reversedNode;
        }
    }
    
    public class Node<Type>
    {
        private Node<Type> nextNode = null;
        private Type value;

        public Node(Type value)
        {
            this.value = value;
        }

        public Node<Type> NextNode
        {
            get => nextNode;
            set => nextNode = value;
        }

        public Type Value
        {
            get => value;
            set => this.value = value;
        }

        
    }
}