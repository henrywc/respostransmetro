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
    public class MunicipalidadController : Controller
    {
        private BlackSysEntities db = new BlackSysEntities();


        //[Route("Municipalidad")]

        // GET: Municipalidad
        public ActionResult Index()
        {
            return View(db.MunicipalidadModels.ToList());
        }

        // GET: Municipalidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipalidadModel municipalidadModel = db.MunicipalidadModels.Find(id);
            if (municipalidadModel == null)
            {
                return HttpNotFound();
            }
            return View(municipalidadModel);
        }

        // GET: Municipalidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Municipalidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmunicipalidad,nombre_municipalidad")] MunicipalidadModel municipalidadModel)
        {
            if (ModelState.IsValid)
            {
                db.MunicipalidadModels.Add(municipalidadModel);
                db.SaveChanges();
                return View("Index", db.MunicipalidadModels.ToList());
            }

            return View(municipalidadModel);
        }

        // GET: Municipalidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipalidadModel municipalidadModel = db.MunicipalidadModels.Find(id);
            if (municipalidadModel == null)
            {
                return HttpNotFound();
            }
            return View(municipalidadModel);
        }

        // POST: Municipalidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmunicipalidad,nombre_municipalidad")] MunicipalidadModel municipalidadModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipalidadModel).State = EntityState.Modified;
                db.SaveChanges();
                return View("Index", db.MunicipalidadModels.ToList());
            }
            return View(municipalidadModel);
        }

        // GET: Municipalidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipalidadModel municipalidadModel = db.MunicipalidadModels.Find(id);
            if (municipalidadModel == null)
            {
                return HttpNotFound();
            }
            return View(municipalidadModel);
        }

        // POST: Municipalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MunicipalidadModel municipalidadModel = db.MunicipalidadModels.Find(id);
            db.MunicipalidadModels.Remove(municipalidadModel);
            db.SaveChanges();
            return View("Index", db.MunicipalidadModels.ToList());
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
