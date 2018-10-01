using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TDDBank.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(2018, 4, 2, 10, 30, true)]//mo
        [DataRow(2018, 4, 2, 10, 29, false)]//mo
        [DataRow(2018, 4, 2, 19, 0, false)] //mo
        [DataRow(2018, 4, 7, 12, 0, true)] //sa
        [DataRow(2018, 4, 7, 18, 0, false)] //sa
        [DataRow(2018, 4, 8, 12, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.AreEqual(result, oh.IsOpen(dt));
        }


        [TestMethod]
        public void OpeningHourse_IsNowOpen()
        {
            
            using (ShimsContext.Create())
            {
                var oh = new OpeningHours();

                System.IO.Fakes.ShimStreamReader.AllInstances.ReadLine = sr => "wichtiger text";



                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2018, 10, 1, 16, 0, 0);
                Assert.IsTrue(oh.IsNowOpen());

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2018, 10, 1, 19, 0, 0);
                Assert.IsFalse(oh.IsNowOpen());
            }

        }

        [TestMethod]
        public void IsWochenende()
        {
            var oh = new OpeningHours();

            Assert.IsTrue(oh.IsWeekend(new DateTime(2018, 9, 30)));
        }
    }
}
