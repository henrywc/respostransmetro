using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlackSys.Models.Modelos_transmetro
{
    public class EstacionModel
    {

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Nombre Estación")]
        public string nombre_estacion { get; set; }
        public int idmunicipalidad { get; set; }
        public int capacidad { get; set; }
        public int? idestacion { get; set; }

    }
}