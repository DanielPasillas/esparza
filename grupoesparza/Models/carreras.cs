//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace grupoesparza.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class carreras
    {
        public carreras()
        {
            this.admin_user_table = new HashSet<admin_user_table>();
            this.grupos = new HashSet<grupos>();
        }
    
        public long id_carrera { get; set; }
        public long id_universidad { get; set; }
        public string NombreCarrera { get; set; }
        public string Generacion { get; set; }
        public int estatus { get; set; }
    
        public virtual ICollection<admin_user_table> admin_user_table { get; set; }
        public virtual universidades universidades { get; set; }
        public virtual ICollection<grupos> grupos { get; set; }
    }
}
