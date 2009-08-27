using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BinaryTree 
{
    public class ShiftedBoundariesBinarySearchTest : Tester<ShiftedBoundariesBinarySearch>
    {
    }

    [TestFixture]
    public class Tester<T> where T: IBinarySearch, new() {
        [Test]
        public void Test0() {
            assert_equal(-1, chop(3, new int[0]));
        }

        [Test]
        public void Test1() {
            assert_equal(-1, chop(3, new[] { 1 }));
        }

        [Test]
        public void Test2() {
            assert_equal(0, chop(1, new[] { 1 }));
        }

        [Test]
        public void Test3() {
            assert_equal(0, chop(1, new[] { 1, 3, 5 }));
        }

        [Test]
        public void Test4() {
            assert_equal(1, chop(3, new[] { 1, 3, 5 }));
        }

        [Test]
        public void Test5() {
            assert_equal(2, chop(5, new[] { 1, 3, 5 }));
        }

        [Test]
        public void Test6() {
            assert_equal(-1, chop(0, new[] { 1, 3, 5 }));
        }

        [Test]
        public void Test7() {
            assert_equal(-1, chop(2, new[] { 1, 3, 5 }));
        }

        [Test]
        public void Test8() {
            assert_equal(-1, chop(4, new[] { 1, 3, 5 }));
        }

        [Test]
        public void Test9() {
            assert_equal(-1, chop(6, new[] { 1, 3, 5 }));
        }

        [Test]
        public void Test10() {
            assert_equal(0, chop(1, new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void Test11() {
            assert_equal(1, chop(3, new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void Test12() {
            assert_equal(2, chop(5, new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void Test13() {
            assert_equal(3, chop(7, new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void Test14() {
            assert_equal(-1, chop(0, new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void Test15() {
            assert_equal(-1, chop(2, new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void Test16() {
            assert_equal(-1, chop(4, new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void Test17() {
            assert_equal(-1, chop(6, new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void Test18() {
            assert_equal(-1, chop(8, new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void TestArrayWithMultipleSearchSegments()
        {
            assert_equal(0, chop(1, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(1, chop(3, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(2, chop(5, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(3, chop(7, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(4, chop(9, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(5, chop(11, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(6, chop(13, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(-1, chop(0, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(-1, chop(2, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(-1, chop(4, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(-1, chop(6, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(-1, chop(8, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(-1, chop(10, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(-1, chop(12, new[] { 1, 3, 5, 7, 9, 11, 13 }));
            assert_equal(-1, chop(14, new[] { 1, 3, 5, 7, 9, 11, 13 }));

            assert_equal(0, chop(1, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(1, chop(3, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(2, chop(5, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(3, chop(7, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(4, chop(9, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(5, chop(11, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(6, chop(13, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(-1, chop(0, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(-1, chop(2, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(-1, chop(4, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(-1, chop(6, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(-1, chop(8, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(-1, chop(10, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(-1, chop(12, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
            assert_equal(-1, chop(14, new[] { 1, 3, 5, 7, 9, 11, 13, 15 }));
        }

        private T _searchEngine;

        [SetUp]
        public void SetUp()
        {
            _searchEngine = new T();
        }

        private int chop(int find, int[] array) {
            return _searchEngine.Chop(find, array);
        }

        private void assert_equal(int expected, int actual) {
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
