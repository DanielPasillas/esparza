using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace grupoesparza.Areas.Administrator.Models
{
    public class Grupos
    {
        public long id_grupo { get; set; }

        [Required]
        public long id_carrera { get; set; }

        [Required]
        [Display(Name = "Grado")]
        public string grado { get; set; }

        [Required]
        [Display(Name = "Grupo")]
        public string grupo { get; set; }

        [Required]
        [Display(Name = "Número contratos")]
        public int num_contratos { get; set; }

        public int estatus { get; set; }

        public Grupos()
        {
            id_grupo = 0;
            estatus  = 0; 
        }
    }
}