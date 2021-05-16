using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BlackSys.Models.Modelos_transmetro
{
    public class DistanciaModel
    {
        public int idorigen { get; set; }
        public int iddestino { get; set; }
        public int distancia { get; set; }
        public int idlinea { get; set; }
        public int? iddistancia { get; set; }

    }
}