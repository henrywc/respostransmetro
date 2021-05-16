using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ConsultarLineasEstaciones
    {
        public int idestacion { get; set; }
        public string nombre_estacion { get; set; }
        public int? idlinea { get; set; }
        public int orden { get; set; }
        public int insert { get; set; }
        public int distancia { get; set; }

    }
}