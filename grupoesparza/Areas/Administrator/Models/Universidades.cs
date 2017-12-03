using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using grupoesparza.Models;
using System.Web;

namespace grupoesparza.Areas.Administrator.Models
{
    public class Universidades : universidades 
    {
        [Required(ErrorMessage = "El campo nombre no debe quedar vacío.")]
        [Display(Name = "Universidad")]
        public string nombreUniversidad { get; set; }

        public Universidades(universidades _universidades)
        {
            id_universidad = _universidades.id_universidad;
            this.nombreUniversidad = _universidades.NombreUniversidad;
            estatus = _universidades.estatus;
        }
    }
}