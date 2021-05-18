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
    public class SimulacionController : Controller
    {

        public static BlackSysEntities db = new BlackSysEntities();

        // GET: Simulacion
        public ActionResult Index()
        {
            IEnumerable<EstacionModel> dropdown_estacion = db.Database.SqlQuery<EstacionModel>("select * from Estaciones");
            ViewBag.dropdown_estaciones = new SelectList(dropdown_estacion.ToList(), "idestacion", "nombre_estacion");

            IEnumerable<ConsultarBus> dropdownbus = db.Database.SqlQuery<ConsultarBus>("select * from VW_BUSES");
            ViewBag.dropdownbus = new SelectList(dropdownbus.ToList(), "idbus", "nombre_bus");
            return View();
        }

        public JsonResult ValidarCapacidad(List<SimulacionBusEstacion> datos)
        {
            var capacidadbus = 0;
            var pasajerosenbus = 0;
            var pasajerosbajan = 0;
            var pasajerosabordan = 0;
            var PorcentajeSubidosBus = 0;
            List<ConsultarSimulacion> lst = new List<ConsultarSimulacion>();
            foreach (var y in datos)
            {
                IEnumerable<ConsultarSimulacion> capacidad = db.Database.SqlQuery<ConsultarSimulacion>("select * from vw_simalacion where idbus = " + y.idbus + " and idestacion = " + y.idestacion).ToList();
                foreach (var x in capacidad)
                {
                    capacidadbus = (int)x.capacidadbus;
                    pasajerosenbus = Convert.ToInt32(x.pasajerosenbus);
                    pasajerosbajan = (int)x.pasajerosbajan;
                    pasajerosabordan = (int)x.pasajerosabordan;
                    PorcentajeSubidosBus = (int)x.PorcentajeSubidosBus;

                }

                foreach (var x in capacidad)
                {
                    lst.Add(new ConsultarSimulacion
                    {

                        capacidadbus = (int)x.capacidadbus,
                        pasajerosenbus = Convert.ToInt32(x.pasajerosenbus),
                        pasajerosbajan = (int)x.pasajerosbajan,
                        pasajerosabordan = (int)x.pasajerosabordan,
                        PorcentajeSubidosBus = (int)x.PorcentajeSubidosBus,
                    });
                }
            }
            var datos1 = lst.First();
            return Json(datos1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ContarPersonas(int id)
        {
            var capestacion = 0;
            var personaestacion = 0;
            var PorcentajePesonasEstacion = 0;


            IEnumerable<ConsultarSimulacion> capacidad = db.Database.SqlQuery<ConsultarSimulacion>("select top 1 * from vw_simalacion where idestacion = " + id).ToList();
            foreach (var x in capacidad)
            {
                capestacion = (int)x.capestacion;
                personaestacion = Convert.ToInt32(x.personaestacion);
                PorcentajePesonasEstacion = (int)x.PorcentajePesonasEstacion;

            }

            List<ConsultarSimulacion> lst = new List<ConsultarSimulacion>();

            foreach (var x in capacidad)
            {
                lst.Add(new ConsultarSimulacion
                {
                    capestacion = (int)x.capestacion,
                    personaestacion = Convert.ToInt32(x.personaestacion),
                    PorcentajePesonasEstacion = (int)x.PorcentajePesonasEstacion,
                });
            }

            var datos = lst.First();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidarLinea(List<SimulacionBusEstacion> datos)
        {
            var msg = "";
            List<ValidarLinea> lst = new List<ValidarLinea>();
            foreach (var y in datos)
            {
                IEnumerable<ValidarLinea> Mensaje = db.Database.SqlQuery<ValidarLinea>("[SP_VALIDARLINEA]" + y.idbus + "," + y.idestacion).ToList();

                foreach (var x in Mensaje)
                {
                    msg = x.Mensaje;

                }

                foreach (var x in Mensaje)
                {
                    lst.Add(new ValidarLinea
                    {

                        Mensaje = x.Mensaje,
                    });
                }
            }
            var datos1 = lst.First();
            return Json(datos1, JsonRequestBehavior.AllowGet);
        }

    }






}