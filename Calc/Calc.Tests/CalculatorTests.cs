using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Calculator_Sum_3_and_4_Result_7()
        {
            //Arrange
            var calc = new Calculator();

            //Act
            int result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Calculator_Sum_n7_and_n12_Result_n19()
        {
            //Arrange
            var calc = new Calculator();

            //Act
            int result = calc.Sum(-7, -12);

            //Assert
            Assert.AreEqual(-19, result);
        }

        [TestMethod]
        public void Calculator_Sum_0_and_0_Result_0()
        {
            //Arrange
            var calc = new Calculator();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Exception Tests")]
        public void Calculator_Sum_MAX_and_1_throws_OverflowException()
        {
            //Arrange
            var calc = new Calculator();

            //Act + Assert
            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }


        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(1, 2, 3)]
        [DataRow(-3, -3, -6)]
        [DataRow(-3, 6, 3)]
        [DataRow(10, -20, -10)]
        public void Calculator_Sum(int a, int b, int soll)
        {
            var calc = new Calculator();

            Assert.AreEqual(soll, calc.Sum(a, b));
        }
    }
}