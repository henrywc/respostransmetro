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

namespace BlackSys.Controllers.Controladores_transmetro
{
    public class LineaController : Controller
    {

        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Linea
        [Route("Controladores transmetro/LineaController")]
        public ActionResult Index()
        {
            IEnumerable<ConsultarLinea> lineas = db.Database.SqlQuery<ConsultarLinea>("select * from VW_LINEASMUNICIPALIDAD");
            ViewBag.Lineas = lineas.ToList();
            return View();
        }

        // GET: Linea/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<ConsultarLinea> lineas = db.Database.SqlQuery<ConsultarLinea>("select * from VW_LINEASMUNICIPALIDAD where idlinea = " + id);
            ViewBag.Lineas = lineas.ToList();
            return View();
        }

        // GET: Linea/Create
        public ActionResult Create()
        {
            IEnumerable<MunicipalidadModel> dropdown_municipalidad = db.Database.SqlQuery<MunicipalidadModel>("select * from MUNICIPALIDADES");
            ViewBag.dropdown_municipalidades = new SelectList(dropdown_municipalidad.ToList(), "idmunicipalidad", "nombre_municipalidad");
            return View();
        }

        // POST: Linea/Create
        [HttpPost]
        public ActionResult Create(List<LineaModel> datos) 
        {
            
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_INSERTLINEA] '" + i.nombre_linea + "', " + i.idmunicipalidad + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Linea/Edit/5
        public ActionResult Edit(int id)
        {
            var idmuni = 0;

            IEnumerable<LineaModel> lineas = db.Database.SqlQuery<LineaModel>("select * from LINEAS where idlinea = " + id);

            foreach(var x in lineas)
            {
                idmuni = x.idmunicipalidad;
                ViewBag.nombrelinea = x.nombre_linea;
                ViewBag.idlinea = id;
            }

            IEnumerable<MunicipalidadModel> dropdown_municipalidad = db.Database.SqlQuery<MunicipalidadModel>("select * from MUNICIPALIDADES");

            List<SelectListItem> lineaslist = new List<SelectListItem>();
            foreach (var i in dropdown_municipalidad)
            {
                if (i.idmunicipalidad == idmuni)
                {
                    lineaslist.Add(new SelectListItem() { Text = i.nombre_municipalidad.ToString(), Value = i.idmunicipalidad.ToString(), Selected = true });
                }
                else
                {
                    lineaslist.Add(new SelectListItem() { Text = i.nombre_municipalidad.ToString(), Value = i.idmunicipalidad.ToString() });
                }
            }
            ViewBag.dropdown_municipalidades = lineaslist;
            return View();
        }

        // POST: Linea/Edit/5
        [HttpPost]
        public ActionResult Edit(List<LineaModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_UPDATELINEA]" + i.idlinea + ", '" + i.nombre_linea + "', " + i.idmunicipalidad + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Linea/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<ConsultarLinea> lineas = db.Database.SqlQuery<ConsultarLinea>("select * from VW_LINEASMUNICIPALIDAD where idlinea = " + id);
            ViewBag.Lineas = lineas.ToList();
            return View();
        }

        // POST: Linea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                db.Database.ExecuteSqlCommand("exec [SP_DELETELINEA] " + id);
                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
