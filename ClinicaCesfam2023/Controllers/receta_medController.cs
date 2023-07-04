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
    public class receta_medController : Controller
    {
        private CesfamClinicaEntities db = new CesfamClinicaEntities();

        // GET: receta_med
        public ActionResult Index()
        {
            var receta_med = db.receta_med.Include(r => r.paciente).Include(r => r.usuario);
            return View(receta_med.ToList());
        }

        // GET: receta_med/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receta_med receta_med = db.receta_med.Find(id);
            if (receta_med == null)
            {
                return HttpNotFound();
            }
            return View(receta_med);
        }

        // GET: receta_med/Create
        public ActionResult Create()
        {
            ViewBag.paciente_rut_pac = new SelectList(db.paciente, "rut_pac", "nombre");
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user");
            return View();
        }

        // POST: receta_med/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_receta,descripcion,fecha_emi,paciente_rut_pac,usuario_rut_user")] receta_med receta_med)
        {
            if (ModelState.IsValid)
            {
                db.receta_med.Add(receta_med);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.paciente_rut_pac = new SelectList(db.paciente, "rut_pac", "nombre", receta_med.paciente_rut_pac);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", receta_med.usuario_rut_user);
            return View(receta_med);
        }

        // GET: receta_med/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receta_med receta_med = db.receta_med.Find(id);
            if (receta_med == null)
            {
                return HttpNotFound();
            }
            ViewBag.paciente_rut_pac = new SelectList(db.paciente, "rut_pac", "nombre", receta_med.paciente_rut_pac);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", receta_med.usuario_rut_user);
            return View(receta_med);
        }

        // POST: receta_med/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_receta,descripcion,fecha_emi,paciente_rut_pac,usuario_rut_user")] receta_med receta_med)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receta_med).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.paciente_rut_pac = new SelectList(db.paciente, "rut_pac", "nombre", receta_med.paciente_rut_pac);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", receta_med.usuario_rut_user);
            return View(receta_med);
        }

        // GET: receta_med/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receta_med receta_med = db.receta_med.Find(id);
            if (receta_med == null)
            {
                return HttpNotFound();
            }
            return View(receta_med);
        }

        // POST: receta_med/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            receta_med receta_med = db.receta_med.Find(id);
            db.receta_med.Remove(receta_med);
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
