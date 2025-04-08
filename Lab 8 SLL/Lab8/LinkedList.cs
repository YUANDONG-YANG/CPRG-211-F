using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class LinkedList
    {
        // Properties
        public Node Head { get; private set; }
        public int Count { get; private set; }

        // Constructor
        public LinkedList()
        {
            Head = null;
            Count = 0;
        }

        // Add a node to the beginning of the list
        public void AddFirst(string value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            Count++;
        }

        // Add a node to the end of the list
        public void AddLast(string value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            Count++;
        }

        // Remove the first node in the list
        public void RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Cannot remove from an empty list");
            }

            Head = Head.Next;
            Count--;
        }

        // Remove the last node in the list
        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Cannot remove from an empty list");
            }

            if (Head.Next == null)
            {
                Head = null;
                Count--;
                return;
            }

            Node current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
            Count--;
        }

        // Get the value of the node at the specified index
        public string GetValue(int index)
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Cannot get value from an empty list");
            }

            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }
    }
}