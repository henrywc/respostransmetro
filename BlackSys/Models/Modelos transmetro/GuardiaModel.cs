using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class GuardiaModel
    {

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Nombre ")]
        public string nombre_guardia { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Dirección ")]
        public string direccion_guardia { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Correo ")]
        public string correo_guardia { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Edad ")]
        public int edad_guardia { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Teléfono ")]
        public int telefono_guardia { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Celular ")]
        public int celular_guardia { get; set; }

        public int idacceso { get; set; }
        public int? idguardia { get; set; }

    }

}