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
    public class BusController : Controller
    {

        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Bus
        public ActionResult Index()
        {
            IEnumerable<ConsultarBus> buses = db.Database.SqlQuery<ConsultarBus>("select * from VW_BUSES");
            ViewBag.Buses = buses.ToList();
            return View();
        }

        // GET: Bus/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<ConsultarBus> buses = db.Database.SqlQuery<ConsultarBus>("select * from VW_BUSES where idbus = " + id);
            ViewBag.Buses = buses.ToList();
            return View();
        }

        // GET: Bus/Create
        public ActionResult Create()
        {
            IEnumerable<LineaModel> dropdown_linea = db.Database.SqlQuery<LineaModel>("select * from LINEAS");
            ViewBag.dropdown_lineas = new SelectList(dropdown_linea.ToList(), "idlinea", "nombre_linea");

            IEnumerable<ParqueoModel> dropdown_parqueo = db.Database.SqlQuery<ParqueoModel>("select * from PARQUEOS");
            ViewBag.dropdown_parqueos = new SelectList(dropdown_parqueo.ToList(), "idparqueo", "nombre_parqueo");

            IEnumerable<PilotoModel> dropdown_piloto = db.Database.SqlQuery<PilotoModel>("select * from PILOTOS");
            ViewBag.dropdown_pilotos = new SelectList(dropdown_piloto.ToList(), "idpiloto", "nombre_piloto");

            return View();
        }

        // POST: Bus/Create
        [HttpPost]
        public ActionResult Create(List<BusModel> datos)
        {

            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_INSERTBUS] '" + i.nombre_bus + "', " + i.idlinea + ", " + i.capacidad + ", " + i.idparqueo + ", " + i.idpiloto + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Bus/Edit/5
        public ActionResult Edit(int id)
        {
            var idlin = 0;
            var idpar = 0;
            var idpil = 0;

            IEnumerable<BusModel> buses = db.Database.SqlQuery<BusModel>("select * from VW_BUSESNULL where idbus = " + id);

            foreach (var x in buses)
            {
                idlin = x.idlinea;
                idpar = x.idparqueo;
                idpil = x.idpiloto;
                ViewBag.nombre_bus = x.nombre_bus;
                ViewBag.capacidad = x.capacidad;
                ViewBag.idbus = id;
            }

            IEnumerable<LineaModel> dropdown_linea = db.Database.SqlQuery<LineaModel>("select * from LINEAS");

            List<SelectListItem> lineaslist = new List<SelectListItem>();
            foreach (var i in dropdown_linea)
            {
                if (i.idlinea == idlin)
                {
                    lineaslist.Add(new SelectListItem() { Text = i.nombre_linea.ToString(), Value = i.idlinea.ToString(), Selected = true });
                }
                else
                {
                    lineaslist.Add(new SelectListItem() { Text = i.nombre_linea.ToString(), Value = i.idlinea.ToString() });
                }
            }
            ViewBag.dropdown_lineas = lineaslist;

            IEnumerable<ParqueoModel> dropdown_parqueo = db.Database.SqlQuery<ParqueoModel>("select * from PARQUEOS");

            List<SelectListItem> parqueoslist = new List<SelectListItem>();
            foreach (var i in dropdown_parqueo)
            {
                if (i.idparqueo == idpar)
                {
                    parqueoslist.Add(new SelectListItem() { Text = i.nombre_parqueo.ToString(), Value = i.idparqueo.ToString(), Selected = true });
                }
                else
                {
                    parqueoslist.Add(new SelectListItem() { Text = i.nombre_parqueo.ToString(), Value = i.idparqueo.ToString() });
                }
            }
            ViewBag.dropdown_parqueos = parqueoslist;


            IEnumerable<PilotoModel> dropdown_piloto = db.Database.SqlQuery<PilotoModel>("select * from PILOTOS");

            List<SelectListItem> pilotoslist = new List<SelectListItem>();
            foreach (var i in dropdown_piloto)
            {
                if (i.idpiloto == idpil)
                {
                    pilotoslist.Add(new SelectListItem() { Text = i.nombre_piloto.ToString(), Value = i.idpiloto.ToString(), Selected = true });
                }
                else
                {
                    pilotoslist.Add(new SelectListItem() { Text = i.nombre_piloto.ToString(), Value = i.idpiloto.ToString() });
                }
            }
            ViewBag.dropdown_pilotos = pilotoslist;


            return View();
        }

        // POST: Bus/Edit/5
        [HttpPost]
        public ActionResult Edit(List<BusModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_UPDATEBUS]" + i.idbus + ", '" + i.nombre_bus + "', " + i.idlinea + ", " + i.capacidad + ", " + i.idparqueo + ", " + i.idpiloto + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Bus/ValidarParqueo
        public JsonResult ValidarParqueo(int id)
        {
            var contador = 0;

            IEnumerable<BusModel> buses = db.Database.SqlQuery<BusModel>("select * from BUSES where idparqueo = " + id);

            foreach(var i in buses)
            {
                contador = contador + 1;

            }

            if (contador > 0)
            {
                return Json(new { existe = 1 },JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { existe = 2 },JsonRequestBehavior.AllowGet);
            }


        }


        // GET: Bus/ValidarLínea
        public JsonResult ValidarLinea(int id)
        {
            var disponibilidad = 0;

            IEnumerable<ConsultarValidarLineaDisponibilidad> lineas = db.Database.SqlQuery<ConsultarValidarLineaDisponibilidad>("select * from VW_VALIDARLINEA where idlinea = " + id);

            foreach (var x in lineas)
            {
                disponibilidad = x.disponibilidad;
            }

            if (disponibilidad > 0)
            {
                return Json(new { existe = 1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { existe = 2 }, JsonRequestBehavior.AllowGet);
            }


        }



        // GET: Bus/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<ConsultarBus> buses = db.Database.SqlQuery<ConsultarBus>("select * from VW_BUSES where idbus = " + id);
            ViewBag.Buses = buses.ToList();
            return View();
        }

        // POST: Bus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                db.Database.ExecuteSqlCommand("exec [SP_DELETEBUS] " + id);
                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
