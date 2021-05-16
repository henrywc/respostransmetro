using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class LineaEstacion
    {
           
        public int idlinea { get; set; }

        public int idestacion { get; set; }

        public int orden { get; set; }
        public int distancia { get; set; }

    }
}
