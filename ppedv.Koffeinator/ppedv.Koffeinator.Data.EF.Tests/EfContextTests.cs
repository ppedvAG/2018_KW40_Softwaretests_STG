using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Koffeinator.Model;

namespace ppedv.Koffeinator.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_db()
        {
            var con = new EfContext();

            if (con.Database.Exists())
                con.Database.Delete();

            con.Database.Create();

            Assert.IsTrue(con.Database.Exists());

            con.Database.Exists().Should().BeTrue();
        }

        [TestMethod]
        public void EfContext_can_add_Rezept()
        {
            var testRezept = new KaffeeRezept
            {
                Bezeichnung = "Lecker Kaffe!",
                Kaffee = 11,
                Kakao = 22,
                Milch = 33,
                Zucker = 44,
                Löffel = true
            };
            int count;
            using (var con = new EfContext())
            {
                count = con.Rezepte.Count();

                con.Rezepte.Add(testRezept);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                con.Rezepte.Count().Should().Be(count + 1);
                var loaded = con.Rezepte.Find(testRezept.Id);
                loaded.Should().NotBeNull();
                loaded.Kaffee.Should().Be(11);
                loaded.Milch.Should().BeGreaterThan(30);
                loaded.Kakao.Should().BeInRange(20, 30);

            }
        }

        [TestMethod]
        public void EfContext_CRUD_KaffeeRezept()
        {
            var testRezept = new KaffeeRezept
            {
                Bezeichnung = "Lecker Kaffe!",
            };

            //CREATE
            using (var con = new EfContext())
            {
                con.Rezepte.Add(testRezept);
                con.SaveChanges();
            }

            //check CREATE + UPDATE
            using (var con = new EfContext())
            {
                var loaded = con.Rezepte.Find(testRezept.Id);
                loaded.Should().NotBeNull();

                loaded.Bezeichnung = "Sehr leckerer Kaffe!";
                con.SaveChanges();
            }

            //check  UPDATE + DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Rezepte.Find(testRezept.Id);
                loaded.Bezeichnung.Should().Be("Sehr leckerer Kaffe!");

                con.Rezepte.Remove(loaded);
                con.SaveChanges();
            }

            //check   DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Rezepte.Find(testRezept.Id);
                loaded.Should().BeNull();
            }
        }

    }
}
