using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Assignment3.Exception;

namespace Assignment3.ProblemDomain
{
    [Serializable]
    [DataContract]
    public class SLL : ILinkedListADT
    {
        // Head of the linked list
        [DataMember]
        private Node head;

        // Number of elements in the list
        [DataMember]
        private int size;

        public SLL()
        {
            head = null;
            size = 0;
        }

        /// <summary>
        /// Checks if the list is empty
        /// </summary>
        /// <returns>True if the list is empty</returns>
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// Clears the list
        /// </summary>
        public void Clear()
        {
            head = null;
            size = 0;
        }

        /// <summary>
        /// Adds to the end of the list
        /// </summary>
        /// <param name="value">Value to append</param>
        public void AddLast(User value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            size++;
        }

        /// <summary>
        /// Prepends (adds to beginning) value to the list
        /// </summary>
        /// <param name="value">Value to store inside element</param>
        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
            size++;
        }

        /// <summary>
        /// Adds a new element at a specific position
        /// </summary>
        /// <param name="value">Value that element is to contain</param>
        /// <param name="index">Index to add new element at</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or past the size of the list</exception>
        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
                throw new IndexOutOfRangeException("Index out of range");

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            Node newNode = new Node(value);
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
            size++;
        }

        /// <summary>
        /// Replaces the value at index
        /// </summary>
        /// <param name="value">Value to replace</param>
        /// <param name="index">Index of element to replace</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list</exception>
        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Index out of range");

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }

        /// <summary>
        /// Gets the number of elements in the list
        /// </summary>
        /// <returns>Size of list (0 meaning empty)</returns>
        public int Count()
        {
            return size;
        }

        /// <summary>
        /// Removes first element from list
        /// </summary>
        /// <exception cref="CannotRemoveException">Thrown if list is empty</exception>
        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new CannotRemoveException("Cannot remove from an empty list");

            head = head.Next;
            size--;
        }

        /// <summary>
        /// Removes last element from list
        /// </summary>
        /// <exception cref="CannotRemoveException">Thrown if list is empty</exception>
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new CannotRemoveException("Cannot remove from an empty list");

            if (size == 1)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            size--;
        }

        /// <summary>
        /// Removes element at index from list, reducing the size
        /// </summary>
        /// <param name="index">Index of element to remove</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list</exception>
        public void Remove(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Index out of range");

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            current.Next = current.Next.Next;
            size--;
        }

        /// <summary>
        /// Gets the value at the specified index
        /// </summary>
        /// <param name="index">Index of element to get</param>
        /// <returns>Value of node at index</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list</exception>
        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Index out of range");

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        /// <summary>
        /// Gets the first index of element containing value
        /// </summary>
        /// <param name="value">Value to find index of</param>
        /// <returns>First of index of node with matching value or -1 if not found</returns>
        public int IndexOf(User value)
        {
            Node current = head;
            for (int i = 0; i < size; i++)
            {
                if (current.Value.Equals(value))
                    return i;
                current = current.Next;
            }
            return -1;
        }

        /// <summary>
        /// Go through nodes and check if one has value
        /// </summary>
        /// <param name="value">Value to find index of</param>
        /// <returns>True if element exists with value</returns>
        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        /// <summary>
        /// Additional functionality: Reverse the list
        /// </summary>
        public void Reverse()
        {
            if (size <= 1) return; // No need to reverse if 0 or 1 element

            Node previous = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                // Store next node
                next = current.Next;

                // Reverse current node's pointer
                current.Next = previous;

                // Move pointers one position ahead
                previous = current;
                current = next;
            }

            // Update head to point to the last node (now first)
            head = previous;
        }
    }
}