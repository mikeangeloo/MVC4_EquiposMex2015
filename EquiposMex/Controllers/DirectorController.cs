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
    public class DirectorController : Controller
    {
        private Equipos_MexicoEntities db = new Equipos_MexicoEntities();

        //
        // GET: /Director/

        public ActionResult Index()
        {
            var director = db.DIRECTOR.Include(d => d.EQUIPO);
            return View(director.ToList());
        }

        //
        // GET: /Director/Details/5

        public ActionResult Details(int id = 0)
        {
            DIRECTOR director = db.DIRECTOR.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        //
        // GET: /Director/Create

        public ActionResult Create()
        {
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBREEQUIPO");
            return View();
        }

        //
        // POST: /Director/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DIRECTOR director)
        {
            if (ModelState.IsValid)
            {
                db.DIRECTOR.Add(director);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBREEQUIPO", director.ID_EQUIPO);
            return View(director);
        }

        //
        // GET: /Director/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DIRECTOR director = db.DIRECTOR.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBREEQUIPO", director.ID_EQUIPO);
            return View(director);
        }

        //
        // POST: /Director/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DIRECTOR director)
        {
            if (ModelState.IsValid)
            {
                db.Entry(director).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBREEQUIPO", director.ID_EQUIPO);
            return View(director);
        }

        //
        // GET: /Director/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DIRECTOR director = db.DIRECTOR.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        //
        // POST: /Director/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIRECTOR director = db.DIRECTOR.Find(id);
            db.DIRECTOR.Remove(director);
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