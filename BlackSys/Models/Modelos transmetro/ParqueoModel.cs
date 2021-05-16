using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class ParqueoModel
    {
        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Nombre Parqueo")]
        public string nombre_parqueo { get; set; }

        public int idestacion { get; set; }
        public int? idparqueo { get; set; }


    }
}