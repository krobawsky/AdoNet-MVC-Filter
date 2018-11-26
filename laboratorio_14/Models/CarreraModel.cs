using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laboratorio_14.Models
{
    public class CarreraModel
    {

        [Display(Name = "Codigo")]
        public string codcar { get; set; }

        [Display(Name = "Carrera")]
        public string nomcar { get; set; }

    }
}