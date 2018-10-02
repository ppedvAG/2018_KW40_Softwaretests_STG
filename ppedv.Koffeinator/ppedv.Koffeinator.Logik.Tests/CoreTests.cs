using System;
using System.Collections.Generic;
using System.Linq;
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


        [TestMethod]
        public void Core_GetRezeptMitMeistemKaffee()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<KaffeeRezept>()).Returns(() =>
            {
                var kr1 = new KaffeeRezept() { Kaffee = 6, Bezeichnung = "A1" };
                var kr2 = new KaffeeRezept() { Kaffee = 8, Bezeichnung = "A2" };
                var kr3 = new KaffeeRezept() { Kaffee = 3, Bezeichnung = "A3" };
                return new[] { kr1, kr2, kr3 }.AsQueryable();
            });

            var core = new Core(mock.Object);

            var result = core.GetRezeptMitMeistemKaffee();

            Assert.AreEqual("A2", result.Bezeichnung);
        }
    }
}
