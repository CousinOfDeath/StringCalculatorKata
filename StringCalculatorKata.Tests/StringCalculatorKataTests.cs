using System;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public sealed class StringCalculatorKataTests
    {
        private StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
        
        [Test]
        public void Add_WhenEmptyString_ReturnDefault()
        {
            var sc = CreateStringCalculator();
            
            var result = sc.Add("");
            
            Assert.AreEqual(0, result);
        }
        
        [Test]
        public void Add_WhenEmptyPositiveNumber_ReturnThatValue()
        {
            var sc = CreateStringCalculator();
            
            var result = sc.Add("1");
            
            Assert.AreEqual(1, result);
        }
        
        [Test]
        public void Add_WhenEmptyPositiveNumbers_ReturnSum()
        {
            var sc = CreateStringCalculator();
            
            var result = sc.Add("1,2");
            
            Assert.AreEqual(3, result);
        }


        [Test]
        public void Add_CustomDelimiter_ReturnsSum()
        {
            var sc = CreateStringCalculator();

            var result = sc.Add("//;\n1;2");
            
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_WithNegativeNumber_ThrowsArgumentException()
        {
            var sc = CreateStringCalculator();

            var e = Assert.Catch<ArgumentException>(() => { sc.Add("-1"); });
            
            StringAssert.Contains("negatives not allowed: -1", e.Message);
        }

        [Test]
        public void Add_WithNegativeNumbers_ThrowsArgumentException()
        {
            var sc = CreateStringCalculator();

            var e = Assert.Catch<ArgumentException>(() => { sc.Add("-1,-2"); });
            
            StringAssert.Contains("negatives not allowed: -1,-2", e.Message);
        }

    }
    
}