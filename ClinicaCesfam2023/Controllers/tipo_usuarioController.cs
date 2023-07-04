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
    public class tipo_usuarioController : Controller
    {
        private CesfamClinicaEntities db = new CesfamClinicaEntities();

        // GET: tipo_usuario
        public ActionResult Index()
        {
            return View(db.tipo_usuario.ToList());
        }

        // GET: tipo_usuario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            if (tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipo_user,descripcion")] tipo_usuario tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.tipo_usuario.Add(tipo_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            if (tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuario);
        }

        // POST: tipo_usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipo_user,descripcion")] tipo_usuario tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            if (tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuario);
        }

        // POST: tipo_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            db.tipo_usuario.Remove(tipo_usuario);
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
