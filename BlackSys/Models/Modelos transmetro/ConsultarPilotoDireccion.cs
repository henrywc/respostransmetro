using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ConsultarPilotoDireccion
    {
        public int idpilotos_direccion { get; set; }
        public string direccion_piloto { get; set; }
        public string zona_piloto { get; set; }
        public string colonia_piloto { get; set; }
        public string municipio_piloto { get; set; }
        public string departamento_piloto { get; set; }
        public string nombre_piloto { get; set; }

    }
}