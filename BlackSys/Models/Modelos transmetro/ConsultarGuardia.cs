using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ConsultarGuardia
    {
        public int idguardia { get; set; }
        public string nombre_guardia { get; set; }
        public string direccion_guardia { get; set; }
        public string correo_guardia { get; set; }
        public int edad_guardia { get; set; }
        public int telefono_guardia { get; set; }
        public int celular_guardia { get; set; }
        public string nombre_acceso { get; set; }


    }
}