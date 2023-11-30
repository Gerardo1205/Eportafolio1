using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eportafolio1.Models;

namespace Eportafolio1.Controllers
{
    public class AcercasController : Controller
    {
        private gmaganaEntities db = new gmaganaEntities();

        // GET: Acercas
        public ActionResult Index()
        {
            return View(db.Acercas.ToList());
        }

        // GET: Acercas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acerca acerca = db.Acercas.Find(id);
            if (acerca == null)
            {
                return HttpNotFound();
            }
            return View(acerca);
        }

        // GET: Acercas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acercas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Acerca1")] Acerca acerca)
        {
            if (ModelState.IsValid)
            {
                db.Acercas.Add(acerca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acerca);
        }

        // GET: Acercas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acerca acerca = db.Acercas.Find(id);
            if (acerca == null)
            {
                return HttpNotFound();
            }
            return View(acerca);
        }

        // POST: Acercas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Acerca1")] Acerca acerca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acerca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acerca);
        }

        // GET: Acercas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acerca acerca = db.Acercas.Find(id);
            if (acerca == null)
            {
                return HttpNotFound();
            }
            return View(acerca);
        }

        // POST: Acercas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acerca acerca = db.Acercas.Find(id);
            db.Acercas.Remove(acerca);
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
