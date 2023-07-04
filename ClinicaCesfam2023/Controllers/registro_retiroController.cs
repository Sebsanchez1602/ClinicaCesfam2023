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
    public class registro_retiroController : Controller
    {
        private CesfamClinicaEntities db = new CesfamClinicaEntities();

        // GET: registro_retiro
        public ActionResult Index()
        {
            var registro_retiro = db.registro_retiro.Include(r => r.med_receta).Include(r => r.usuario);
            return View(registro_retiro.ToList());
        }

        // GET: registro_retiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro_retiro registro_retiro = db.registro_retiro.Find(id);
            if (registro_retiro == null)
            {
                return HttpNotFound();
            }
            return View(registro_retiro);
        }

        // GET: registro_retiro/Create
        public ActionResult Create()
        {
            ViewBag.med_receta_id_med_recet = new SelectList(db.med_receta, "id_med_recet", "retiro");
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user");
            return View();
        }

        // POST: registro_retiro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reg,fecha_reg,usuario_rut_user,med_receta_id_med_recet")] registro_retiro registro_retiro)
        {
            if (ModelState.IsValid)
            {
                db.registro_retiro.Add(registro_retiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.med_receta_id_med_recet = new SelectList(db.med_receta, "id_med_recet", "retiro", registro_retiro.med_receta_id_med_recet);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", registro_retiro.usuario_rut_user);
            return View(registro_retiro);
        }

        // GET: registro_retiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro_retiro registro_retiro = db.registro_retiro.Find(id);
            if (registro_retiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.med_receta_id_med_recet = new SelectList(db.med_receta, "id_med_recet", "retiro", registro_retiro.med_receta_id_med_recet);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", registro_retiro.usuario_rut_user);
            return View(registro_retiro);
        }

        // POST: registro_retiro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reg,fecha_reg,usuario_rut_user,med_receta_id_med_recet")] registro_retiro registro_retiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro_retiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.med_receta_id_med_recet = new SelectList(db.med_receta, "id_med_recet", "retiro", registro_retiro.med_receta_id_med_recet);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", registro_retiro.usuario_rut_user);
            return View(registro_retiro);
        }

        // GET: registro_retiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro_retiro registro_retiro = db.registro_retiro.Find(id);
            if (registro_retiro == null)
            {
                return HttpNotFound();
            }
            return View(registro_retiro);
        }

        // POST: registro_retiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registro_retiro registro_retiro = db.registro_retiro.Find(id);
            db.registro_retiro.Remove(registro_retiro);
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
