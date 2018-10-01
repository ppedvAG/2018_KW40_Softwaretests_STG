using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Tests_NUnit
{
    [TestFixture]
    public class CalculatorTests_Nunit
    {
        [Test]
        public void Calc_Sum_7_and_19_Results_26()
        {
            var calc = new Calculator();

            int result = calc.Sum(7, 19);

            Assert.AreEqual(26, result);
        }


    }
}
