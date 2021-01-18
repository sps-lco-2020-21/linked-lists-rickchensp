using System;
using LinkedListExample.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListExample.Tests
{
    [TestClass]
    public class BasicLinkedListTests
    {
        [TestMethod]
        public void TestCount()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            Assert.AreEqual(3, ill.Count);
        }

        [TestMethod]
        public void TestSum()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            Assert.AreEqual(21, ill.Sum);
        }

        [TestMethod]
        public void TestToStringExplicit()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            Assert.AreEqual("{5, 7, 9}", ill.ToString());
        }

        [TestMethod]
        public void TestDelete()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            
            ill.Delete(7);
            Assert.AreEqual(false, ill.Delete(6));
            Assert.AreEqual(14, ill.Sum);
            Assert.AreEqual(2, ill.Count);
            ill.Delete(5);
            Assert.AreEqual(1, ill.Count);
        }

        [TestMethod]
        public void TestJoin()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            var ill2 = new IntegerLinkedList(6);
            ill2.Append(10);
            ill2.Append(-3);
            ill.Join(ill2);
            Assert.AreEqual(6, ill.Count);
        }


        [TestMethod]
        public void TestRemoveDuplicates()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            ill.Append(7);
            ill.Append(10);
            ill.Append(10);
            ill.Append(7);            
            ill.RemoveDuplicates();
            Assert.AreEqual(2, ill.Count);
            Assert.AreEqual("{5, 9}", ill.ToString());
        }

        [TestMethod]
        public void TestAlternateMerge()
        {
            var ill = new IntegerLinkedList(1);
            ill.Append(2);
            ill.Append(3);
            var ill2 = new IntegerLinkedList(4);
            ill2.Append(5);
            ill2.Append(6);
            ill2.Append(7);
            IntegerLinkedList ill3 = ill.AlternateMerge(ill2);
            Assert.AreEqual("{1, 4, 2, 5, 3, 6, 7}", ill3.ToString());
        }
    }
}
