using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        [Test]
        public void TestNegativesNotAllowed()
        {
            try
            {
                var calculator = new Calculator();
                calculator.Add("-5");
                Assert.Fail();
            }
            catch(NegativesNotAllowedException e)
            {
                Assert.IsTrue("negatives not allowed" == e.Message);
            }
        }

        [Test]
        public void TestNegativesNotAllowedWithDelimiterFormatPattern()
        {
            try
            {
                var calculator = new Calculator();
                calculator.Add("//[a]\n1\n2a-5");
                Assert.Fail();
            }
            catch (NegativesNotAllowedException)
            {
            }
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

        [Test]
        public void TestAddThreeNumbers()
        {
            var calculator = new Calculator();
            try
            {
                Assert.IsTrue(1110 == calculator.Add("1000,100,10"));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestAddLotsOfNumbers()
        {
            var calculator = new Calculator();
            try
            {
                var random = new Random();
                var list = new List<int>();
                int total = 0;
                for (int i = 0; i < 100; ++i)
                {
                    var value = random.Next(1, 1000);
                    total += value;
                    list.Add(value);
                }

                var stringValue = list.Select(x => x.ToString()).Aggregate((a, b) => a + "," + b);
                Assert.IsTrue(total == calculator.Add(stringValue));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestDelimiterSequenceCommaNewlineInvalid()
        {
            try
            {
                var calculator = new Calculator();
                calculator.Add("1,\n2");
            }
            catch (InvalidDelimiterSequenceException)
            {

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestDelimiterSequenceNewlineCommaInvalid()
        {
            try
            {
                var calculator = new Calculator();
                calculator.Add("1\n,2");
            }
            catch(InvalidDelimiterSequenceException)
            {

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestNumbersWithNewlineAndCommaValid()
        {
            try
            {
                var calculator = new Calculator();
                calculator.Add("1\n2,3");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestCanUseNewLineAsDelimiters()
        {
            try
            {
                var calculator = new Calculator();
                Assert.IsTrue(6 == calculator.Add("1\n2,3"));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        [Test]
        public void TestCannotUseNewLineAndCommaDelimitersSequentially()
        {
            try
            {
                var calculator = new Calculator();
                calculator.Add("1\n2\n,3");
                Assert.Fail();
            }
            catch (InvalidDelimiterSequenceException)
            {
                
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestCanUseDelimiterFormatPattern()
        {
            try
            {
                var calculator = new Calculator();
                Assert.IsTrue(6 == calculator.Add("//[a]\n1\n2a3"));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestAddIgnoresNumbersGreaterThan1000()
        {
            try
            {
                var calculator = new Calculator();
                Assert.IsTrue(1003 == calculator.Add("1,2,1000,1001"));
                Assert.IsTrue(6 == calculator.Add("//[a]\n2001a1\n2a3"));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestCanUseStringDelimitersWithFormatPattern()
        {
            try
            {
                var calculator = new Calculator();
                Assert.IsTrue(6 == calculator.Add("//[delimiter]\n1\n2delimiter3"));
                Assert.IsTrue(6 == calculator.Add("//[q_7]\n1q_72\n3"));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestCanUseMultipleDelimitersInFormatPattern()
        {
            try
            {
                var calculator = new Calculator();
                Assert.IsTrue(6 == calculator.Add("//[*][%]\n1*2%3"));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestCanUseMultipleVariableLengthDelimitersInFormatPattern()
        {
            try
            {
                var calculator = new Calculator();
                Assert.IsTrue(13 == calculator.Add("//[patt1][%][joe]\n1joe2%3patt17"));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}