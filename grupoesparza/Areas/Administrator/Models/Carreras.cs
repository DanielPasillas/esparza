using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace grupoesparza.Areas.Administrator.Models
{
    public class Carreras
    {
        public long id_carrera { get; set; }
        public string Universidad { get; set; }
        public string Carrera { get; set; }
        public string Generacion { get; set; }
    }
}