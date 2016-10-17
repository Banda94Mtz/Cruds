using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crud.Models;

namespace Crud.Controllers
{
    public class rentasController : Controller
    {
        private PeliculasEntities db = new PeliculasEntities();

        // GET: rentas
        public ActionResult Index()
        {
            var renta = db.renta.Include(r => r.clientes).Include(r => r.peliculas);
            return View(renta.ToList());
        }

        // GET: rentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            renta renta = db.renta.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            return View(renta);
        }

        // GET: rentas/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.clientes, "idCliente", "nombres");
            ViewBag.idPeliculas = new SelectList(db.peliculas, "idPeliculas", "titulo");
            return View();
        }

        // POST: rentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRenta,idCliente,idPeliculas,fecha")] renta renta)
        {
            if (ModelState.IsValid)
            {
                db.renta.Add(renta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.clientes, "idCliente", "nombres", renta.idCliente);
            ViewBag.idPeliculas = new SelectList(db.peliculas, "idPeliculas", "titulo", renta.idPeliculas);
            return View(renta);
        }

        // GET: rentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            renta renta = db.renta.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.clientes, "idCliente", "nombres", renta.idCliente);
            ViewBag.idPeliculas = new SelectList(db.peliculas, "idPeliculas", "titulo", renta.idPeliculas);
            return View(renta);
        }

        // POST: rentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRenta,idCliente,idPeliculas,fecha")] renta renta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.clientes, "idCliente", "nombres", renta.idCliente);
            ViewBag.idPeliculas = new SelectList(db.peliculas, "idPeliculas", "titulo", renta.idPeliculas);
            return View(renta);
        }

        // GET: rentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            renta renta = db.renta.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            return View(renta);
        }

        // POST: rentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            renta renta = db.renta.Find(id);
            db.renta.Remove(renta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
