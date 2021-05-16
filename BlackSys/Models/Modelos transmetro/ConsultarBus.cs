using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ConsultarBus
    {
        public int idbus { get; set; }
        public string nombre_bus { get; set; }
        public string nombre_linea { get; set; }
        public string nombre_estacion { get; set; }
        public int capacidad { get; set; }
        public string nombre_parqueo { get; set; }
        public string nombre_piloto { get; set; }
    }
}