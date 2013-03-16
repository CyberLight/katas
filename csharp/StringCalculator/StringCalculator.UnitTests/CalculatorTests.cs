using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;
using StringCalculator;
using Ploeh.AutoFixture;

namespace StringCalculator.UnitTests
{
    public class CalculatorTests
    {
        [Theory, CalculatorTestConventions]
        public void AddEmptyReturnsCorrectResult( Calculator sut )
        {
            var numbers = "";
            int actual = sut.Add(numbers);
            Assert.Equal(0, actual);
        }

        [Theory, CalculatorTestConventions]
        public void AddSingleNumberReturnsCorrectResult(Calculator sut, int expected)
        {
            var numbers = expected.ToString();
            var actual = sut.Add(numbers);
            Assert.Equal(expected, actual);
        }

        [Theory, CalculatorTestConventions]
        public void AddTwoNumbersReturnsCorrectResult(Calculator sut, int x, int y)
        {
            var numbers = string.Join(",", x, y);
            var actual = sut.Add(numbers);
            Assert.Equal(x + y, actual);
        }

        [Theory, CalculatorTestConventions]
        public void AddAnyAmountOfNumbersReturnsCorrectResult(Calculator sut, int count, Generator<int> generator)
        {
            var integers = generator.Take(count+2).ToArray();    
            var numbers = string.Join(",", integers);
            
            var actual = sut.Add(numbers);
            var expected = integers.Sum();

            Assert.Equal(expected, actual);
        }

        [Theory, CalculatorTestConventions]
        public void AddWithLineBreakAndCommaAsDelimitersReturnsCorrectResult(Calculator sut, int x, int y, int z)
        {
            var numbers = string.Format("{0}\n{1},{2}", x, y, z);
            var actual = sut.Add(numbers);
            Assert.Equal(x + y + z, actual);
        }

        [Theory, CalculatorTestConventions]
        public void AddLineWithCustomDelimiterReturnsCorrrectResult(Calculator sut, 
                                                                    Generator<char> charGenerator, 
                                                                    Generator<int> intGenerator,
                                                                    int count)
        {
            int dummy;
            var delimiter = charGenerator.Where(c => !int.TryParse(c.ToString(), out dummy) &&
                                                c != '-').First();
            var integers = intGenerator.Take(count).ToArray();
            var numbers = string.Format("//{0}\n{1}", delimiter, string.Join(delimiter.ToString(), integers));

            var actual = sut.Add(numbers);
            var expected = integers.Sum();

            Assert.Equal(expected, actual);
        }

        [Theory, CalculatorTestConventions]
        public void AddLineWithNegativeNumbersThrowsCorrectException(Calculator sut, int x, int y, int z)
        {
            var numbers = string.Join(",", -x, y, -z);

            var e = Assert.Throws<ArgumentOutOfRangeException>(() => sut.Add(numbers));

            Assert.True(e.Message.StartsWith("Negatives not allowed."));
            Assert.Contains((-x).ToString(), e.Message);
            Assert.Contains((-z).ToString(), e.Message);
        }

        [Theory, CalculatorTestConventions]
        public void AddIgnoresBigNumbers(Calculator sut, int smallSeed, int bigSeed)
        {
            var x = Math.Min(smallSeed, 1000);
            var y = bigSeed + 1000;
            var numbers = string.Join(",", x, y);

            var actual = sut.Add(numbers);

            Assert.Equal(x, actual);
        }

        [Theory, CalculatorTestConventions]
        public void AddLineWithCustomDelimiterStringREturnsCorrectResult(Calculator sut,
                                                                         string delimiter,
                                                                         int count,
                                                                         Generator<int> intGenerator)
        {
            var integers = intGenerator.Take(count).ToArray();
            var numbers = string.Format("//[{0}]\n{1}", 
                                        delimiter, 
                                        string.Join(delimiter, integers));

            var expected = integers.Sum();

            var actual = sut.Add(numbers);

            Assert.Equal(expected, actual);
        }

        [Theory, CalculatorTestConventions]
        public void AddLineWithCustomDelimiterStringsReturnsCorrectResult(Calculator sut,
                                                                          string delimiter1,
                                                                          string delimiter2,
                                                                          int x,
                                                                          int y,
                                                                          int z)
        {
            var numbers = string.Format("//[{0}][{1}]\n{2}{0}{3}{1}{4}",
                                        delimiter1,
                                        delimiter2,
                                        x,
                                        y,
                                        z);
            var actual = sut.Add(numbers);
            var expected = x + y + z;

            Assert.Equal(expected, actual);
        }
    }
}
