using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BlackSys.Models.Modelos_transmetro
{
    public class AccesoModel
    {
        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Nombre Acceso")]
        public string nombre_acceso { get; set; }

        public int idestacion { get; set; }
        public int? idacceso { get; set; }

    }
}