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
    
    public partial class universidades
    {
        public universidades()
        {
            this.admin_user_table = new HashSet<admin_user_table>();
            this.carreras = new HashSet<carreras>();
        }
    
        public long id_universidad { get; set; }
        public string NombreUniversidad { get; set; }
        public int estatus { get; set; }
    
        public virtual ICollection<admin_user_table> admin_user_table { get; set; }
        public virtual ICollection<carreras> carreras { get; set; }
    }
}
