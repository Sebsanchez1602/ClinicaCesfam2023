﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaCesfam2023.Models;


namespace ClinicaCesfam2023.Controllers
{
    public class COMPRAsController : Controller
    {
        private CesfamClinicaEntities db = new CesfamClinicaEntities();





        // GET: COMPRAs
        public ActionResult Index()
        {
            return View(db.COMPRA.ToList());
        }

        // GET: COMPRAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA cOMPRA = db.COMPRA.Find(id);
            if (cOMPRA == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRA);
        }

        // GET: COMPRAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: COMPRAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_compra,total,fecha")] COMPRA cOMPRA)
        {
            if (ModelState.IsValid)
            {
                db.COMPRA.Add(cOMPRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOMPRA);
        }

        // GET: COMPRAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA cOMPRA = db.COMPRA.Find(id);
            if (cOMPRA == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRA);
        }

        // POST: COMPRAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_compra,total,fecha")] COMPRA cOMPRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOMPRA);
        }

        // GET: COMPRAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA cOMPRA = db.COMPRA.Find(id);
            if (cOMPRA == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRA);
        }

        // POST: COMPRAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMPRA cOMPRA = db.COMPRA.Find(id);
            db.COMPRA.Remove(cOMPRA);
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
