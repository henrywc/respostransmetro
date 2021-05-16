using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlackSys.Models;

namespace BlackSys.Controllers
{
    public class PilotoController : Controller
    {
        private BlackSysEntities db = new BlackSysEntities();

        // GET: Piloto
        public ActionResult Index()
        {
            return View(db.PilotoModels.ToList());
        }

        // GET: Piloto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PilotoModel pilotoModel = db.PilotoModels.Find(id);
            if (pilotoModel == null)
            {
                return HttpNotFound();
            }
            return View(pilotoModel);
        }

        // GET: Piloto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Piloto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idpiloto,nombre_piloto,direccion_piloto,correo_piloto,edad_piloto,telefono_piloto,celular_piloto")] PilotoModel pilotoModel)
        {
            if (ModelState.IsValid)
            {
                db.PilotoModels.Add(pilotoModel);
                db.SaveChanges();
                return RedirectToAction("Index", db.PilotoModels.ToList());
            }

            return View(pilotoModel);
        }

        // GET: Piloto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PilotoModel pilotoModel = db.PilotoModels.Find(id);
            if (pilotoModel == null)
            {
                return HttpNotFound();
            }
            return View(pilotoModel);
        }

        // POST: Piloto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idpiloto,nombre_piloto,direccion_piloto,correo_piloto,edad_piloto,telefono_piloto,celular_piloto")] PilotoModel pilotoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pilotoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", db.PilotoModels.ToList());
            }
            return View(pilotoModel);
        }

        // GET: Piloto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PilotoModel pilotoModel = db.PilotoModels.Find(id);
            if (pilotoModel == null)
            {
                return HttpNotFound();
            }
            return View(pilotoModel);
        }

        // POST: Piloto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PilotoModel pilotoModel = db.PilotoModels.Find(id);
            db.PilotoModels.Remove(pilotoModel);
            db.SaveChanges();
            return RedirectToAction("Index", db.PilotoModels.ToList());
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
