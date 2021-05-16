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
    public class AccesoController : Controller
    {

        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Acceso
        public ActionResult Index()
        {
            IEnumerable<ConsultarAcceso> accesos = db.Database.SqlQuery<ConsultarAcceso>("select * from VW_ACCESOSESTACION");
            ViewBag.Accesos = accesos.ToList();
            return View();
        }

        // GET: Acceso/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<ConsultarAcceso> accesos = db.Database.SqlQuery<ConsultarAcceso>("select * from VW_ACCESOSESTACION where idacceso = " + id);
            ViewBag.Accesos = accesos.ToList();
            return View();
        }

        // GET: Acceso/Create
        public ActionResult Create()
        {
            IEnumerable<EstacionModel> dropdown_estacion = db.Database.SqlQuery<EstacionModel>("select * from ESTACIONES");
            ViewBag.dropdown_estaciones = new SelectList(dropdown_estacion.ToList(), "idestacion", "nombre_estacion");
            return View();
        }

        // POST: Acceso/Create
        [HttpPost]
        public ActionResult Create(List<AccesoModel> datos)
        {

            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_INSERTACCESO] '" + i.nombre_acceso + "', " + i.idestacion + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Acceso/Edit/5
        public ActionResult Edit(int id)
        {
            var idesta = 0;

            IEnumerable<AccesoModel> accesos = db.Database.SqlQuery<AccesoModel>("select * from ACCESOS where idacceso = " + id);

            foreach (var x in accesos)
            {
                idesta = x.idestacion;
                ViewBag.nombreacceso = x.nombre_acceso;
                ViewBag.idacceso = id;
            }

            IEnumerable<EstacionModel> dropdown_estacion = db.Database.SqlQuery<EstacionModel>("select * from ESTACIONES");

            List<SelectListItem> accesoslist = new List<SelectListItem>();
            foreach (var i in dropdown_estacion)
            {
                if (i.idestacion == idesta)
                {
                    accesoslist.Add(new SelectListItem() { Text = i.nombre_estacion.ToString(), Value = i.idestacion.ToString(), Selected = true });
                }
                else
                {
                    accesoslist.Add(new SelectListItem() { Text = i.nombre_estacion.ToString(), Value = i.idestacion.ToString() });
                }
            }
            ViewBag.dropdown_estaciones = accesoslist;
            return View();
        }

        // POST: Acceso/Edit/5
        [HttpPost]
        public ActionResult Edit(List<AccesoModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_UPDATEACCESO]" + i.idacceso + ", '" + i.nombre_acceso + "', " + i.idestacion + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Acceso/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<ConsultarAcceso> accesos = db.Database.SqlQuery<ConsultarAcceso>("select * from VW_ACCESOSESTACION where idacceso = " + id);
            ViewBag.Accesos = accesos.ToList();
            return View();
        }

        // POST: Acceso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                db.Database.ExecuteSqlCommand("exec [SP_DELETEACCESO] " + id);
                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
