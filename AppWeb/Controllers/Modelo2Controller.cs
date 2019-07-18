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
    public class Modelo2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Modelo2
        public ActionResult Index()
        {
            return View(db.Modelo2.ToList());
        }

        // GET: Modelo2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo2 modelo2 = db.Modelo2.Find(id);
            if (modelo2 == null)
            {
                return HttpNotFound();
            }
            return View(modelo2);
        }

        // GET: Modelo2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modelo2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Modelo2Id,cargo,cedula")] Modelo2 modelo2)
        {
            if (ModelState.IsValid)
            {
                db.Modelo2.Add(modelo2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelo2);
        }

        // GET: Modelo2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo2 modelo2 = db.Modelo2.Find(id);
            if (modelo2 == null)
            {
                return HttpNotFound();
            }
            return View(modelo2);
        }

        // POST: Modelo2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Modelo2Id,cargo,cedula")] Modelo2 modelo2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelo2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelo2);
        }

        // GET: Modelo2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo2 modelo2 = db.Modelo2.Find(id);
            if (modelo2 == null)
            {
                return HttpNotFound();
            }
            return View(modelo2);
        }

        // POST: Modelo2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelo2 modelo2 = db.Modelo2.Find(id);
            db.Modelo2.Remove(modelo2);
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
