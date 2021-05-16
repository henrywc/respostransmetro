using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ConsultarValidarLineaDisponibilidad
    {
        public int idlinea { get; set; }
        public string nombre_linea { get; set; }
        public int disponibilidad { get; set; }
    }
}