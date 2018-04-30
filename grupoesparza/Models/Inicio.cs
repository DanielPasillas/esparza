using System;
using grupoesparza.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace grupoesparza.Models
{
    public class Inicio
    {
        public IEnumerable<galerias> Gallery { get; set; }
        public Contacto Contacto { get; set; }
    }
}