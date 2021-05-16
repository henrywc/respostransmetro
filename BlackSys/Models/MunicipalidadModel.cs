using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackSys.Models
{
    [Table("MUNICIPALIDADES")]

    public class MunicipalidadModel
    {
        
        [Key]
        public int idmunicipalidad { get; set; }

        [Required(ErrorMessage = "Obligatorio"), MaxLength(50, ErrorMessage = "No más de 50 carácteres")]
        [Display(Name = "Nombre Municipalidad")]
        public string nombre_municipalidad { get; set; }


    }
}