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
    public class PilotoEducacionController : Controller
    {
        public static BlackSysEntities db = new BlackSysEntities();

        // GET: PilotoEducacion
        public ActionResult Index()
        {
            IEnumerable<ConsultarPilotoEducacion> pilotoseducacion = db.Database.SqlQuery<ConsultarPilotoEducacion>("select * from VW_PILOTOS_EDUCACIONPILOTO");
            ViewBag.PilotosEducacion = pilotoseducacion.ToList();
            return View();
        }

        // GET: PilotoEducacion/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<ConsultarPilotoEducacion> pilotoseducacion = db.Database.SqlQuery<ConsultarPilotoEducacion>("select * from VW_PILOTOS_EDUCACIONPILOTO where idpilotos_educacion = " + id);
            ViewBag.PilotosEducacion = pilotoseducacion.ToList();
            return View();
        }

        // GET: PilotoEducacion/Create
        public ActionResult Create()
        {
            IEnumerable<PilotoModel> dropdown_piloto = db.Database.SqlQuery<PilotoModel>("select * from PILOTOS");
            ViewBag.dropdown_pilotos = new SelectList(dropdown_piloto.ToList(), "idpiloto", "nombre_piloto");
            return View();
        }

        // POST: PilotoEducacion/Create
        [HttpPost]
        public ActionResult Create(List<PilotoEducacionModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_INSERTPILOTO] '" + i.nivelcursado + "', '" + i.fechanivelcursado + "', '" + i.centroeducativo + "', " + i.idpiloto + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: PilotoEducacion/Edit/5
        public ActionResult Edit(int id)
        {
            var idpilo = 0;
            
            IEnumerable<PilotoEducacionModel> pilotoseducacion  = db.Database.SqlQuery<PilotoEducacionModel>("select * from PILOTOS_EDUCACION where idpilotos_educacion = " + id);

            foreach (var x in pilotoseducacion)
            {
                idpilo = x.idpiloto;
                ViewBag.nivelcursado = x.nivelcursado;
                ViewBag.fechanivelcursado = x.fechanivelcursado;
                ViewBag.centroeducativo = x.centroeducativo;
                ViewBag.idpilotos_educacion = id;
            }

            IEnumerable<PilotoModel> dropdown_piloto = db.Database.SqlQuery<PilotoModel>("select * from PILOTOS");

            List<SelectListItem> pilotoseducacionlist = new List<SelectListItem>();
            foreach (var i in dropdown_piloto)
            {
                if (i.idpiloto == idpilo)
                {
                    pilotoseducacionlist.Add(new SelectListItem() { Text = i.nombre_piloto.ToString(), Value = i.idpiloto.ToString(), Selected = true });
                }
                else
                {
                    pilotoseducacionlist.Add(new SelectListItem() { Text = i.nombre_piloto.ToString(), Value = i.idpiloto.ToString() });
                }
            }
            ViewBag.dropdown_pilotos = pilotoseducacionlist;
            return View();
        }

        // POST: PilotoEducacion/Edit/5
        [HttpPost]
        public ActionResult Edit(List<PilotoEducacionModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_UPDATEEDUCACION_PILOTO]" + i.idpilotos_educacion + ", '" + i.nivelcursado + "', '" + i.fechanivelcursado + "', '" + i.centroeducativo + "', " + i.idpiloto + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: PilotoEducacion/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<ConsultarPilotoEducacion> pilotoseducacion = db.Database.SqlQuery<ConsultarPilotoEducacion>("select * from VW_PILOTOS_EDUCACIONPILOTO where idpilotos_educacion = " + id);
            ViewBag.PilotosEducacion = pilotoseducacion.ToList();
            return View();
          }

        // POST: PilotoEducacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Database.ExecuteSqlCommand("exec [SP_DELETEPILOTOS_EDUCACION] " + id);
                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
