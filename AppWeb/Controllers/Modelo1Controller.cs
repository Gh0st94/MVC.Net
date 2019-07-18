using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppWeb.Models;

namespace AppWeb.Controllers
{
    public class Modelo1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Modelo1
        public ActionResult Index()
        {
            ViewBag.Suma = (from m in db.Modelo1 select m.cargo).Sum();
            var modelo1 = db.Modelo1.Include(m => m.Modelo2);
            return View(modelo1.ToList());
        }

        // GET: Modelo1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo1 modelo1 = db.Modelo1.Find(id);
            if (modelo1 == null)
            {
                return HttpNotFound();
            }
            return View(modelo1);
        }

        // GET: Modelo1/Create
        public ActionResult Create()
        {
            ViewBag.Modelo2Id = new SelectList(db.Modelo2, "Modelo2Id", "Modelo2Id");
            return View();
        }

        // POST: Modelo1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Modelo1Id,nombre,cargo,Modelo2Id")] Modelo1 modelo1)
        {
            if (ModelState.IsValid)
            {
                db.Modelo1.Add(modelo1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Modelo2Id = new SelectList(db.Modelo2, "Modelo2Id", "Modelo2Id", modelo1.Modelo2Id);
            return View(modelo1);
        }

        // GET: Modelo1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo1 modelo1 = db.Modelo1.Find(id);
            if (modelo1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Modelo2Id = new SelectList(db.Modelo2, "Modelo2Id", "Modelo2Id", modelo1.Modelo2Id);
            return View(modelo1);
        }

        // POST: Modelo1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Modelo1Id,nombre,cargo,Modelo2Id")] Modelo1 modelo1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelo1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Modelo2Id = new SelectList(db.Modelo2, "Modelo2Id", "Modelo2Id", modelo1.Modelo2Id);
            return View(modelo1);
        }

        // GET: Modelo1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo1 modelo1 = db.Modelo1.Find(id);
            if (modelo1 == null)
            {
                return HttpNotFound();
            }
            return View(modelo1);
        }

        // POST: Modelo1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelo1 modelo1 = db.Modelo1.Find(id);
            db.Modelo1.Remove(modelo1);
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
