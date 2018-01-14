using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace grupoesparza.Areas.Administrator.Models
{
    public class Maderas
    {
        [Required]
        public long id_madera { get; set; }

        [Required]
        [Display(Name = "Nombre madera")]
        public string NombreMadera { get; set; }

        [Required]
        [Display(Name = "Imágen")]
        public string Imagen { get; set; }

        public int estatus { get; set; }

        public Maderas()
        {
            estatus   = 0;
            id_madera = 0;
        }
    }
}