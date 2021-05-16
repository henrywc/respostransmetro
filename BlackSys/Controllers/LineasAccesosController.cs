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
    public class LineasAccesosController : Controller
    {
        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Lineas_Estaciones
        public ActionResult LineasAccesos()
        {
            IEnumerable<LineaModel> dropdown_linea = db.Database.SqlQuery<LineaModel>("select * from VW_LINEAS");
            ViewBag.dropdown_linea = new SelectList(dropdown_linea.ToList(), "idlinea", "nombre_linea");
            ViewBag.Accesos = "";
            return View();
        }

        // POST: Lineas_Estaciones
        [HttpPost]
        public ActionResult LineasAccesos(int? idlinea)
        {
            IEnumerable<LineaModel> dropdown_linea = db.Database.SqlQuery<LineaModel>("select * from VW_LINEAS");
            List<SelectListItem> lineaslist = new List<SelectListItem>();
            foreach (var i in dropdown_linea)
            {
                if (i.idlinea == idlinea)
                {
                    lineaslist.Add(new SelectListItem() { Text = i.nombre_linea.ToString(), Value = i.idlinea.ToString(), Selected = true });
                }
                else
                {
                    lineaslist.Add(new SelectListItem() { Text = i.nombre_linea.ToString(), Value = i.idlinea.ToString() });
                }
            }
            ViewBag.dropdown_linea = lineaslist;
            IEnumerable<ConsultarLineasAccesos> tabla_accesos = db.Database.SqlQuery<ConsultarLineasAccesos>("select * from VW_LINEACCESOS where idlinea = " + idlinea);
            ViewBag.Accesos = tabla_accesos.ToList();
            return View();
        }

    }
}