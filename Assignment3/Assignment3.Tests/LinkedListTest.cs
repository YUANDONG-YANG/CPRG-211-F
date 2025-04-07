using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.exception;
using Assignment3.ProblemDomain;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        private SLL list;
        private User testUser1;
        private User testUser2;
        private User testUser3;

        [SetUp]
        public void Setup()
        {
            list = new SLL();
            testUser1 = new User(1, "John Doe", "john@example.com", "password1");
            testUser2 = new User(2, "Jane Smith", "jane@example.com", "password2");
            testUser3 = new User(3, "Bob Johnson", "bob@example.com", "password3");
        }

        [Test]
        public void TestIsEmpty_NewList_ReturnsTrue()
        {
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestAddFirst_AddsItemToBeginningOfList()
        {
            list.AddFirst(testUser1);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(testUser1, list.GetValue(0));
        }

        [Test]
        public void TestAddLast_AddsItemToEndOfList()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(testUser2, list.GetValue(1));
        }

        [Test]
        public void TestAdd_AddsItemAtSpecificIndex()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            list.Add(testUser3, 1);
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(testUser3, list.GetValue(1));
        }

        [Test]
        public void TestReplace_ReplacesItemAtIndex()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            User replacementUser = new User(4, "Alice Williams", "alice@example.com", "password4");
            list.Replace(replacementUser, 1);
            Assert.AreEqual(replacementUser, list.GetValue(1));
        }

        [Test]
        public void TestRemoveFirst_RemovesFirstItem()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            list.RemoveFirst();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(testUser2, list.GetValue(0));
        }

        [Test]
        public void TestRemoveLast_RemovesLastItem()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            list.RemoveLast();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(testUser1, list.GetValue(0));
        }

        [Test]
        public void TestRemove_RemovesItemAtSpecificIndex()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            list.AddLast(testUser3);
            list.Remove(1);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(testUser3, list.GetValue(1));
        }

        [Test]
        public void TestIndexOf_FindsCorrectIndexOfItem()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            Assert.AreEqual(0, list.IndexOf(testUser1));
            Assert.AreEqual(1, list.IndexOf(testUser2));
            Assert.AreEqual(-1, list.IndexOf(new User(99, "Not", "exist", "here")));
        }

        [Test]
        public void TestContains_ChecksIfItemExists()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            Assert.IsTrue(list.Contains(testUser1));
            Assert.IsFalse(list.Contains(new User(99, "Not", "exist", "here")));
        }

        [Test]
        public void TestClear_EmptiesTheList()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestReverse_ReversesOrderOfNodes()
        {
            list.AddLast(testUser1);
            list.AddLast(testUser2);
            list.AddLast(testUser3);

            list.Reverse();

            Assert.AreEqual(testUser3, list.GetValue(0));
            Assert.AreEqual(testUser2, list.GetValue(1));
            Assert.AreEqual(testUser1, list.GetValue(2));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void TestReverse_SingleOrEmptyList_Remains_Unchanged(int initialCount)
        {
            // Populate list with 0 or 1 user
            for (int i = 0; i < initialCount; i++)
            {
                list.AddLast(testUser1);
            }

            list.Reverse();
            Assert.AreEqual(initialCount, list.Count());
        }

        // Test cases for exception throwing
        [Test]
        public void TestRemoveFirst_EmptyList_ThrowsException()
        {
            Assert.Throws<CannotRemoveException>(() => list.RemoveFirst());
        }

        [Test]
        public void TestRemoveLast_EmptyList_ThrowsException()
        {
            Assert.Throws<CannotRemoveException>(() => list.RemoveLast());
        }

        [Test]
        public void TestAdd_InvalidIndex_ThrowsException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Add(testUser1, -1));
            Assert.Throws<IndexOutOfRangeException>(() => list.Add(testUser1, 1));
        }
    }
}
