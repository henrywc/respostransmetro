using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BlackSys.Models.Modelos_transmetro
{
    public class PilotoEducacionModel
    {
        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Último grado académico")]
        public string nivelcursado { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(4, ErrorMessage = "No más de 4 carácteres")]
        [Display(Name = "Año del último grado académico")]
        public string fechanivelcursado { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Centro Educativo")]
        public string centroeducativo { get; set; }
        public int idpiloto { get; set; }
        public int idpilotos_educacion { get; set; }

    }
}