using NUnit.Framework;
using TDD_Kata_String_Calculator;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAddEmptyStringReturnsZero()
        {
            var calculator = new Calculator();
            Assert.IsTrue( 0 == calculator.Add(""));
        }

        [Test]
        public void TestAddSingleNumber()
        {
            Assert.Fail();
        }

        [Test]
        public void TestAddTwoNumbers()
        {
            Assert.Fail();
        }
    }
}