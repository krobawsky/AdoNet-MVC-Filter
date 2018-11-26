using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laboratorio_14.Models
{
    public class AlumnoModel
    {

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "Codigo requerido")]
        public string codalu { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre requerido")]
        public string nomalu { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Display(Name = "Codigo Carrera")]
        public int codcar { get; set; }

        [Display(Name = "Fecha Inscripcion")]
        public DateTime fecha_ins { get; set; }

        [Display(Name = "Estado")]
        public int estado { get; set; }

        [Display(Name = "Foto")]
        public string Fotoalu { get; set; }

    }
}