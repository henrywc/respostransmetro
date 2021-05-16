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
    public class GuardiaController : Controller
    {

        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Guardia
        public ActionResult Index()
        {
            IEnumerable<ConsultarGuardia> guardias = db.Database.SqlQuery<ConsultarGuardia>("select * from VW_GUARDIASACCESO");
            ViewBag.Guardias = guardias.ToList();
            return View();
        }

        // GET: Guardia/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<ConsultarGuardia> guardias = db.Database.SqlQuery<ConsultarGuardia>("select * from VW_GUARDIASACCESO where idguardia = " + id);
            ViewBag.Guardias = guardias.ToList();
            return View();
        }

        // GET: Guardia/Create
        public ActionResult Create()
        {
            IEnumerable<AccesoModel> dropdown_acceso = db.Database.SqlQuery<AccesoModel>("select * from VW_GUARDIAACCESOESTACIONES");
            ViewBag.dropdown_accesos = new SelectList(dropdown_acceso.ToList(), "idacceso", "nombre_acceso");
            return View();
        }

        // POST: Guardia/Create
        [HttpPost]
        public ActionResult Create(List<GuardiaModel> datos)
        {

            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_INSERTGUARDIA] '" + i.nombre_guardia + "', '" + i.direccion_guardia + "', '" + i.correo_guardia + "', " + i.edad_guardia + ", " + i.telefono_guardia + ", " + i.celular_guardia + ", " + i.idacceso + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Acceso/Edit/5
        public ActionResult Edit(int id)
        {
            var idesta = 0;

            IEnumerable<GuardiaModel> guardias = db.Database.SqlQuery<GuardiaModel>("select * from GUARDIAS where idguardia = " + id);

            foreach (var x in guardias)
            {
                idesta = x.idacceso;
                ViewBag.nombre_guardia = x.nombre_guardia;
                ViewBag.direccion_guardia = x.direccion_guardia;
                ViewBag.correo_guardia = x.correo_guardia;
                ViewBag.edad_guardia = x.edad_guardia;
                ViewBag.telefono_guardia = x.telefono_guardia;
                ViewBag.celular_guardia = x.celular_guardia;
                ViewBag.idguardia = id;
            }

            IEnumerable<AccesoModel> dropdown_acceso = db.Database.SqlQuery<AccesoModel>("select * from ACCESOS");

            List<SelectListItem> guardiaslist = new List<SelectListItem>();
            foreach (var i in dropdown_acceso)
            {
                if (i.idacceso == idesta)
                {
                    guardiaslist.Add(new SelectListItem() { Text = i.nombre_acceso.ToString(), Value = i.idacceso.ToString(), Selected = true });
                }
                else
                {
                    guardiaslist.Add(new SelectListItem() { Text = i.nombre_acceso.ToString(), Value = i.idacceso.ToString() });
                }
            }
            ViewBag.dropdown_accesos = guardiaslist;
            return View();
        }

        // POST: Acceso/Edit/5
        [HttpPost]
        public ActionResult Edit(List<GuardiaModel> datos)
        {
            if (datos is null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var i in datos)
                {
                    db.Database.ExecuteSqlCommand("exec [SP_UPDATEGUARDIA]" + i.idguardia + ", '" + i.nombre_guardia + "', '" + i.direccion_guardia + "', '" + i.correo_guardia + "', " + i.edad_guardia + ", " + i.telefono_guardia + ", " + i.celular_guardia + ", " + i.idacceso + "");
                }
                return RedirectToAction("/Index");
            }
        }

        // GET: Guardia/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<ConsultarGuardia> guardias = db.Database.SqlQuery<ConsultarGuardia>("select * from VW_GUARDIASACCESO where idguardia = " + id);
            ViewBag.Guardias = guardias.ToList();
            return View();
        }

        // POST: Guardia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Database.ExecuteSqlCommand("exec [SP_DELETEGUARDIA] " + id);
                return RedirectToAction("/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
