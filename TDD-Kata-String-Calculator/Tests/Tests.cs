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
        public void TestFailsToAddSingleValue10b()
        {
            var calculator = new Calculator();
            try
            {
                Assert.IsTrue(10 == calculator.Add("10b"));
                Assert.Fail();
            }
            catch(Exception)
            {
            }
        }

        [Test]
        public void TestFailsToAddSingleValue1_0()
        {
            var calculator = new Calculator();
            try
            {
                Assert.IsTrue(10 == calculator.Add("1_0"));
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }

        [Test]
        public void TestAddTwoNumbers()
        {
            var calculator = new Calculator();
            try
            {
                Assert.IsTrue(4 == calculator.Add("1,3"));
                Assert.IsTrue(2 == calculator.Add("-5,7"));
                Assert.IsTrue(177 == calculator.Add("123,54"));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestCannotAddTwoNumbers1_AND3()
        {
            var calculator = new Calculator();
            try
            {
                Assert.IsTrue(4 == calculator.Add("1_,3"));
                Assert.Fail();
            }
            catch (Exception)
            {   
            }
        }
    }
}