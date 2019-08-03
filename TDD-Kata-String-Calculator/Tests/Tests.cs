using NUnit.Framework;
using System;
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
            var calculator = new Calculator();
            Assert.IsTrue(10 == calculator.Add("10"));
            Assert.IsTrue(5 == calculator.Add("5"));
            Assert.IsTrue(-5 == calculator.Add("-5"));
        }

        [Test]
        public void TestFailsToAddSingleNumber()
        {
            var calculator = new Calculator();
            try
            {
                Assert.IsTrue(10 == calculator.Add("10b"));
                Assert.IsTrue(10 == calculator.Add("1-0"));
                Assert.Fail();
            }
            catch(Exception)
            {
            }   
        }


        [Test]
        public void TestAddTwoNumbers()
        {
            Assert.Fail();
        }
    }
}