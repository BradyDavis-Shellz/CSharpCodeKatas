using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeLineCounter
{
    
    [TestFixture]
    class StringCalculatorTests
    {
        private StringCalculator stringCalculator;
        private Random random;

        [SetUp]
        public void Setup()
        {
            random = new Random();
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void TestThatEmptyStringReturns0()
        {
            var input = "";
            var result = stringCalculator.Calculate(input);

            Assert.Zero(result);
        }

        [Test]
        public void TestThatSingleNumberInputReturnsThatNumber()
        {
            var input = random.Next().ToString();
            var result  = stringCalculator.Calculate(input);

            Assert.AreEqual(int.Parse(input), result);
        }

        [Test]
        public void TestThatMultipleNumbersReturnsTheSum()
        {
            int input1, input2;
            input1 = random.Next();
            input2 = random.Next();

            var result = stringCalculator.Calculate(String.Concat(input1.ToString(), ',', input2.ToString()));

            Assert.AreEqual(input1+input2, result);
        }

        [Test]
        public void TestThatInvalidInputThrowsException()
        {
            var input1 = random.Next();
            var input2 = random.Next().ToString() + "j";

            Assert.Throws(typeof(InvalidDataException),
            delegate { stringCalculator.Calculate(String.Concat(input1.ToString(), ",", input2));  });
        }

        [Test]
        public void TestThatUnknownAmountOfNumbersReturnsSum()
        {
            var numberOfNumbers = random.Next(3, 21);
            var firstInput = random.Next();
            var testTotal = firstInput;
            string input = firstInput.ToString();

            for (int i = 0; i < numberOfNumbers - 1; i++)
            {
                var nextInput = random.Next();
                testTotal += nextInput;
                input = string.Concat(input, ",", nextInput.ToString());

            }

            var result = stringCalculator.Calculate(input);

            Assert.AreEqual(testTotal, result);
        }

        [Test]
        public void TestThatUnknownAmountOfNumbersWithMinusReturnsDifference()
        {
            var numberOfNumbers = random.Next(3, 21);
            var firstInput = random.Next();
            var testTotal = firstInput;
            string input = firstInput.ToString();

            for (int i = 0; i < numberOfNumbers - 1; i++)
            {
                var nextInput = random.Next();
                testTotal -= nextInput;
                input = string.Concat(input, ",", nextInput.ToString());

            }

            var result = stringCalculator.Calculate(input, "-");

            Assert.AreEqual(testTotal, result);
        }

        [Test]
        public void TestThatAcceptsDifferentTypesOfDelimeters()
        {
            var numberOfNumbers = random.Next(3, 21);
            var firstInput = random.Next();
            var testTotal = firstInput;
            string input = firstInput.ToString();

            for (int i = 0; i < numberOfNumbers - 1; i++)
            {
                var nextInput = random.Next();
                testTotal -= nextInput;
                input = string.Concat(input, "&", nextInput.ToString());

            }

            var result = stringCalculator.Calculate(input, "-", '&');

            Assert.AreEqual(testTotal, result);
        }
    }
}
