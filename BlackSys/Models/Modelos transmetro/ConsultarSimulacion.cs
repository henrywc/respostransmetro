using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ConsultarSimulacion
    {
        public int? capacidadbus { get; set; }
        public double pasajerosenbus { get; set; }
        public int? pasajerosbajan { get; set; }
        public int? capestacion { get; set; }
        public double personaestacion { get; set; }
        public int? pasajerosabordan { get; set; }
        public int? idestacion { get; set; }
        public int? idbus { get; set; }
        public int? PorcentajeSubidosBus { get; set; }
        public int? PorcentajePesonasEstacion { get; set; }
    }
}