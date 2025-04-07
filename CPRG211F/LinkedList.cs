using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211F
{
    public class LinkedList
    {
        public Node Head { get; private set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Count = 0;
        }

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

        public void RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Cannot remove from an empty list");
            }

            Head = Head.Next;
            Count--;
        }

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

        public string GetValue(int index)
        {
            if (Head == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
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
