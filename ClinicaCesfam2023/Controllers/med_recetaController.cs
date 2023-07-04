using System;
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
    public class med_recetaController : Controller
    {
        private CesfamClinicaEntities db = new CesfamClinicaEntities();

        // GET: med_receta
        public ActionResult Index()
        {
            var med_receta = db.med_receta.Include(m => m.medicamento).Include(m => m.receta_med);
            return View(med_receta.ToList());
        }

        // GET: med_receta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            med_receta med_receta = db.med_receta.Find(id);
            if (med_receta == null)
            {
                return HttpNotFound();
            }
            return View(med_receta);
        }

        // GET: med_receta/Create
        public ActionResult Create()
        {
            ViewBag.medicamento_id_med = new SelectList(db.medicamento, "id_med", "nombre");
            ViewBag.receta_med_id_receta = new SelectList(db.receta_med, "id_receta", "descripcion");
            return View();
        }

        // POST: med_receta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_med_recet,receta_med_id_receta,medicamento_id_med,cantidad,retiro")] med_receta med_receta)
        {
            if (ModelState.IsValid)
            {
                db.med_receta.Add(med_receta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicamento_id_med = new SelectList(db.medicamento, "id_med", "nombre", med_receta.medicamento_id_med);
            ViewBag.receta_med_id_receta = new SelectList(db.receta_med, "id_receta", "descripcion", med_receta.receta_med_id_receta);
            return View(med_receta);
        }

        // GET: med_receta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            med_receta med_receta = db.med_receta.Find(id);
            if (med_receta == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicamento_id_med = new SelectList(db.medicamento, "id_med", "nombre", med_receta.medicamento_id_med);
            ViewBag.receta_med_id_receta = new SelectList(db.receta_med, "id_receta", "descripcion", med_receta.receta_med_id_receta);
            return View(med_receta);
        }

        // POST: med_receta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_med_recet,receta_med_id_receta,medicamento_id_med,cantidad,retiro")] med_receta med_receta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(med_receta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicamento_id_med = new SelectList(db.medicamento, "id_med", "nombre", med_receta.medicamento_id_med);
            ViewBag.receta_med_id_receta = new SelectList(db.receta_med, "id_receta", "descripcion", med_receta.receta_med_id_receta);
            return View(med_receta);
        }

        // GET: med_receta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            med_receta med_receta = db.med_receta.Find(id);
            if (med_receta == null)
            {
                return HttpNotFound();
            }
            return View(med_receta);
        }

        // POST: med_receta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            med_receta med_receta = db.med_receta.Find(id);
            db.med_receta.Remove(med_receta);
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
