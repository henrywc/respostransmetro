using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackSys.Models
{
    [Table("PILOTOS")]

    public class PilotoModel
    {

       [Key]
        public int idpiloto { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Nombre ")]
        public string nombre_piloto { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Dirección Corta")]
        public string direccion_piloto { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Correo")]
        public string correo_piloto { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Edad")]
        public int edad_piloto { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Teléfono de casa")]
        public int telefono_piloto { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Celular")]
        public int celular_piloto { get; set; }

    }
}