using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BlackSys.Models.Modelos_transmetro
{
    public class PilotoDireccionModel
    {
        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Dirección")]
        public string direccion_piloto { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Zona")]
        public string zona_piloto { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Colonia")]
        public string colonia_piloto { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Municipio")]
        public string municipio_piloto { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Departamento")]
        public string departamento_piloto { get; set; }

        public int idpiloto { get; set; }

        public int? idpilotos_direccion { get; set; }


    }

}