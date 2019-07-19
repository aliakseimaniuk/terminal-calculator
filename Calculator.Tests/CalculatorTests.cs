using Calculator;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CalculatorTests
    {
        private TerminalCalculator calculator = new TerminalCalculator();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidationOfEmptyStringTest()
        {
            Assert.Throws(typeof(ArgumentException), () =>
            {
                var expression = "  ";
                var r = calculator.Eval(expression);
            });
        }

        [Test]
        public void ValidationOfSpecialCharactersTest()
        {
            Assert.Throws(typeof(ArgumentException), () =>
            {
                var expression = "add(1, 2%)";
                var r = calculator.Eval(expression);
            });
        }

        [TestCase("add(1,2)", ExpectedResult=3)]
        [TestCase("add(1,-1)", ExpectedResult=0)]
        [TestCase("add(-1,-1)", ExpectedResult=-2)]
        [TestCase("add(2147483647,-2147483648)", ExpectedResult = -1)]
        [TestCase("add(2147483647,2147483648)", ExpectedResult = 4294967295)]
        [TestCase("add(0,0)", ExpectedResult = 0)]
        public long AddSimpleTest(string input)
        {
            return calculator.Eval(input);
        }

        [Test]
        public void NestedAddTest()
        {
            var expression = "add(add(add(1,1),2),add(1,add(1,1)))";
            var r = calculator.Eval(expression);

            Assert.AreEqual(r, 7);
        }

        [Test]
        public void MultAndAddTest()
        {
            var expression = "add(1,mult(2,3))";
            var r = calculator.Eval(expression);

            Assert.AreEqual(r, 7);
        }

        [Test]
        public void MultAndAddAndDivTest()
        {
            var expression = "mult(add(2,2),div(9,3))";
            var r = calculator.Eval(expression);

            Assert.AreEqual(r, 12);
        }

        [Test]
        public void MultAndAddAndDivTest2()
        {
            var expression = "add(add(add(div(1,1),1),1),add(1,mult(1,1)))";
            var r = calculator.Eval(expression);

            Assert.AreEqual(r, 5);
        }
    }
}