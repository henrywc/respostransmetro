using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ConsultarDistancia
    {
        public int iddistancia { get; set; }
        public string estacion_origen { get; set; }
        public string estacion_destino { get; set; }
        public int distancia { get; set; }
        public string nombre_linea { get; set; }

    }
}