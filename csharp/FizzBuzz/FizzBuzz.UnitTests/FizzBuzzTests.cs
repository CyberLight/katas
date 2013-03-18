using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace FizzBuzz.UnitTests
{
    public class FizzBuzzTests
    {
        [Theory, FizzBuzzTestConventions]
        public void SetNumbersDividedOnThreeReturnsCorrectResult(FizzBuzz sut, int count, Generator<int> generator)
        {
            var numbers = generator.Take(count).Where(x => x % 3 == 0 && x % 5 != 0).ToArray();

            var actual = numbers.Select(n => sut.Get(n)).ToList();

            actual.ForEach(result => Assert.Equal("Fizz", result));
        }

        [Theory, FizzBuzzTestConventions]
        public void SetNumbersDividedOnFiveReturnsCorrectResult(FizzBuzz sut, int count, Generator<int> generator)
        {
            var numbers = generator.Take(count).Where(x => x % 5 == 0 && x % 3 != 0).ToArray();

            var actual = numbers.Select(n => sut.Get(n)).ToList();

            actual.ForEach(result => Assert.Equal("Buzz", result));
        }

        [Theory, FizzBuzzTestConventions]
        public void SetNumbersNotDividedOnFiveAndThreeReturnsCorrectResult(FizzBuzz sut, int count, Generator<int> generator)
        {
            var numbers = generator.Take(count).Where(x => x % 5 != 0 && x % 3 != 0).ToArray();

            var actual = numbers.Select(n => sut.Get(n)).ToList();

            var expected = numbers.Select(n => Convert.ToString(n));

            Assert.Equal(expected, actual);
        }
    }
}
