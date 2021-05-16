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
    public class ParqueoController : Controller
    {

        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Parqueo
        public ActionResult Index()
        {
            IEnumerable<ConsultarParqueo> parqueos = db.Database.SqlQuery<ConsultarParqueo>("select * from VW_PARQUEOSESTACION");
            ViewBag.Parqueos = parqueos.ToList();
            return View();
        }

        // GET: Parqueo/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<ConsultarParqueo> parqueos = db.Database.SqlQuery<ConsultarParqueo>("select * from VW_PARQUEOSESTACION where idparqueo = " + id);
            ViewBag.Parqueos = parqueos.ToList();
            return View();
        }

        // GET: Parqueo/Create
        public ActionResult Create()
        {
            IEnumerable<EstacionModel> dropdown_estacion = db.Database.SqlQuery<EstacionModel>("select * from ESTACIONES");
            ViewBag.dropdown_estaciones = new SelectList(dropdown_estacion.ToList(), "idestacion", "nombre_estacion");
            return View();
        }

        // POST: Parqueo/Create
        [HttpPost]
        public ActionResult Create(List<ParqueoModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_INSERTPARQUEO] '" + i.nombre_parqueo + "', " + i.idestacion + "");
                }
                return RedirectToAction("/Index");
            }
        }


        // GET: Parqueo/Edit/5
        public ActionResult Edit(int id)
        {
            var idesta = 0;

            IEnumerable<ParqueoModel> parqueos = db.Database.SqlQuery<ParqueoModel>("select * from PARQUEOS where idparqueo = " + id);

            foreach (var x in parqueos)
            {
                idesta = x.idestacion;
                ViewBag.nombreparqueo = x.nombre_parqueo;
                ViewBag.idparqueo = id;
            }

            IEnumerable<EstacionModel> dropdown_estacion = db.Database.SqlQuery<EstacionModel>("select * from ESTACIONES");

            List<SelectListItem> parqueoslist = new List<SelectListItem>();
            foreach (var i in dropdown_estacion)
            {
                if (i.idestacion == idesta)
                {
                    parqueoslist.Add(new SelectListItem() { Text = i.nombre_estacion.ToString(), Value = i.idestacion.ToString(), Selected = true });
                }
                else
                {
                    parqueoslist.Add(new SelectListItem() { Text = i.nombre_estacion.ToString(), Value = i.idestacion.ToString() });
                }
            }
            ViewBag.dropdown_estaciones = parqueoslist;
            return View();
        }

        // POST: Parqueo/Edit/5
        [HttpPost]
        public ActionResult Edit(List<ParqueoModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_UPDATEPARQUEO]" + i.idparqueo + ", '" + i.nombre_parqueo + "', " + i.idestacion + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Parqueo/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<ConsultarParqueo> parqueos = db.Database.SqlQuery<ConsultarParqueo>("select * from VW_PARQUEOSESTACION where idparqueo = " + id);
            ViewBag.Parqueos = parqueos.ToList();
            return View();
        }

        // POST: Parqueo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Database.ExecuteSqlCommand("exec [SP_DELETEPARQUEO] " + id);
                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
