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
    public class LineasEstacionesController : Controller
    {
        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Lineas_Estaciones
        public ActionResult LineasEstaciones()
        {
            IEnumerable<LineaModel> dropdown_linea = db.Database.SqlQuery<LineaModel>("select * from VW_LINEAS");
            ViewBag.dropdown_linea = new SelectList(dropdown_linea.ToList(), "idlinea", "nombre_linea");
            ViewBag.Estaciones = "";
            ViewBag.Mensaje = "";
            return View();
        }



        // POST: Lineas_Estaciones
        [HttpPost]
        public ActionResult LineasEstaciones(int? idlinea)
        {

            IEnumerable<ConsultarLineasEstacionesDistancia> distanciaporlinea = db.Database.SqlQuery<ConsultarLineasEstacionesDistancia>("select * from VW_SUMADISTANCIALINEA where idlinea = " + idlinea).ToList();
            foreach(var i in distanciaporlinea){
                ViewBag.Mensaje = "La distancia total de la línea es " + i.distancia.ToString(); 
            }



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
            IEnumerable<ConsultarLineasEstaciones> tabla_estaciones = db.Database.SqlQuery<ConsultarLineasEstaciones>("[SP_LINEAS_ESTACIONES_ORDEN]" + idlinea).ToList();
            ViewBag.Estaciones = tabla_estaciones.ToList();
            return View();


        }


    public JsonResult InsertarLineasEstaciones(List<LineaEstacion> datos)
        {

            var idlinea = 0;

 
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



            if (datos is null)
            {
                return Json(1, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var idlinea1 = 0;

                foreach (var x in datos)
                {
                    idlinea1 = x.idlinea;
                }

                db.Database.ExecuteSqlCommand("exec [DELETELINEAS_ESTACIONES] " + idlinea1);

                foreach (var x in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [INSERTLINEAS_ESTACIONES] " + x.idlinea + ", " + x.idestacion + ", " + x.orden + ", " + x.distancia + "");
                }

                return Json(1, JsonRequestBehavior.AllowGet);


            }


        }

    }
}