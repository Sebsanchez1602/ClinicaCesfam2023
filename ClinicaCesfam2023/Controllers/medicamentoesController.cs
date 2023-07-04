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
    public class medicamentoesController : Controller
    {
        private CesfamClinicaEntities db = new CesfamClinicaEntities();

        // GET: medicamentoes
        public ActionResult Index()
        {
            return View(db.medicamento.ToList());
        }

        // GET: medicamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicamento medicamento = db.medicamento.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // GET: medicamentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: medicamentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_med,nombre,descripcion,cantidad,fecha_venc,fabricante,precio")] medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.medicamento.Add(medicamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicamento);
        }

        // GET: medicamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicamento medicamento = db.medicamento.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: medicamentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_med,nombre,descripcion,cantidad,fecha_venc,fabricante,precio")] medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicamento);
        }

        // GET: medicamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicamento medicamento = db.medicamento.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: medicamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            medicamento medicamento = db.medicamento.Find(id);
            db.medicamento.Remove(medicamento);
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
