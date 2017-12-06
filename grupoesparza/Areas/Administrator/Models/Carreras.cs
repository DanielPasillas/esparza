using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace grupoesparza.Areas.Administrator.Models
{
    public class Carreras
    {
        public long id_carrera { get; set; }
        public long id_universidad { get; set; }
        public string Universidad { get; set; }

        [Required(ErrorMessage = "El nombre no debe quedar vacío")]
        [Display(Name = "Nombre carrera")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "Ingrese la generación")]
        [Display(Name = "Generación")]
        public string Generacion { get; set; }
    }
}