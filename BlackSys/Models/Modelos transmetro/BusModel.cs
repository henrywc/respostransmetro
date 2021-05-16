using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class BusModel
    {
        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Nombre Bus")]
        public string nombre_bus { get; set; }

        public int idlinea { get; set; }

        public int capacidad { get; set; }

        public int idparqueo { get; set; }

        public int idpiloto { get; set; }
 
        public int? idbus { get; set; }

    }
}