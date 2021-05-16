using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ConsultarEstacion
    {
        public int idestacion { get; set; }
        public string nombre_estacion { get; set; }
        public int capacidad { get; set; }
        public string nombre_municipalidad { get; set; }

    }
}