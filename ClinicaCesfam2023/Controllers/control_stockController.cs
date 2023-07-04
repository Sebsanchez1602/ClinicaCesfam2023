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
    public class control_stockController : Controller
    {
        private CesfamClinicaEntities db = new CesfamClinicaEntities();

        // GET: control_stock
        public ActionResult Index()
        {
            var control_stock = db.control_stock.Include(c => c.medicamento).Include(c => c.usuario);
            return View(control_stock.ToList());
        }

        // GET: control_stock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            control_stock control_stock = db.control_stock.Find(id);
            if (control_stock == null)
            {
                return HttpNotFound();
            }
            return View(control_stock);
        }

        // GET: control_stock/Create
        public ActionResult Create()
        {
            ViewBag.medicamento_id_med = new SelectList(db.medicamento, "id_med", "nombre");
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user");
            return View();
        }

        // POST: control_stock/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_caduca_med,medicamento_id_med,descripcion,cantidad,fecha_control,usuario_rut_user")] control_stock control_stock)
        {
            if (ModelState.IsValid)
            {
                db.control_stock.Add(control_stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicamento_id_med = new SelectList(db.medicamento, "id_med", "nombre", control_stock.medicamento_id_med);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", control_stock.usuario_rut_user);
            return View(control_stock);
        }

        // GET: control_stock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            control_stock control_stock = db.control_stock.Find(id);
            if (control_stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicamento_id_med = new SelectList(db.medicamento, "id_med", "nombre", control_stock.medicamento_id_med);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", control_stock.usuario_rut_user);
            return View(control_stock);
        }

        // POST: control_stock/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_caduca_med,medicamento_id_med,descripcion,cantidad,fecha_control,usuario_rut_user")] control_stock control_stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(control_stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicamento_id_med = new SelectList(db.medicamento, "id_med", "nombre", control_stock.medicamento_id_med);
            ViewBag.usuario_rut_user = new SelectList(db.usuario, "rut_user", "tipo_usuario_tipo_user", control_stock.usuario_rut_user);
            return View(control_stock);
        }

        // GET: control_stock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            control_stock control_stock = db.control_stock.Find(id);
            if (control_stock == null)
            {
                return HttpNotFound();
            }
            return View(control_stock);
        }

        // POST: control_stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            control_stock control_stock = db.control_stock.Find(id);
            db.control_stock.Remove(control_stock);
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
