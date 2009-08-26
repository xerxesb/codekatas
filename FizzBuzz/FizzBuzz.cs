using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz 
{
    public class FizzBizzGenerator
    {
        public FizzBizzGenerator()
        {
        }

        public string FizzBuzz() // Default test
        {
            return FizzBuzz(1, 100);
        }

        public string FizzBuzz(int lowerBound, int upperBound)
        {
            var result = "";

            for (var i = lowerBound; i <= upperBound; i++)
            {
                if (i % 15 == 0) result += "FizzBuzz\r\n";
                else if (i % 5 == 0) result += "Buzz\r\n";
                else if (i % 3 == 0) result += "Fizz\r\n";
                else result += i + "\r\n";
            }

            return result.Trim();
        }
    }
}
