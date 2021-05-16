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
    public class PilotoDireccionController : Controller
    {

        public static BlackSysEntities db = new BlackSysEntities();

        // GET: PilotoDireccion
        public ActionResult Index()
        {
            IEnumerable<ConsultarPilotoDireccion> pilotosdireccion = db.Database.SqlQuery<ConsultarPilotoDireccion>("select * from VW_PILOTOS_DIRECCIONPILOTO");
            ViewBag.PilotosDireccion = pilotosdireccion.ToList();
            return View();
        }

        // GET: PilotoDireccion/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<ConsultarPilotoDireccion> pilotosdireccion = db.Database.SqlQuery<ConsultarPilotoDireccion>("select * from VW_PILOTOS_DIRECCIONPILOTO where idpilotos_direccion = " + id);
            ViewBag.PilotosDireccion = pilotosdireccion.ToList();
            return View();
        }

        // GET: PilotoDireccion/Create
        public ActionResult Create()
        {
            IEnumerable<PilotoModel> dropdown_piloto = db.Database.SqlQuery<PilotoModel>("select * from PILOTOS");
            ViewBag.dropdown_pilotos = new SelectList(dropdown_piloto.ToList(), "idpiloto", "nombre_piloto");
            return View();
        }

        // POST: PilotoDireccion/Create
        [HttpPost]
        public ActionResult Create(List<PilotoDireccionModel> datos)
        {

            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_INSERTPILOTOS_DIRECCION] '" + i.direccion_piloto + "', '" + i.zona_piloto + "', '" + i.colonia_piloto + "', '" + i.municipio_piloto + "', '" + i.departamento_piloto + "', " + i.idpiloto + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: PilotoDireccion/Edit/5
        public ActionResult Edit(int id)
        {
            var idpilo = 0;

            IEnumerable<PilotoDireccionModel> pilotosdireccion = db.Database.SqlQuery<PilotoDireccionModel>("select * from PILOTOS_DIRECCION where idpilotos_direccion = " + id);

            foreach (var x in pilotosdireccion)
            {
                idpilo = x.idpiloto;
                ViewBag.direccion_piloto = x.direccion_piloto;
                ViewBag.zona_piloto = x.zona_piloto;
                ViewBag.colonia_piloto = x.colonia_piloto;
                ViewBag.municipio_piloto = x.municipio_piloto;
                ViewBag.departamento_piloto = x.departamento_piloto;
                ViewBag.idpilotos_direccion = id;
            }

            IEnumerable<PilotoModel> dropdown_piloto = db.Database.SqlQuery<PilotoModel>("select * from PILOTOS");

            List<SelectListItem> pilotosdireccionlist = new List<SelectListItem>();
            foreach (var i in dropdown_piloto)
            {
                if (i.idpiloto == idpilo)
                {
                    pilotosdireccionlist.Add(new SelectListItem() { Text = i.nombre_piloto.ToString(), Value = i.idpiloto.ToString(), Selected = true });
                }
                else
                {
                    pilotosdireccionlist.Add(new SelectListItem() { Text = i.nombre_piloto.ToString(), Value = i.idpiloto.ToString() });
                }
            }
            ViewBag.dropdown_pilotos = pilotosdireccionlist;
            return View();
        }

        // POST: PilotoDireccion/Edit/5
        [HttpPost]
        public ActionResult Edit(List<PilotoDireccionModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_UPDATEDIRECCION_PILOTO]" + i.idpilotos_direccion + ", '" + i.direccion_piloto + "', '" + i.zona_piloto + "', '" + i.colonia_piloto + "', '" + i.municipio_piloto + "', '" + i.departamento_piloto + "', " + i.idpiloto + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: PilotoDireccion/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<ConsultarPilotoDireccion> pilotosdireccion = db.Database.SqlQuery<ConsultarPilotoDireccion>("select * from VW_PILOTOS_DIRECCIONPILOTO where idpilotos_direccion = " + id);
            ViewBag.PilotosDireccion = pilotosdireccion.ToList();
            return View();
        }

        // POST: PilotoDireccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                db.Database.ExecuteSqlCommand("exec [SP_DELETEPILOTOS_DIRECCION] " + id);
                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
