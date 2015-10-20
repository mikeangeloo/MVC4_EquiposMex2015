using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EquiposMex.Models;

namespace EquiposMex.Controllers
{
    public class PadreController : Controller
    {
        private Equipos_MexicoEntities db = new Equipos_MexicoEntities();

        //
        // GET: /Padre/

        public ActionResult Index()
        {
            return View(db.PADRE.ToList());
        }

        //
        // GET: /Padre/Details/5

        public ActionResult Details(int id = 0)
        {
            PADRE padre = db.PADRE.Find(id);
            if (padre == null)
            {
                return HttpNotFound();
            }
            return View(padre);
        }

        //
        // GET: /Padre/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Padre/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PADRE padre)
        {
            if (ModelState.IsValid)
            {
                db.PADRE.Add(padre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(padre);
        }

        //
        // GET: /Padre/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PADRE padre = db.PADRE.Find(id);
            if (padre == null)
            {
                return HttpNotFound();
            }
            return View(padre);
        }

        //
        // POST: /Padre/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PADRE padre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(padre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(padre);
        }

        //
        // GET: /Padre/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PADRE padre = db.PADRE.Find(id);
            if (padre == null)
            {
                return HttpNotFound();
            }
            return View(padre);
        }

        //
        // POST: /Padre/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PADRE padre = db.PADRE.Find(id);
            db.PADRE.Remove(padre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}