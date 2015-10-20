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
    public class JugadorController : Controller
    {
        private Equipos_MexicoEntities db = new Equipos_MexicoEntities();

        //
        // GET: /Jugador/

        public ActionResult Index()
        {
            var jugador = db.JUGADOR.Include(j => j.EQUIPO).Include(j => j.PADRE);
            return View(jugador.ToList());
        }

        //
        // GET: /Jugador/Details/5

        public ActionResult Details(int id = 0)
        {
            JUGADOR jugador = db.JUGADOR.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        //
        // GET: /Jugador/Create

        public ActionResult Create()
        {
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBREEQUIPO");
            ViewBag.ID_PADRE = new SelectList(db.PADRE, "ID_PADRE", "ID_PADRE");
            return View();
        }

        //
        // POST: /Jugador/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JUGADOR jugador)
        {
            if (ModelState.IsValid)
            {
                db.JUGADOR.Add(jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBREEQUIPO", jugador.ID_EQUIPO);
            ViewBag.ID_PADRE = new SelectList(db.PADRE, "ID_PADRE", "APELLIDOSPADRE", jugador.ID_PADRE);
            return View(jugador);
        }

        //
        // GET: /Jugador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            JUGADOR jugador = db.JUGADOR.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBREEQUIPO", jugador.ID_EQUIPO);
            ViewBag.ID_PADRE = new SelectList(db.PADRE, "ID_PADRE", "APELLIDOSPADRE", jugador.ID_PADRE);
            return View(jugador);
        }

        //
        // POST: /Jugador/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JUGADOR jugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EQUIPO = new SelectList(db.EQUIPO, "ID_EQUIPO", "NOMBREEQUIPO", jugador.ID_EQUIPO);
            ViewBag.ID_PADRE = new SelectList(db.PADRE, "ID_PADRE", "APELLIDOSPADRE", jugador.ID_PADRE);
            return View(jugador);
        }

        //
        // GET: /Jugador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            JUGADOR jugador = db.JUGADOR.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        //
        // POST: /Jugador/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JUGADOR jugador = db.JUGADOR.Find(id);
            db.JUGADOR.Remove(jugador);
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