using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public string Get(int num)
        {
            return (num % 3 == 0) ? "Fizz" : num % 5 == 0 ? "Buzz" : num.ToString();
        }
    }
}
