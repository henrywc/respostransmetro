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
    public class EstacionController : Controller
    {

        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Estacion
        //[Route("Controladores transmetro/EstacionController")]

        public ActionResult Index()
        {
            IEnumerable<ConsultarEstacion> estaciones = db.Database.SqlQuery<ConsultarEstacion>("select * from VW_ESTACIONESMUNICIPALIDAD");
            ViewBag.Estaciones = estaciones.ToList();
            return View();
        }

        // GET: Estacion/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<ConsultarEstacion> estaciones = db.Database.SqlQuery<ConsultarEstacion>("select * from VW_ESTACIONESMUNICIPALIDAD where idestacion = " + id);
            ViewBag.Estaciones = estaciones.ToList();
            return View();
        }

        // GET: Estacion/Create
        public ActionResult Create()
        {
            IEnumerable<MunicipalidadModel> dropdown_municipalidad = db.Database.SqlQuery<MunicipalidadModel>("select * from MUNICIPALIDADES");
            ViewBag.dropdown_municipalidades = new SelectList(dropdown_municipalidad.ToList(), "idmunicipalidad", "nombre_municipalidad");
            return View();
        }

        // POST: Estacion/Create
        [HttpPost]
        public ActionResult Create(List<EstacionModel> datos)
        {

            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_INSERTESTACION] '" + i.nombre_estacion + "', " + i.idmunicipalidad + ", " + i.capacidad + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Estacion/Edit/5
        public ActionResult Edit(int id)
        { 
 
            var idmuni = 0;

            IEnumerable<EstacionModel> estaciones = db.Database.SqlQuery<EstacionModel>("select * from ESTACIONES where idestacion = " + id);

            foreach(var x in estaciones)
            {
                idmuni = x.idmunicipalidad;
                ViewBag.nombreestacion = x.nombre_estacion;
                ViewBag.capacidad = x.capacidad;
                ViewBag.idestacion = id;
            }

            IEnumerable<MunicipalidadModel> dropdown_municipalidad = db.Database.SqlQuery<MunicipalidadModel>("select * from MUNICIPALIDADES");

            List<SelectListItem> estacioneslist = new List<SelectListItem>();
            foreach (var i in dropdown_municipalidad)
            {
                if (i.idmunicipalidad == idmuni)
                {
                    estacioneslist.Add(new SelectListItem() { Text = i.nombre_municipalidad.ToString(), Value = i.idmunicipalidad.ToString(), Selected = true });
                }
                else
                {
                    estacioneslist.Add(new SelectListItem() { Text = i.nombre_municipalidad.ToString(), Value = i.idmunicipalidad.ToString() });
                }
            }
            ViewBag.dropdown_municipalidades = estacioneslist;
            return View();
        }

        // POST: Estacion/Edit/5
        [HttpPost]
        public ActionResult Edit(List<EstacionModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_UPDATEESTACION]" + i.idestacion + ", '" + i.nombre_estacion + "', " + i.idmunicipalidad + ", " + i.capacidad + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Estacion/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<ConsultarEstacion> estaciones = db.Database.SqlQuery<ConsultarEstacion>("select * from VW_ESTACIONESMUNICIPALIDAD where idestacion = " + id);
            ViewBag.Estaciones = estaciones.ToList();
            return View();
        }

        // POST: Estacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Database.ExecuteSqlCommand("exec [SP_DELETEESTACION] " + id);
                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
