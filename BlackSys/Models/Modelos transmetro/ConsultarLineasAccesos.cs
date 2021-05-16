using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ConsultarLineasAccesos
    {
        public int idlinea { get; set; }
        public string nombre_linea { get; set; }
        public string nombre_estacion { get; set; }
        public string nombre_acceso { get; set; }
    }
}