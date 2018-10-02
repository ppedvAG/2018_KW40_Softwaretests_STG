using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Koffeinator.Model;

namespace ppedv.Koffeinator.Data.Jura.Tests
{
    [TestClass]
    public class JuraConfigTests
    {
        [TestMethod]
        public void JuraConfig_ErstelleKaffee_Schwarz()
        {
            var jc = new JuraConfig();
            jc.ErstelleKaffee(new KaffeeRezept() { Kaffee = 50, Kakao = 1, Milch = 1, Zucker = 1 });
        }

        [TestMethod]
        public void JuraConfig_ErstelleKaffee_rezept_null()
        {
            var jc = new JuraConfig();
            Assert.ThrowsException<ArgumentNullException>(() => jc.ErstelleKaffee(null));
        }


        [TestMethod]
        public void JuraConfig_ErstelleKaffee_rezept_wiener_melange()
        {
            var jc = new JuraConfig();
            jc.ErstelleKaffee(new KaffeeRezept()
            {
                Kaffee = 50,
                Milch = 50,
                Zucker = 5,
                Kakao = 10,
                Löffel = true
            });
        }
    }
}
