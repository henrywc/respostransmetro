using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BlackSys.Models.Modelos_transmetro
{
    public class LineaModel
    {

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Nombre Línea")]
        public string nombre_linea { get; set; }

        public int idmunicipalidad { get; set; }

        public int? idlinea { get; set; }


    }
}