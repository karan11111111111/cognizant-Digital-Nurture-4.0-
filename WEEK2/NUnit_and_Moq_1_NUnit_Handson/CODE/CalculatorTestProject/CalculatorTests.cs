using NUnit.Framework;
using CalcLibrary;

namespace CalculatorTestProject
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, -1, -2)]
        [TestCase(0, 0, 0)]
        public void Add_WhenCalled_ReturnsCorrectSum(int a, int b, int expectedResult)
        {
            var result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [Ignore("This is a demonstration of [Ignore] attribute.")]
        public void ThisTestIsIgnored()
        {
            Assert.Fail("This test should be ignored.");
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}
