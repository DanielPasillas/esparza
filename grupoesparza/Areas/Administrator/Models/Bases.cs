using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace grupoesparza.Areas.Administrator.Models
{
    public class Bases
    {
        public long id_base { get; set; }

        [Required]
        public long id_paquete { get; set; }

        [Required]
        [Display(Name = "Nombre base")]
        public string NombreBase { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Imágen")]
        public string Imagen { get; set; }

        public int estatus { get; set; }

        public Bases()
        {
            id_base = 0;
            estatus = 1;
        }


    }
}