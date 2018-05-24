using System;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorKataTests
    {
        [Test]
        public void Add_WhenEmptyString_ReturnDefault()
        {
            var sc = new StringCalculator();
            
            var result = sc.Add("");
            
            Assert.AreEqual(0, result);
        }
        
        [Test]
        public void Add_WhenEmptyPositiveNumber_ReturnThatValue()
        {
            var sc = new StringCalculator();
            
            var result = sc.Add("1");
            
            Assert.AreEqual(1, result);
        }
        
        [Test]
        public void Add_WhenEmptyPositiveNumbers_ReturnSum()
        {
            var sc = new StringCalculator();
            
            var result = sc.Add("1,2");
            
            Assert.AreEqual(3, result);
        }
    }
    
}