using System;
using NUnit.Framework;

namespace FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [Test]
        public void Test1()
        {
            CheckFizzBuzzForSingleValue(1, "1");
        }

        [Test]
        public void Test2()
        {
            CheckFizzBuzzForSingleValue(2, "2");
        }

        [Test]
        public void Test3()
        {
            CheckFizzBuzzForSingleValue(3, "Fizz");
        }

        [Test]
        public void Test5()
        {
            CheckFizzBuzzForSingleValue(5, "Buzz");
        }

        [Test]
        public void Test6()
        {
            CheckFizzBuzzForSingleValue(6, "Fizz");
        }

        [Test]
        public void Test10()
        {
            CheckFizzBuzzForSingleValue(10, "Buzz");
        }

        [Test]
        public void Test15()
        {
            CheckFizzBuzzForSingleValue(15, "FizzBuzz");
        }

        [Test]
        public void Test30()
        {
            CheckFizzBuzzForSingleValue(30, "FizzBuzz");
        }

        [Test]
        public void Test1To2()
        {
            CheckFizzBuzzForRange(1, 2, "1\r\n2");
        }

        [Test]
        public void Test1To3()
        {
            CheckFizzBuzzForRange(1, 3, "1\r\n2\r\nFizz");
        }

        [Test]
        public void Test1To5()
        {
            CheckFizzBuzzForRange(1, 5, "1\r\n2\r\nFizz\r\n4\r\nBuzz");
        }

        [Test]
        public void Test10To15()
        {
            CheckFizzBuzzForRange(10, 15, "Buzz\r\n11\r\nFizz\r\n13\r\n14\r\nFizzBuzz");
        }

        // http://fizzbuzz.rubyforge.org/
        [Test]
        public void TestRubyForgeOutput()
        {
            var expected = @"1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
16
17
Fizz
19
Buzz
Fizz
22
23
Fizz
Buzz
26
Fizz
28
29
FizzBuzz
31
32
Fizz
34
Buzz
Fizz
37
38
Fizz
Buzz
41
Fizz
43
44
FizzBuzz
46
47
Fizz
49
Buzz
Fizz
52
53
Fizz
Buzz
56
Fizz
58
59
FizzBuzz
61
62
Fizz
64
Buzz
Fizz
67
68
Fizz
Buzz
71
Fizz
73
74
FizzBuzz
76
77
Fizz
79
Buzz
Fizz
82
83
Fizz
Buzz
86
Fizz
88
89
FizzBuzz
91
92
Fizz
94
Buzz
Fizz
97
98
Fizz
Buzz";
            CheckFizzBuzzForRange(1, 100, expected);
        }


        private void CheckFizzBuzzForSingleValue(int value, string expected)
        {
            CheckFizzBuzzForRange(value, value, expected);
        }

        private void CheckFizzBuzzForRange(int lowerBound, int upperBound, string expected)
        {
            var actual = new FizzBizzGenerator().FizzBuzz(lowerBound, upperBound);
            Assert.AreEqual(expected, actual);
        }
    }
}