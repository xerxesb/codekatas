﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BinaryTree 
{
    [TestFixture]
    public class BinaryTreeTest 
    {
        BinarySearch searchEngine;

        [SetUp]
        public void SetUp()
        {
            searchEngine = new BinarySearch();
        }

        [Test]
        public void DefaultTests()
        {
            Assert.AreEqual(-1, searchEngine.Chop(3, new int[0]));
            Assert.AreEqual(-1, searchEngine.Chop(3, new [] {1}));
            Assert.AreEqual(0, searchEngine.Chop(1, new [] {1}));

            Assert.AreEqual(0, searchEngine.Chop(1, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(1, searchEngine.Chop(3, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(2, searchEngine.Chop(5, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(3, searchEngine.Chop(7, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, searchEngine.Chop(0, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, searchEngine.Chop(2, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, searchEngine.Chop(4, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, searchEngine.Chop(6, new[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, searchEngine.Chop(8, new[] { 1, 3, 5, 7 }));

            Assert.AreEqual(0, searchEngine.Chop(1, new [] {1, 3, 5}));
            Assert.AreEqual(1, searchEngine.Chop(3, new [] {1, 3, 5}));
            Assert.AreEqual(2, searchEngine.Chop(5, new [] {1, 3, 5}));
            Assert.AreEqual(-1, searchEngine.Chop(0, new [] {1, 3, 5}));
            Assert.AreEqual(-1, searchEngine.Chop(2, new [] {1, 3, 5}));
            Assert.AreEqual(-1, searchEngine.Chop(4, new [] {1, 3, 5}));
            Assert.AreEqual(-1, searchEngine.Chop(6, new [] {1, 3, 5}));

            Assert.AreEqual(0, searchEngine.Chop(1, new[] { 1, 3, 5, 7, 9, 11, 13}));
            Assert.AreEqual(1, searchEngine.Chop(3, new[] { 1, 3, 5, 7, 9, 11, 13}));
            Assert.AreEqual(2, searchEngine.Chop(5, new[] { 1, 3, 5, 7, 9, 11, 13}));
            Assert.AreEqual(3, searchEngine.Chop(7, new[] { 1, 3, 5, 7, 9, 11, 13}));
            Assert.AreEqual(4, searchEngine.Chop(9, new[] { 1, 3, 5, 7, 9, 11, 13}));
            Assert.AreEqual(5, searchEngine.Chop(11, new[] { 1, 3, 5, 7, 9, 11, 13}));
            Assert.AreEqual(6, searchEngine.Chop(13, new[] { 1, 3, 5, 7, 9, 11, 13}));
            Assert.AreEqual(-1, searchEngine.Chop(0, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            Assert.AreEqual(-1, searchEngine.Chop(2, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            Assert.AreEqual(-1, searchEngine.Chop(4, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            Assert.AreEqual(-1, searchEngine.Chop(6, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            Assert.AreEqual(-1, searchEngine.Chop(8, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            Assert.AreEqual(-1, searchEngine.Chop(10, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            Assert.AreEqual(-1, searchEngine.Chop(12, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            Assert.AreEqual(-1, searchEngine.Chop(14, new[] { 1, 3, 5, 7, 9, 11, 13 }));

            Assert.AreEqual(0, searchEngine.Chop(1, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(1, searchEngine.Chop(3, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(2, searchEngine.Chop(5, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(3, searchEngine.Chop(7, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(4, searchEngine.Chop(9, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(5, searchEngine.Chop(11, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(6, searchEngine.Chop(13, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(-1, searchEngine.Chop(0, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(-1, searchEngine.Chop(2, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(-1, searchEngine.Chop(4, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(-1, searchEngine.Chop(6, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(-1, searchEngine.Chop(8, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(-1, searchEngine.Chop(10, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(-1, searchEngine.Chop(12, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            Assert.AreEqual(-1, searchEngine.Chop(14, new[] { 1, 3, 5, 7, 9, 11, 13, 15}));
        }

    }
}
