﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eportafolio1.Models;

namespace Eportafolio1.Controllers
{
    public class ProyectoesController : Controller
    {
        private gmaganaEntities db = new gmaganaEntities();

        // GET: Proyectoes
        public ActionResult Index()
        {
            return View(db.Proyectos.ToList());
        }

        // GET: Proyectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectos.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Imagen,Empresa,Fecha")] Proyecto proyecto, HttpPostedFileBase ImagenFile)
        {
            if (ModelState.IsValid)
            {
                //Verifica si se proporciono un archivo de imagen
                if (ImagenFile != null && ImagenFile.ContentLength > 0)
                {
                    //Obtiene el nombre del archivo y el path donde se guardara en la carpeta
                    var filename = Path.GetFileName(ImagenFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/"), filename);

                    //Guarda el archivo en el path especificado
                    ImagenFile.SaveAs(path);

                    //Asigna la URL de la Imagen al campo "Imagen" del modelo
                    proyecto.Imagen = filename;

                }

                db.Proyectos.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proyecto);
        }

        // GET: Proyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectos.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Imagen,Empresa,Fecha")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectos.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyectos.Find(id);
            db.Proyectos.Remove(proyecto);
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
