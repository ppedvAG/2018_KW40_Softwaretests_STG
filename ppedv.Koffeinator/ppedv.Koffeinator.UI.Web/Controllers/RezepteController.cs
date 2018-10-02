using ppedv.Koffeinator.Data.EF;
using ppedv.Koffeinator.Logik;
using ppedv.Koffeinator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ppedv.Koffeinator.UI.Web.Controllers
{
    public class RezepteController : Controller
    {
        Core core = new Core(new EfRepository());
        // GET: Rezepte
        public ActionResult Index()
        {
            return View(core.Repository.GetAll<KaffeeRezept>());
        }

        // GET: Rezepte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rezepte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezepte/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rezepte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rezepte/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rezepte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rezepte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
