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
    public class reserva_medController : Controller
    {
        private CesfamClinicaEntities db = new CesfamClinicaEntities();

        // GET: reserva_med
        public ActionResult Index()
        {
            var reserva_med = db.reserva_med.Include(r => r.med_receta).Include(r => r.usuario);
            return View(reserva_med.ToList());
        }

        // GET: reserva_med/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva_med reserva_med = db.reserva_med.Find(id);
            if (reserva_med == null)
            {
                return HttpNotFound();
            }
            return View(reserva_med);
        }

        // GET: reserva_med/Create
        public ActionResult Create()
        {
            ViewBag.med_receta_id_med_recet = new SelectList(db.med_receta, "id_med_recet", "retiro");
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user");
            return View();
        }

        // POST: reserva_med/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reserva,fecha_reserva,usuario_rut_user,med_receta_id_med_recet")] reserva_med reserva_med)
        {
            if (ModelState.IsValid)
            {
                db.reserva_med.Add(reserva_med);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.med_receta_id_med_recet = new SelectList(db.med_receta, "id_med_recet", "retiro", reserva_med.med_receta_id_med_recet);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", reserva_med.usuario_rut_user);
            return View(reserva_med);
        }

        // GET: reserva_med/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva_med reserva_med = db.reserva_med.Find(id);
            if (reserva_med == null)
            {
                return HttpNotFound();
            }
            ViewBag.med_receta_id_med_recet = new SelectList(db.med_receta, "id_med_recet", "retiro", reserva_med.med_receta_id_med_recet);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", reserva_med.usuario_rut_user);
            return View(reserva_med);
        }

        // POST: reserva_med/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reserva,fecha_reserva,usuario_rut_user,med_receta_id_med_recet")] reserva_med reserva_med)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva_med).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.med_receta_id_med_recet = new SelectList(db.med_receta, "id_med_recet", "retiro", reserva_med.med_receta_id_med_recet);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", reserva_med.usuario_rut_user);
            return View(reserva_med);
        }

        // GET: reserva_med/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva_med reserva_med = db.reserva_med.Find(id);
            if (reserva_med == null)
            {
                return HttpNotFound();
            }
            return View(reserva_med);
        }

        // POST: reserva_med/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reserva_med reserva_med = db.reserva_med.Find(id);
            db.reserva_med.Remove(reserva_med);
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
