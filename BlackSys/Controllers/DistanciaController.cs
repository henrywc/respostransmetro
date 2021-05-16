using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackSys.Models;
using System.Web.Mvc;
using BlackSys.Models.Modelos_transmetro;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace BlackSys.Controllers
{
    public class DistanciaController : Controller
    {

        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Distancia
        public ActionResult Index()
        {
            IEnumerable<ConsultarDistancia> distancias = db.Database.SqlQuery<ConsultarDistancia>("select * from VW_DISTANCIASLINEA");
            ViewBag.Distancias = distancias.ToList();
            return View();
        }

        // GET: Distancia/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<ConsultarDistancia> distancias = db.Database.SqlQuery<ConsultarDistancia>("select * from VW_DISTANCIASLINEA where iddistancia = " + id);
            ViewBag.Distancias = distancias.ToList();
            return View();
        }

        // GET: Distancia/Create
        public ActionResult Create()
        {
            IEnumerable<EstacionModel> dropdown_estacion1 = db.Database.SqlQuery<EstacionModel>("select * from ESTACIONES");
            ViewBag.dropdown_estaciones1 = new SelectList(dropdown_estacion1.ToList(), "idestacion", "nombre_estacion");
            IEnumerable<EstacionModel> dropdown_estacion2 = db.Database.SqlQuery<EstacionModel>("select * from ESTACIONES");
            ViewBag.dropdown_estaciones2 = new SelectList(dropdown_estacion2.ToList(), "idestacion", "nombre_estacion");
            IEnumerable<LineaModel> dropdown_linea = db.Database.SqlQuery<LineaModel>("select * from LINEAS");
            ViewBag.dropdown_lineas = new SelectList(dropdown_linea.ToList(), "idlinea", "nombre_linea");
            return View();
        }

        // POST: Distancia/Create
        [HttpPost]
        public ActionResult Create(List<DistanciaModel> datos)
        {

            if (datos is null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_INSERTDISTANCIA] " + i.idorigen + ", " + i.iddestino + ", " + i.distancia + ", " + i.idlinea + "");
                }
                return RedirectToAction("Index");
            }
        }

        // GET: Distancia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Distancia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Distancia/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<ConsultarDistancia> distancias = db.Database.SqlQuery<ConsultarDistancia>("select * from VW_DISTANCIASLINEA where iddistancia = " + id);
            ViewBag.Distancias = distancias.ToList();
            return View();
        }

        // POST: Distancia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                db.Database.ExecuteSqlCommand("exec [SP_DELETEDISTANCIA] " + id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
