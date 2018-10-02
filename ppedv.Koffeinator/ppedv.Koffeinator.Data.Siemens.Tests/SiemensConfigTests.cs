using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Koffeinator.Model;

namespace ppedv.Koffeinator.Data.Siemens.Tests
{
    [TestClass]
    public class SiemensConfigTests
    {
        [TestMethod]
        public void SiemensConfig_MachKaffee_Schwarz()
        {
            SiemensConfig sc = new SiemensConfig();
            sc.MachKaffee(new KaffeeRezept() { Kaffee = 50 });
        }

        [TestMethod]
        public void SiemensConfig_MachKaffee_null_as_rezept()
        {
            SiemensConfig sc = new SiemensConfig();
            Assert.ThrowsException<ArgumentNullException>(() => sc.MachKaffee(null));
        }
    }
}
