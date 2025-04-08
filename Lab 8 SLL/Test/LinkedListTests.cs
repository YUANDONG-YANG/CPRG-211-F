using System.Collections.Generic;
using Lab8;
namespace Test
{
    [TestFixture]
    public class LinkedListTests
    {
        private Lab8.LinkedList list;
        private readonly string[] names =
        {
            "Joe Blow",
            "Joe Schmoe",
            "John Smith",
            "Jane Doe",
            "Bob Bobberson",
            "Sam Sammerson",
            "Dave Daverson"
        };

        [SetUp]
        public void Setup()
        {
            list = new Lab8.LinkedList();
        }

        [Test]
        public void NewList_IsEmpty()
        {
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
        }

        [Test]
        public void AddFirst_IncreasesCount()
        {
            list.AddFirst(names[0]);
            Assert.AreEqual(1, list.Count);

            list.AddFirst(names[1]);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void AddFirst_AddsNodeToBeginning()
        {
            list.AddFirst(names[0]);
            Assert.AreEqual(names[0], list.Head.Value);

            list.AddFirst(names[1]);
            Assert.AreEqual(names[1], list.Head.Value);
            Assert.AreEqual(names[0], list.Head.Next.Value);
        }

        [Test]
        public void AddLast_IncreasesCount()
        {
            list.AddLast(names[0]);
            Assert.AreEqual(1, list.Count);

            list.AddLast(names[1]);
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void AddLast_AddsNodeToEnd()
        {
            list.AddLast(names[0]);
            Assert.AreEqual(names[0], list.Head.Value);

            list.AddLast(names[1]);
            Assert.AreEqual(names[0], list.Head.Value);
            Assert.AreEqual(names[1], list.Head.Next.Value);
        }

        [Test]
        public void RemoveFirst_DecreasesCount()
        {
            list.AddFirst(names[0]);
            list.AddFirst(names[1]);
            list.RemoveFirst();

            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void RemoveFirst_RemovesFirstNode()
        {
            list.AddFirst(names[0]);
            list.AddFirst(names[1]);
            list.RemoveFirst();

            Assert.AreEqual(names[0], list.Head.Value);
        }

        [Test]
        public void RemoveFirst_ThrowsExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Test]
        public void RemoveLast_DecreasesCount()
        {
            list.AddLast(names[0]);
            list.AddLast(names[1]);
            list.RemoveLast();

            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void RemoveLast_RemovesLastNode()
        {
            list.AddLast(names[0]);
            list.AddLast(names[1]);
            list.RemoveLast();

            Assert.AreEqual(names[0], list.Head.Value);
            Assert.IsNull(list.Head.Next);
        }

        [Test]
        public void RemoveLast_ThrowsExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Test]
        public void GetValue_ReturnsCorrectValue()
        {
            // Add all names to the list
            foreach (string name in names)
            {
                list.AddLast(name);
            }

            // Check each value at its index
            for (int i = 0; i < names.Length; i++)
            {
                Assert.AreEqual(names[i], list.GetValue(i));
            }
        }

        [Test]
        public void GetValue_ThrowsExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => list.GetValue(0));
        }

        [Test]
        public void GetValue_ThrowsExceptionWhenIndexOutOfRange()
        {
            list.AddLast(names[0]);

            Assert.Throws<IndexOutOfRangeException>(() => list.GetValue(-1));
            Assert.Throws<IndexOutOfRangeException>(() => list.GetValue(1));
        }

        [Test]
        public void CompleteWorkflow_Test()
        {
            // Add all names to the beginning
            foreach (string name in names)
            {
                list.AddFirst(name);
            }

            // Check the size
            Assert.AreEqual(names.Length, list.Count);

            // Names should be in reverse order
            Assert.AreEqual(names[names.Length - 1], list.GetValue(0));

            // Remove first and check
            list.RemoveFirst();
            Assert.AreEqual(names.Length - 1, list.Count);
            Assert.AreEqual(names[names.Length - 2], list.GetValue(0));

            // Remove last and check
            list.RemoveLast();
            Assert.AreEqual(names.Length - 2, list.Count);

            // Create a new list with names in original order
            list = new LinkedList();
            foreach (string name in names)
            {
                list.AddLast(name);
            }

            // Check the size and values
            Assert.AreEqual(names.Length, list.Count);
            for (int i = 0; i < names.Length; i++)
            {
                Assert.AreEqual(names[i], list.GetValue(i));
            }
        }
    }
}