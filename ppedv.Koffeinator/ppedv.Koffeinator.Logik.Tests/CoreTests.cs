using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Koffeinator.Model;
using ppedv.Koffeinator.Model.Contracts;

namespace ppedv.Koffeinator.Logik.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_MachAlleKaffees_null_as_active_maschine_throws_InvalidOperationException()
        {
            var core = new Core();

            Assert.ThrowsException<InvalidOperationException>(() => core.MachAlleKaffees(new List<KaffeeRezept>()));
        }

        [TestMethod]
        public void Core_MachAlleKaffees_null_list_nothing_happens()
        {
            var core = new Core();
            var mock = new Mock<IKaffeemaschine>();
            core.AktiveMaschine = mock.Object;

            Assert.ThrowsException<ArgumentNullException>(() => core.MachAlleKaffees(null));

        }

        [TestMethod]
        public void Core_MachAlleKaffees_empty_list()
        {
            var core = new Core();
            var mock = new Mock<IKaffeemaschine>();
            core.AktiveMaschine = mock.Object;

            core.MachAlleKaffees(new List<KaffeeRezept>());

            mock.Verify(x => x.MachKaffee(It.IsAny<KaffeeRezept>()), Times.Never);

        }

        [TestMethod]
        public void Core_MachAlleKaffees_2_with_more_than_2_kaffee()
        {
            var core = new Core();
            var mock = new Mock<IKaffeemaschine>();
            core.AktiveMaschine = mock.Object;
            var rez = new List<KaffeeRezept>();
            rez.Add(new KaffeeRezept() { Kaffee = 3 });
            rez.Add(new KaffeeRezept() { Kaffee = 3576 });
            rez.Add(new KaffeeRezept() { Kaffee = 1 });
            rez.Add(new KaffeeRezept() { Kaffee = 2 });

            core.MachAlleKaffees(rez);

            mock.Verify(x => x.MachKaffee(It.IsAny<KaffeeRezept>()), Times.Exactly(2));


        }
    }
}
